// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Login.World;
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
		public static void AddCharacter(this Packet packet, Character character)
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

			// Items
			var equipIds = character.GetEquipIds();
			if (equipIds.Length != Items.EquipSlotCount)
				throw new InvalidOperationException("Incorrect amount of equipment (" + equipIds.Length + ").");

			for (int i = 0; i < equipIds.Length; ++i)
				packet.PutInt(equipIds[i]);

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

			packet.PutLong(character.Id);

			// [i11025 (2016-02-26)]
			// Index was previously stored as a short, now there seem
			// to be two byte, with the first being the index.
			{
				packet.PutByte(character.Index);
				packet.PutByte(181);
			}

			packet.PutShort(character.MapId);
			packet.PutInt(0);
			packet.PutInt(0);
			packet.PutInt(0); // maxXP ?
			packet.PutInt(0);

			// Position?
			packet.PutFloat(character.BarrackPosition.X);
			packet.PutFloat(character.BarrackPosition.Y);
			packet.PutFloat(character.BarrackPosition.Z);
			packet.PutFloat(0);	// Vector direction
			packet.PutFloat(0); // Vector direction

			// ?
			packet.PutFloat(character.BarrackPosition.X);
			packet.PutFloat(character.BarrackPosition.Y);
			packet.PutFloat(character.BarrackPosition.Z);
			packet.PutFloat(0); // Vector direction
			packet.PutFloat(0); // Vector direction

			packet.PutInt(0);
		}
	}
}
