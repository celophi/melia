// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.World;
using Melia.Shared.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Network.Helpers
{
	public static class MonsterHelper
	{
		public static void AddMonster(this Packet packet, Monster monster)
		{
			//if (monster.DialogName == "SIAUL_WEST_MEET_TITAS_AUTO")
			//{
			//	packet.PutBinFromHex(@"32 d4 1b 00 00 00 0c c4 a7 69 82 43 00 00 43 c4 00 00 80 3f 00 00 00 00 02 00 18 00 00 00 18 00 00 00 00 00 00 00 00 00 60 42 3a 4e 00 00 58 02 00 00 18 00 00 00 01 00 00 00 00 00 80 3f 00 00 00 00 37 00 00 00 49 00 00 00 08 00 00 21 00 40 64 69 63 49 44 5f 5e 2a 24 45 54 43 5f 32 30 31 35 30 33 31 37 5f 30 30 39 35 31 37 24 2a 5e 00 01 00 00 01 00 00 1b 00 53 49 41 55 4c 5f 57 45 53 54 5f 4d 45 45 54 5f 54 49 54 41 53 5f 41 55 54 4f 00 01 00 00 aa 18 00 00 00 00 48 43");
			//	return;
			//}

			packet.PutInt(monster.Handle);
			packet.PutFloat(monster.Position.X);
			packet.PutFloat(monster.Position.Y);
			packet.PutFloat(monster.Position.Z);
			packet.PutFloat(monster.Direction.Cos);
			packet.PutFloat(monster.Direction.Sin);
			packet.PutByte((byte)monster.NpcType); // 0~2,  0: friendly?, 1: monster, 2: NPC
			packet.PutByte(0); // bool ?
			packet.PutInt(monster.Hp);
			packet.PutInt(monster.MaxHp);
			packet.PutShort(0);
			packet.PutFloat(0);

			// [i11025 (2016-02-26)] ?
			{
				packet.PutShort(16832);
			}

			// MONSTER
			{
				packet.PutInt(monster.Id);
				packet.PutInt(0);
				packet.PutInt(monster.MaxHp);

				// [i11025 (2016-02-26)] Removed?
				{
					//packet.PutShort(0); // MaxShield?
					//packet.PutEmptyBin(2);
				}

				packet.PutInt(monster.Level);
				packet.PutFloat(monster.SDR);
				packet.PutByte(0);
				packet.PutEmptyBin(3);
			}
			packet.PutInt(0); // GenType
			packet.PutInt(0);

			//packet.PutShort(0); // parameters size
			// it was, like this in IDA o.o
			packet.PutByte(0); // parameters size
			packet.PutByte(0); // ??
			packet.PutByte(0); // v.v;;

			packet.PutLpString(monster.Name);
			packet.PutLpString(""); // UniqueName
			packet.PutLpString(monster.DialogName); // (if string is set - HP isn't shown, and talking activated)
			packet.PutLpString(monster.WarpName);
			packet.PutLpString(""); // str3

			packet.PutEmptyBin(0); // parameters
		}
	}
}
