using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Domain
{
	public class Equipment
	{
		public virtual Character Character { get; protected set; }
		public virtual int ItemId { get; protected set; }
		public virtual int Amount { get; protected set; }
		public virtual int EquipSlot { get; protected set; }
		public virtual int ItemUniqueId { get; protected set; }
		public virtual int Sort { get; protected set; }

		protected Equipment() { }
		
		public Equipment(Character character, int itemId, int equipSlot) : this()
		{
			this.Character = character;
			this.ItemId = itemId;
			this.EquipSlot = equipSlot;
			this.Amount = 1;
			this.Sort = 0;
		}

		/// <summary>
		/// Equips an item to a slot
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="equipSlot"></param>
		public virtual void Equip(int itemId)
		{
			if (itemId == 0)
				Log.Error("Error. Attempted to equip an invalid item.");
			this.ItemId = itemId;
		}
	}
}
