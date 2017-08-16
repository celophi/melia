// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Shared.Const;
using Melia.Shared.Data.Database;
using Melia.Shared.Network.Helpers;
using Melia.Shared.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.World
{
	public class Character
	{
		public virtual long Id { get; protected set; }

		/// <summary>
		/// Index of character in character list.
		/// </summary>
		public virtual byte Index { get; set; }

		/// <summary>
		/// Ids of equipped items.
		/// </summary>
		public virtual IList<Equipment> Equipment { get; protected set; }

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
				var cls = this.Job.ToClass();

				// The stance is affected by the equipped items, we might
				// have to move this to a place where we have proper access
				// to the character's items, and we need item types.
				// Maybe we can use ItemData on Login, so we don't need
				// another Item class.
				// For the official conditions see stancecondition.ies.

				switch (cls)
				{
					default:
					case Class.Swordsman:
						return 10000;

					case Class.Wizard:
						return 10006;

					case Class.Archer:
						return 10008;

					case Class.Cleric:
					case Class.GM:
						return 10004;
				}
			}
		}
		
		protected Character() { }

		/// <summary>
		/// Creates new character.
		/// </summary>
		public static Character New(Account account, string name, Gender gender, byte hair, JobData jobData, MapData mapData, Position pos)
		{
			var character = new Character
			{
				Account = account,
				Job = (Job)jobData.Id,
				MapId = mapData.Id,
				Name = name,
				Gender = gender,
				Hair = hair,
				Position = pos,
				Equipment = new List<Equipment>()
			};

			character.Stats = new Stats(character, jobData);
			character.Move(pos);

			for (var i = 0; i < Items.DefaultItems.Length; i++)
			{
				var item = new Equipment(character, Items.DefaultItems[i], i);
				character.Equipment.Add(item);
			}

			character.InitEquipment();
			return character;
		}

		public virtual void Move(Position pos)
		{
			this.BarrackPosition = pos;
		}

		/// <summary>
		/// Initializes equipment for first time creation.
		/// </summary>
		private void InitEquipment()
		{
			// TODO: This belongs in a constructor (complicated with data persistence).
			switch (this.Job)
			{
				case Job.Archer:
					this.Equipment[(int)EquipSlot.LeftHand].Equip(161101);
					this.Equipment[(int)EquipSlot.RightHand].Equip(161101);
					break;
				case Job.Swordsman:
					this.Equipment[(int)EquipSlot.LeftHand].Equip(101101);
					break;
				case Job.Cleric:
					this.Equipment[(int)EquipSlot.LeftHand].Equip(201101);
					break;
				case Job.Wizard:
					this.Equipment[(int)EquipSlot.LeftHand].Equip(141101);
					break;
				default:
					throw new ArgumentException(string.Format("The job type '{0}' is not valid for this method.", this.Job));
			}

			this.Equipment[(int)EquipSlot.Pants].Equip(521101);
			this.Equipment[(int)EquipSlot.Top].Equip(531101);
		}

		/// <summary>
		/// Returns ids of equipped items.
		/// </summary>
		/// <returns></returns>
		public virtual int[] GetEquipIds()
		{
			return this.Equipment
				.OrderBy(x => x.EquipSlot)
				.Select(x => x.ItemId)
				.ToArray();
		}
	}
}
