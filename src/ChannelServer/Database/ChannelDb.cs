// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.Scripting;
using Melia.Channel.World;
using Melia.Shared.Const;
using Melia.Shared.Database;
using Melia.Shared.Util;
using Melia.Shared.World;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class ChannelDb : MeliaDb
	{
		/// <summary>
		/// Saves account
		/// </summary>
		/// <param name="account"></param>
		public bool SaveAccount(Account account)
		{
			using (ISession session = SessionFactory.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				session.SaveOrUpdate(account);
				this.SaveVariables("account:" + account.Id, account.Variables.Perm);
				tx.Commit();
				return true;
			}
		}

		/// <summary>
		/// Returns account with given name, or null if it doesn't exist.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Account GetAccount(string name)
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				var account = session.Query<Account>()
					.Where(x => x.Name == name)
					.FirstOrDefault();

				this.LoadVars("account:" + account.Id, account.Variables.Perm);

				return account;
			}
		}

		public Character GetCharacter(long accountId, long characterId)
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				var character = session.Query<Character>()
					.Where(x => x.AccountId == accountId)
					.Where(x => x.Id == characterId)
					.FirstOrDefault();

				this.LoadCharacterItems(character);
				this.LoadVars("character:" + character.Id, character.Variables.Perm);

				return character;
			}
		}

		public void SaveCharacter(Character character)
		{
			using (ISession session = SessionFactory.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				session.SaveOrUpdate(character);
				this.SaveCharacterItems(character);
				this.SaveVariables("character:" + character.Id, character.Variables.Perm);
				tx.Commit();
			}
		}

		/// <summary>
		/// Load character's items.
		/// </summary>
		/// <param name="characterId"></param>
		/// <returns></returns>
		private void LoadCharacterItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `items` WHERE `characterId` = @characterId ORDER BY `sort` ASC", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.Id);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var itemId = reader.GetInt32("itemId");
						var amount = reader.GetInt32("amount");
						var equipSlot = (EquipSlot)reader.GetByte("equipSlot");

						// Check item, in case its data was removed
						if (!ChannelServer.Instance.Data.ItemDb.Exists(itemId))
						{
							Log.Warning("ChannelDb.LoadCharacterItems: Item '{0}' not found, removing it from inventory.", itemId);
							continue;
						}

						var item = new Item(itemId, amount);

						if (!Enum.IsDefined(typeof(EquipSlot), equipSlot))
							character.Inventory.AddSilent(item);
						else
							character.Inventory.SetEquipSilent(equipSlot, item);
					}
				}
			}
		}

		/// <summary>
		/// Returns items for given character.
		/// </summary>
		/// <param name="characterId"></param>
		/// <returns></returns>
		public void SaveCharacterItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `items` WHERE `characterId` = @characterId", conn, trans))
				{
					mc.Parameters.AddWithValue("@characterId", character.Id);
					mc.ExecuteNonQuery();
				}

				var i = 0;
				foreach (var item in character.Inventory.GetItems().OrderBy(a => a.Key))
				{
					using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn))
					{
						cmd.Set("characterId", character.Id);
						cmd.Set("itemId", item.Value.Id);
						cmd.Set("amount", item.Value.Amount);
						cmd.Set("sort", i++);
						cmd.Set("equipSlot", 0x7F);

						cmd.Execute();
					}
				}

				foreach (var item in character.Inventory.GetEquip().Where(a => !(a.Value is DummyEquipItem)))
				{
					using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn))
					{
						cmd.Set("characterId", character.Id);
						cmd.Set("itemId", item.Value.Id);
						cmd.Set("amount", item.Value.Amount);
						cmd.Set("sort", 0);
						cmd.Set("equipSlot", (byte)item.Key);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Saves owner's variables in database.
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="vars"></param>
		public void SaveVariables(string owner, VariableManager vars)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `vars` WHERE `owner` = @owner", conn, trans))
				{
					mc.Parameters.AddWithValue("@owner", owner);
					mc.ExecuteNonQuery();
				}

				foreach (var var in vars.GetList())
				{
					if (var.Value == null)
						continue;

					// Get type
					string type;
					if (var.Value is byte) type = "1u";
					else if (var.Value is ushort) type = "2u";
					else if (var.Value is uint) type = "4u";
					else if (var.Value is ulong) type = "8u";
					else if (var.Value is sbyte) type = "1";
					else if (var.Value is short) type = "2";
					else if (var.Value is int) type = "4";
					else if (var.Value is long) type = "8";
					else if (var.Value is float) type = "f";
					else if (var.Value is double) type = "d";
					else if (var.Value is bool) type = "b";
					else if (var.Value is string) type = "s";
					else
					{
						Log.Warning("SaveVars: Skipping variable '{0}', unsupported type '{1}'.", var.Key, var.Value.GetType().Name);
						continue;
					}

					// Get value
					var val = "";
					switch (type)
					{
						case "f": val = ((float)var.Value).ToString(CultureInfo.InvariantCulture); break;
						case "d": val = ((double)var.Value).ToString(CultureInfo.InvariantCulture); break;
						default: val = var.Value.ToString(); break;
					}

					// Make sure value isn't too big for the mediumtext field
					// (unlikely as it may be). Size: 16,777,215
					if (val.Length > (1 << 24) - 1)
					{
						Log.Warning("SaveVars: Skipping variable '{0}', it's too big.", var.Key);
						continue;
					}

					// Save
					using (var cmd = new InsertCommand("INSERT INTO `vars` {0}", conn, trans))
					{
						cmd.Set("owner", owner);
						cmd.Set("name", var.Key);
						cmd.Set("type", type);
						cmd.Set("value", val);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads owner's variables into the variable manager.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public void LoadVars(string owner, VariableManager vars)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `vars` WHERE `owner` = @owner", conn))
			{
				mc.Parameters.AddWithValue("@owner", owner);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var name = reader.GetString("name");
						var type = reader.GetString("type");
						var val = reader.GetStringSafe("value");

						if (val == null)
							continue;

						try
						{
							switch (type)
							{
								case "1u": vars[name] = byte.Parse(val); break;
								case "2u": vars[name] = ushort.Parse(val); break;
								case "4u": vars[name] = uint.Parse(val); break;
								case "8u": vars[name] = ulong.Parse(val); break;
								case "1": vars[name] = sbyte.Parse(val); break;
								case "2": vars[name] = short.Parse(val); break;
								case "4": vars[name] = int.Parse(val); break;
								case "8": vars[name] = long.Parse(val); break;
								case "f": vars[name] = float.Parse(val, CultureInfo.InvariantCulture); break;
								case "d": vars[name] = double.Parse(val, CultureInfo.InvariantCulture); break;
								case "b": vars[name] = bool.Parse(val); break;
								case "s": vars[name] = val; break;

								default:
									Log.Warning("LoadVars: Unknown variable type '{0}'.", type);
									continue;
							}
						}
						catch (FormatException)
						{
							Log.Warning("LoadVars: Variable '{0}' could not be parsed as type '{1}'. Value: '{2}', Owner: '{3}'", name, type, val, owner);
							continue;
						}
						catch (OverflowException)
						{
							Log.Warning("LoadVars: Value '{2}' of variable '{0}' doesn't fit into type '{1}'. Owner: '{3}'", name, type, val, owner);
							continue;
						}
					}
				}
			}
		}
	}
}
