using FluentNHibernate;
using FluentNHibernate.Mapping;
using Melia.Login.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
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

			HasMany<Character>(Reveal.Member<Account>("_characters"))
				.KeyColumn("accountId")
				.OrderBy("characterId DESC")
				.Cascade.All();
		}
	}
}
