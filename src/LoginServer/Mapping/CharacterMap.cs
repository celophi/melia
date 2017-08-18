using FluentNHibernate;
using FluentNHibernate.Mapping;
using Melia.Login.Database;
using Melia.Login.Domain;
using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Mapping
{
	public class CharacterMap : ClassMap<Character>
	{
		public CharacterMap()
		{
			Table("characters");
			Id(x => x.Id).Column("characterId");
			Map(x => x.Name);
			Map(x => x.MapId).Column("zone");
			Map(x => x.Job).CustomType<Job>();
			Map(x => x.Gender).CustomType<Gender>();
			Map(x => x.Hair);
			References<Account>(x => x.Account, "accountId");

			Component(x => x.BarrackPosition, y =>
			{
				y.Map(p => p.X).Column("bx");
				y.Map(p => p.Y).Column("`by`");
				y.Map(p => p.Z).Column("bz");
			});

			Component(x => x.Position, y =>
			{
				y.Map(p => p.X);
				y.Map(p => p.Y);
				y.Map(p => p.Z);
			});

			Component(x => x.Stats, y =>
			{
				y.Map(p => p.MaxHP);
				y.Map(p => p.MaxSP);
				y.Map(p => p.MaxStamina);
				y.Map(p => p.STR);
				y.Map(p => p.CON);
				y.Map(p => p.INT).Column("`Int`");
				y.Map(p => p.SPR);
				y.Map(p => p.DEX);
				y.Map(p => p.Level);
			});

			HasMany<Equipment>(x => x.Inventory)
				.KeyColumn("characterId")
				.Where(x => x.EquipSlot < Items.EquipSlotCount)
				.OrderBy("equipSlot ASC")
				.Cascade.AllDeleteOrphan()
				.Inverse()
				.Not.LazyLoad();
		}
	}
}
