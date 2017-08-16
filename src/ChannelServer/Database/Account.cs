// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.Scripting;
using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	/// <summary>
	/// A player's account.
	/// </summary>
	public class Account
	{
		/// <summary>
		/// Account id
		/// </summary>
		public virtual long Id { get; protected set; }

		/// <summary>
		/// Account name
		/// </summary>
		public virtual string Name { get; protected set; }

		/// <summary>
		/// Account's team name
		/// </summary>
		public virtual string TeamName { get; protected set; }

		/// <summary>
		/// The account's authority level, used to determine if a character
		/// can use a specific GM command.
		/// </summary>
		public virtual int Authority { get; protected set; }

		/// <summary>
		/// The account's settings.
		/// </summary>
		public virtual AccountSettings Settings { get; protected set; }

		/// <summary>
		/// Account's scripting variables.
		/// </summary>
		public virtual Variables Variables { get; protected set; }


		/// <summary>
		/// Amount of medals (iCoins).
		/// </summary>
		public virtual int Medals { get; protected set; }

		/// <summary>
		/// Id of the barrack map.
		/// </summary>
		public virtual int SelectedBarrack { get; protected set; }

		/// <summary>
		/// Contains all visible portions of maps.
		/// </summary>
		public virtual IList<MapVisibility> ExploredMaps { get; protected set; }

		/// <summary>
		/// List of chat macros.
		/// </summary>
		public virtual IList<ChatMacro> ChatMacros { get; protected set; }

		/// <summary>
		/// lock for updating the account
		/// </summary>
		private object _key = new object();

		/// <summary>
		/// Creates new account.
		/// </summary>
		public Account()
		{
			this.Medals = 500;
			this.SelectedBarrack = 11;

			this.Settings = new AccountSettings();
			this.Variables = new Variables();
			this.ChatMacros = new List<ChatMacro>();
		}

		/// <summary>
		/// Returns the chat macros for an account.
		/// </summary>
		/// <returns></returns>
		public virtual IReadOnlyList<ChatMacro> GetChatMacros()
		{
			return this.ChatMacros.ToList().AsReadOnly();
		}

		/// <summary>
		/// Adds a chat macro to the account.
		/// </summary>
		/// <param name="macro"></param>
		public virtual void AddChatMacro(ChatMacro macro)
		{
			lock(this._key)
			{
				if (macro.Slot > 10)
					return;

				var old = this.ChatMacros.FirstOrDefault(x => x.Slot == macro.Slot);
				if (old != null)
				{
					old.Update(macro.Message, macro.Pose);
					return;
				}

				this.ChatMacros.Add(macro);
			}
		}

		public virtual void AddExploredMap(int map, byte[] visible)
		{
			lock(this._key)
			{
				var explored = this.ExploredMaps.Where(x => x.Map == map).FirstOrDefault();
				if (explored == null)
				{
					this.ExploredMaps.Add(new MapVisibility(this, map, visible));
					return;
				}

				explored.Visible = visible;
			}
		}

		/// <summary>
		/// Saves account database.
		/// </summary>
		public virtual void Save()
		{
			ChannelServer.Instance.Database.SaveAccount(this);
		}
	}
}
