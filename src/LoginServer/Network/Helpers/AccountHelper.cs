﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Login.Domain;
using Melia.Shared.Const;
using Melia.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Network.Helpers
{
	public static class AccountHelper
	{
		/// <summary>
		/// Writes account's properties to packet.
		/// </summary>
		/// <param name="packet"></param>
		/// <param name="account"></param>
		public static void AddAccountProperties(this Packet packet, Account account)
		{
			packet.PutShort(43); // Account properties size
			packet.PutShort(100); // ServerGroupID (this is the GROUPID in the web server serverlist.xml)
			
			// Free TP
			packet.PutInt(ObjectProperty.Account["Medal"]);
			packet.PutFloat(account.Money.Medal);

			// Date string to start counting from for Free TP? Ex: 201708518025941
			packet.PutInt(ObjectProperty.Account["Medal_Get_Date"]);
			packet.PutShort(5); // length of the next string
			packet.PutString("None");
			
			//Event TP
			packet.PutInt(ObjectProperty.Account["GiftMedal"]);
			packet.PutFloat(account.Money.GiftMedal);

			// TP
			packet.PutInt(ObjectProperty.Account["PremiumMedal"]);
			packet.PutFloat(account.Money.PremiumMedal);

			packet.PutInt(ObjectProperty.Account["SelectedBarrack"]);
			packet.PutFloat(account.SelectedBarrack);
		}
	}
}
