using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.World
{
	public class EquipmentMap : ClassMap<Equipment>
	{
		public EquipmentMap()
		{
			Table("items");
			Id(x => x.ItemUniqueId);
			Map(x => x.ItemId);
			Map(x => x.Amount);
			Map(x => x.EquipSlot);
			Map(x => x.Sort);
			References<Character>(x => x.Character, "characterId");
		}
	}
}
