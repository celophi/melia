using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class AccountMap : ClassMap<Account>
	{
		public AccountMap()
		{
			Table("accounts");
			Id(x => x.Id).Column("accountId");
			Map(x => x.Authority);
			Map(x => x.Name);
			Map(x => x.TeamName);

			HasMany<ChatMacro>(x => x.ChatMacros)
				.KeyColumn("accountId")
				.Cascade.AllDeleteOrphan()
				.Inverse()
				.Not.LazyLoad();

			HasMany<MapVisibility>(x => x.ExploredMaps)
				.KeyColumn("accountId")
				.Cascade.AllDeleteOrphan()
				.Inverse()
				.Not.LazyLoad();
		}
	}
}
