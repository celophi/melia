using Melia.Channel.World;
using Melia.Shared.Const;
using Melia.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Network.Helpers
{
	public static class CommanderHelper
	{
		public static void AddCommander(this Packet packet, Character commander)
		{
			packet.PutString(commander.Name, 65);
			packet.PutString(commander.TeamName, 64);
			packet.PutEmptyBin(7);
			packet.PutLong(commander.AccountId);
			packet.PutShort(commander.Stance);
			packet.PutShort(0);
			packet.PutShort((short)commander.Job);
			packet.PutByte((byte)commander.Gender);
			packet.PutByte(0);
			packet.PutInt(commander.Stats.Level);

			// Items
			var equipIds = commander.GetEquipIds();
			if (equipIds.Length != Items.EquipSlotCount)
				throw new InvalidOperationException("Incorrect amount of equipment (" + equipIds.Length + ").");

			for (int i = 0; i < equipIds.Length; ++i)
				packet.PutInt(equipIds[i]);

			// [i10671, 2015-10-26 iCBT2] ?
			{
				packet.PutInt(0);
				packet.PutInt(0);
			}

			packet.PutShort(commander.Hair);
			packet.PutShort(0); // Pose
			packet.PutInt(0); // TeamID
			packet.PutInt(0); // Unknown
		}
	}
}
