using FluentNHibernate.Mapping;
using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.World
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
			Map(x => x.Level);
			Map(x => x.MaxHp);
			Map(x => x.MaxSp);
			Map(x => x.MaxStamina);
			Map(x => x.Str);
			Map(x => x.Con);
			Map(x => x.Int).Column("`Int`");
			Map(x => x.Spr);
			Map(x => x.Dex);

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

			HasMany(x => x.Equipment)
				.Table("items")
				.Element("itemId")
				.OrderBy("equipSlot DESC")
				.KeyColumn("characterId");
		}
	}
}
