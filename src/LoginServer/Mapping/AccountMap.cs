using FluentNHibernate;
using FluentNHibernate.Mapping;
using Melia.Login.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Mapping
{
	public class AccountMap : ClassMap<Account>
	{
		public AccountMap()
		{
			Table("accounts");
			Id(x => x.Id).Column("accountId");
			Map(x => x.Name);
			Map(x => x.Password);
			Map(x => x.TeamName);

			Component(x => x.Money, y =>
			{
				y.Map(p => p.Medal);
				y.Map(p => p.GiftMedal);
				y.Map(p => p.PremiumMedal);
			});

			HasMany<Character>(Reveal.Member<Account>("_characters"))
				.KeyColumn("accountId")
				.OrderBy("characterId ASC")
				.Cascade.AllDeleteOrphan()
				.Inverse()
				.Not.LazyLoad();
		}
	}
}
