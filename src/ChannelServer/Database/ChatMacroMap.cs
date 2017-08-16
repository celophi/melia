using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class ChatMacroMap : ClassMap<ChatMacro>
	{
		public ChatMacroMap()
		{
			Table("ChatMacro");
			Id(x => x.Id);
			Map(x => x.Message);
			Map(x => x.Pose);
			Map(x => x.Slot).UniqueKey("UQ_ChatMacro_Slot");
			References(x => x.Account, "accountId").UniqueKey("UQ_ChatMacro_Slot");
		}
	}
}
