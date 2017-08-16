using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.World
{
	public class Equipment
	{
		public virtual Character Character { get; protected set; }
		public virtual int ItemId { get; protected set; }
		public virtual int Amount { get; protected set; }
		public virtual int EquipSlot { get; protected set; }
		public virtual int ItemUniqueId { get; protected set; }
		public virtual int Sort { get; protected set; }

		#region NHibernate
		protected Equipment() { }
		#endregion

		public Equipment(Character character, int itemId, int equipSlot)
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
			this.ItemId = itemId;
		}
	}
}
