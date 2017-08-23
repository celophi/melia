// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Shared.Const;
using Melia.Shared.Data;
using Melia.Shared.World;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Melia.Login.Domain
{
	public class Character
	{
		private object _key = new object();
		
		public virtual long Id { get; protected set; }

		/// <summary>
		/// Ids of equipped items.
		/// </summary>
		public virtual IList<Equipment> Inventory { get; protected set; }

		/// <summary>
		/// Character's position in barracks.
		/// </summary>
		public virtual Position BarrackPosition { get; protected set; }
		public virtual Position Position { get; protected set; }

		public virtual Account Account { get; protected set; }

		public virtual Stats Stats { get; protected set; }

		public virtual Job Job { get; protected set; }
		public virtual Gender Gender { get; protected set; }

		public virtual int MapId { get; set; }
		public virtual string Name { get; protected set; }
		public virtual byte Hair { get; protected set; }

		/// <summary>
		/// Returns stance, based on job and other factors.
		/// </summary>
		public virtual int Stance
		{
			get
			{
				// The stance is affected by the equipped items, we might
				// have to move this to a place where we have proper access
				// to the character's items, and we need item types.
				// Maybe we can use ItemData on Login, so we don't need
				// another Item class.
				// For the official conditions see stancecondition.ies.

				switch (this.Job)
				{
					default:
					case Job.Swordsman:
						return 10000;

					case Job.Wizard:
						return 10006;

					case Job.Archer:
						return 10008;

					case Job.Cleric:
					case Job.GM:
						return 10004;
				}
			}
		}
		
		protected Character() { }

		/// <summary>
		/// Creates new character.
		/// </summary>
		public Character(Account account, string name, Gender gender, byte hair, JobData jobData, MapData mapData, Position pos) : this()
		{
			this.Account = account;
			this.Job = (Job)jobData.JobId;
			this.MapId = mapData.MapId;
			this.Name = name;
			this.Gender = gender;
			this.Hair = hair;
			this.Position = pos;
			this.Inventory = new List<Equipment>();

			this.Stats = new Stats(this, jobData);
			this.Move(pos);

			for (var i = 0; i < Items.DefaultItems.Length; i++)
			{
				var item = new Equipment(this, Items.DefaultItems[i], i);
				this.Inventory.Add(item);
			}

			this.InitEquipment();
		}

		public virtual void Move(Position pos)
		{
			this.BarrackPosition = pos;
		}

		/// <summary>
		/// hacky method. This should not be done in this class.
		/// </summary>
		/// <returns></returns>
		public virtual byte GetIndex()
		{
			return (byte)(this.Account.GetCharacters().ToList().IndexOf(this) + 1);
		}

		/// <summary>
		/// Initializes equipment for first time creation.
		/// </summary>
		private void InitEquipment()
		{
			var db = LoginServer.Instance.ClientData.ItemDB;
			var oldLightBow = db.First(x => x.Name == "Old Light Bow");
			var oldGladius = db.First(x => x.Name == "Old Gladius");
			var oldWoodenClub = db.First(x => x.Name == "Old Wooden Club");
			var oldShortRod = db.First(x => x.Name == "Old Short Rod");
			var lightPants = db.First(x => x.Name == "Light Pants");
			var lightArmor = db.First(x => x.Name == "Light Armor");

			switch (this.Job)
			{
				case Job.Archer:
					this.Inventory[(int)EquipSlot.LeftHand].Equip(oldLightBow.ItemId);
					this.Inventory[(int)EquipSlot.RightHand].Equip(oldLightBow.ItemId);
					break;
				case Job.Swordsman:
					this.Inventory[(int)EquipSlot.LeftHand].Equip(oldGladius.ItemId);
					break;
				case Job.Cleric:
					this.Inventory[(int)EquipSlot.LeftHand].Equip(oldWoodenClub.ItemId);
					break;
				case Job.Wizard:
					this.Inventory[(int)EquipSlot.LeftHand].Equip(oldShortRod.ItemId);
					break;
				default:
					throw new ArgumentException(string.Format("The job type '{0}' is not valid for this method.", this.Job));
			}

			this.Inventory[(int)EquipSlot.Pants].Equip(lightPants.ItemId);
			this.Inventory[(int)EquipSlot.Top].Equip(lightArmor.ItemId);
		}

		/// <summary>
		/// Returns a characters equipment sorted by equip slot.
		/// </summary>
		/// <returns></returns>
		public virtual IList<int> GetEquipment()
		{
			lock (this._key)
			{
				if (this.Inventory.Count != Items.EquipSlotCount)
					throw new Exception("Error. The character's equipment count is not correct.");

				return this.Inventory
					.OrderBy(x => x.EquipSlot)
					.Select(x => x.ItemId)
					.ToList();
			}
		}
	}
}
