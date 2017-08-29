// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Login.Domain;
using Melia.Shared.Const;
using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Network.Helpers
{
	public static class CharacterHelper
	{
		public static void AddAppearancePC(this Packet packet, Character character)
		{
			// Commander
			packet.PutString(character.Name, 65);
			packet.PutString(character.Account.TeamName, 64);
			packet.PutEmptyBin(7);
			packet.PutLong(character.Account.Id);
			packet.PutShort(character.Stance);
			packet.PutShort(0);
			packet.PutShort((short)character.Job);
			packet.PutByte((byte)character.Gender);
			packet.PutByte(0);
			packet.PutInt(character.Stats.Level);
			
			// Equipment
			foreach (var item in character.GetEquipment())
				packet.PutInt(item);

			// [i10671, 2015-10-26 iCBT2] ?
			{
				packet.PutInt(0);
				packet.PutInt(0);
			}

			packet.PutShort(character.Hair);
			packet.PutShort(0); // Pose

			// [i11025 (2016-02-26)] ?
			{
				packet.PutInt(0);
			}

			// End commander

		}
	}
}
