using FluentNHibernate.Mapping;
using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.World
{
	public class CharacterMap : ClassMap<Character>
	{
		public CharacterMap()
		{
			Table("Characters");
			Id(x => x.Id).Column("characterId");
			Map(x => x.AccountId);
			Map(x => x.Name);
			Map(x => x.MapId).Column("zone");
			Map(x => x.Job).CustomType<Job>();
			Map(x => x.Gender).CustomType<Gender>();
			Map(x => x.Hair);
			Map(x => x.UsedStat);
			Map(x => x.StatByBonus);
			Map(x => x.StatByLevel);

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
				y.Map(p => p.HP);
				y.Map(p => p.SP);
				y.Map(p => p.Stamina);
				y.Map(p => p.Exp);
				y.Map(p => p.MaxExp);
			});
		}
	}
}
