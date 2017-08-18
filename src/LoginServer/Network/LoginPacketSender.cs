// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Login.Domain;
using Melia.Login.Network.Helpers;
using Melia.Shared.Const;
using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Network
{
	public static class Send
	{
		/// <summary>
		/// Sends the number of the new character's index.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="character"></param>
		public static void BC_COMMANDER_CREATE_SLOTID(LoginConnection conn, Character character)
		{
			var packet = new Packet(Op.BC_COMMANDER_CREATE_SLOTID);
			var characterCount = (byte)conn.Account.GetCharacters().Count;

			packet.PutByte(characterCount);
			conn.Send(packet);
		}

		/// <summary>
		/// Sent to the client stating that the login was successful.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_LOGINOK(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_LOGINOK);
			packet.PutShort(0);
			packet.PutLong(conn.Account.Id);
			packet.PutString(conn.Account.Name, 33);
			packet.PutInt(3); // accountPrivileges? <= 3 enables a kind of debug context menu
			packet.PutString(conn.SessionKey, 64);
			packet.PutInt(4475); // [i10725 (2015-11-03)] ?
			packet.PutInt(9239); // unk
			packet.PutInt(67213); // unk

			conn.Send(packet);
		}

		/// <summary>
		/// Tells the client that the server successfully received the login packet.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_LOGIN_PACKET_RECEIVED(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_LOGIN_PACKET_RECEIVED);

			conn.Send(packet);
		}

		/// <summary>
		/// Sent to the client when logging out.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_LOGOUTOK(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_LOGOUTOK);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends a list of characters to the client and account properties.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_COMMANDER_LIST(LoginConnection conn)
		{
			var characters = conn.Account.GetCharacters();

			var packet = new Packet(Op.BC_COMMANDER_LIST);
			packet.PutLong(conn.Account.Id);
			packet.PutByte(0);
			packet.PutByte((byte)characters.Count);
			packet.PutString(conn.Account.TeamName, 64);

			packet.AddAccountProperties(conn.Account);

			foreach (var character in characters)
			{
				packet.AddCharacter(character);

				// Equip properties, short->length
				for (int i = 0; i < Items.EquipSlotCount; ++i)
					packet.PutShort(0);

				packet.PutByte(1);
				packet.PutByte(1);
				packet.PutByte(1);

				// Job history?
				// While this short existed in iCBT1, it might not have
				// been used, couldn't find a log.
				// Example: A Mage that switched to Pyromancer has two
				//   elements in this list, 2001 and 2002.
				packet.PutShort(0); // count
									// loop
									//   short jobId

				// [i11025 (2016-02-26)] ?
				{
					packet.PutInt(0);
				}
			}

			// Null terminated list of some kind?
			// Example of != 0: 02 00 | 0B 00 00 00 01 00, 0C 00 00 00 00 00
			packet.PutShort(0); // count?

			packet.PutShort(0); // unk
			packet.PutInt(conn.Account.GetCharacters().Count()); // unk
			packet.PutShort(conn.Account.GetCharacters().Count()); // unk

			conn.Send(packet);
		}

		/// <summary>
		/// Sends a newly created character to the client.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="character"></param>
		public static void BC_COMMANDER_CREATE(LoginConnection conn, Character character)
		{
			var packet = new Packet(Op.BC_COMMANDER_CREATE);
			packet.AddCharacter(character);

			conn.Send(packet);
		}

		/// <summary>
		/// Informs the client that a character has been destroyed.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="index"></param>
		public static void BC_COMMANDER_DESTROY(LoginConnection conn, byte index)
		{
			var packet = new Packet(Op.BC_COMMANDER_DESTROY);
			packet.PutByte(index);

			conn.Send(packet);
		}

		/// <summary>
		/// Instructs the client that it may continue with starting the game.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="character"></param>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		public static void BC_START_GAMEOK(LoginConnection conn, Character character, string ip, int port)
		{
			var packet = new Packet(Op.BC_START_GAMEOK);

			packet.PutInt(0);
			packet.PutInt(IPAddress.Parse(ip).ToInt32());
			packet.PutInt(port);
			packet.PutInt(character.MapId);
			packet.PutByte(0);
			packet.PutLong(character.Id);
			packet.PutByte(0); // Only connects if 0
			packet.PutByte(1); // Passed to a function if ^ is 0

			// Force FNH to treat data as dirty since the channel server will handle it.
			using (var session = SessionFactory.OpenSession())
			{
				session.Clear();
			}

			conn.Send(packet);
		}

		/// <summary>
		/// Sends a changed team name to the client.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="result"></param>
		public static void BC_BARRACKNAME_CHANGE(LoginConnection conn, TeamNameChangeResult result)
		{
			var packet = new Packet(Op.BC_BARRACKNAME_CHANGE);
			packet.PutByte(result == TeamNameChangeResult.Okay);
			packet.PutInt((int)result);
			packet.PutString(conn.Account.TeamName, 64);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends a generic message dialog to the client.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="msgType"></param>
		public static void BC_MESSAGE(LoginConnection conn, MsgType msgType)
		{
			var packet = new Packet(Op.BC_MESSAGE);
			packet.PutByte((byte)msgType);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends a custom message dialog to the client.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="msg"></param>
		public static void BC_MESSAGE(LoginConnection conn, string msg)
		{
			var packet = new Packet(Op.BC_MESSAGE);
			packet.PutByte((byte)MsgType.Text);
			packet.PutEmptyBin(40);
			packet.PutString(msg);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends account properties to the client.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="account"></param>
		public static void BC_ACCOUNT_PROP(LoginConnection conn, Account account)
		{
			var packet = new Packet(Op.BC_ACCOUNT_PROP);

			packet.PutLong(account.Id);
			packet.AddAccountProperties(account);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends information related to the team to be displayed in the barrack.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_NORMAL_TeamUI(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_NORMAL);
			packet.PutInt(0x0B); // SubOp

			packet.PutLong(conn.Account.Id);

			// Maximum number of allowed characters added to the default of (4).
			packet.PutShort(2);

			// Team experience? Displayed under "Team Info"
			packet.PutInt(0);

			// Sum of characters and pets.
			var characters = conn.Account.GetCharacters();
			packet.PutShort(characters.Count);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends zone traffic to the client.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_NORMAL_ZoneTraffic(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_NORMAL);
			packet.PutInt(0x0C); //SubOp

			var characters = conn.Account.GetCharacters();
			var mapAvailableCount = characters.Count;
			var zoneServerCount = 1;
			var zoneMaxPcCount = 150;

			packet.BeginZlib();
			packet.PutShort(zoneMaxPcCount);
			packet.PutShort(mapAvailableCount);
			for (var i = 0; i < mapAvailableCount; ++i)
			{
				packet.PutShort(characters[i].MapId);
				packet.PutShort(zoneServerCount);
				for (var zone = 0; zone < zoneServerCount; ++zone)
				{
					packet.PutShort(zone);
					packet.PutShort(1); // currentPlayersCount
				}
			}
			packet.EndZlib();

			conn.Send(packet);
		}

		/// <summary>
		/// Runs a lua function.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="str"></param>
		public static void BC_NORMAL_Run(LoginConnection conn, string str)
		{
			var packet = new Packet(Op.BC_NORMAL);
			packet.PutInt(0x0F); // SubOp
			packet.PutLpString(str);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends the session key to the client.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_NORMAL_SetSessionKey(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_NORMAL);
			packet.PutInt(0x14);
			packet.PutLpString(conn.SessionKey);

			conn.Send(packet);
		}

		/// <summary>
		/// Sends the cost of a character slot to the client.
		/// </summary>
		/// <param name="conn"></param>
		public static void BC_REQ_SLOT_PRICE(LoginConnection conn)
		{
			var packet = new Packet(Op.BC_REQ_SLOT_PRICE);
			packet.PutInt(50); // move this into database

			conn.Send(packet);
		}

		/// <summary>
		/// Instructs the client to move the user to the barrack server.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="ip1"></param>
		/// <param name="port1"></param>
		/// <param name="ip2"></param>
		/// <param name="port2"></param>
		public static void BC_SERVER_ENTRY(LoginConnection conn, string ip1, int port1, string ip2, int port2)
		{
			var packet = new Packet(Op.BC_SERVER_ENTRY);

			packet.PutInt(IPAddress.Parse(ip1).ToInt32());
			packet.PutInt(IPAddress.Parse(ip2).ToInt32());
			packet.PutShort(port1);
			packet.PutShort(port2);

			conn.Send(packet);
		}
	}
}
