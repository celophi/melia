using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class MapVisibililtyMap : ClassMap<MapVisibility>
	{
		public MapVisibililtyMap()
		{
			Table("MapVisibility");
			Id(x => x.Id);
			Map(x => x.Map);
			Map(x => x.Percentage);
			Map(x => x.Visible).Column("explored").UniqueKey("UQ_MapVisibility_Map");
			References(x => x.Account).Column("accountId");
		}
	}
}
