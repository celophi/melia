using Melia.Channel.Database;
using Melia.Shared.Const;
using Melia.Shared.Network;
using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Network.Helpers
{
	// Merge this with the account helper in the login server project.
	public static class AccountHelper
	{
		/// <summary>
		/// Writes account's properties to packet.
		/// </summary>
		/// <param name="packet"></param>
		/// <param name="account"></param>
		public static void AddAccountProperties(this Packet packet, Account account)
		{
			var length = account.ExploredMaps.Count * 8;
			length += 43;

			packet.PutShort(length); // Account properties size

			// Free TP
			packet.PutInt(ObjectProperty.Account["Medal"]);
			packet.PutFloat(account.Medals);

			packet.PutInt(ObjectProperty.Account["Medal_Get_Date"]);

			packet.PutShort(5); // length of the next string
			packet.PutString("None");

			//Event TP
			packet.PutInt(ObjectProperty.Account["GiftMedal"]);
			packet.PutFloat(10);

			// TP
			packet.PutInt(ObjectProperty.Account["PremiumMedal"]);
			packet.PutFloat(0);

			packet.PutInt(ObjectProperty.Account["SelectedBarrack"]);
			packet.PutFloat(account.SelectedBarrack);

			foreach (var pair in account.ExploredMaps)
			{
				var id = ObjectProperty.Account["HadVisited_" + pair.Map];
				packet.PutInt(id);
				packet.PutFloat(1);
			}
		}
	}
}
