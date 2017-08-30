// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Database;
using Melia.Login.Domain;
using Melia.Shared.Const;
using Melia.Shared.Database;
using Melia.Shared.Network;
using Melia.Shared.Util;
using Melia.Shared.Util.Security;
using Melia.Shared.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Melia.Login.Network
{
	public class LoginPacketHandler : PacketHandler<LoginConnection>
	{
		public static readonly LoginPacketHandler Instance = new LoginPacketHandler();

		/// <summary>
		/// Sent when clicking [Enter] on login screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_LOGIN)]
		public void CB_LOGIN(LoginConnection conn, Packet packet)
		{
			var accountName = packet.GetString(33);
			var password = packet.GetBinAsHex(16); // MD5? I'm disappointed, IMC =|
			var unkByte1 = packet.GetByte();
			var unkByte2 = packet.GetByte();
			var unkByte3 = packet.GetByte(); // [i10671 (2015-10-26)] ?
			var ip = packet.GetInt();
			var unkInt4 = packet.GetInt();
			var unkInt5 = packet.GetInt();
			var sysLocale = packet.GetShort(); // system locale (ex. en_US)

			Send.BC_LOGIN_PACKET_RECEIVED(conn);

			Account account = null;

			// Create new account
			if (accountName.StartsWith("new__") || accountName.StartsWith("new//"))
			{
				accountName = accountName.Substring("new__".Length);
				if (!LoginServer.Instance.Database.AccountExists(accountName))
				{
					account = new Account(accountName, password);
					LoginServer.Instance.Database.SaveAccount(account);
				}

			}

			account = LoginServer.Instance.Database.GetAccount(accountName);
			if (account == null)
			{
				Send.BC_MESSAGE(conn, MsgType.UsernameOrPasswordIncorrect1);
				conn.Close();
				return;
			}

			// Check password
			if (!BCrypt.CheckPassword(password, account.Password))
			{
				Send.BC_MESSAGE(conn, MsgType.UsernameOrPasswordIncorrect2);
				conn.Close();
				return;
			}

			// Logged in
			conn.Account = account;
			conn.LoggedIn = true;

			Log.Info("User '{0}' logged in.", conn.Account.Name);

			Send.BC_LOGINOK(conn);
		}

		/// <summary>
		/// Sent when clicking [Enter] on login screen if no login mask
		/// is used.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_LOGIN_BY_PASSPORT)]
		public void CB_LOGIN_BY_PASSPORT(LoginConnection conn, Packet packet)
		{
			Send.BC_MESSAGE(conn, "Passport login not supported.");
			conn.Close();
		}

		/// <summary>
		/// Sent when clicking [Logout] on barrack screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_LOGOUT)]
		public void CB_LOGOUT(LoginConnection conn, Packet packet)
		{
			Log.Info("User '{0}' is logging out.", conn.Account.Name);

			// Client closes connection without this as well, but it waits a
			// few seconds to do so.
			Send.BC_LOGOUTOK(conn);
		}

		/// <summary>
		/// Sent upon logging in.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_START_BARRACK)]
		public void CB_START_BARRACK(LoginConnection conn, Packet packet)
		{
			var unkByte = packet.GetByte();

			var ip = Settings.Default.BarrackServerIP;
			int port = Int32.Parse(Settings.Default.BarrackServerPort);

			Send.BC_SERVER_ENTRY(conn, ip, port, ip, port);
			Send.BC_NORMAL_SelectedBarrack(conn);
			Send.BC_COMMANDER_LIST(conn);
			Send.BC_NORMAL_ZoneTraffic(conn);
			Send.BC_NORMAL_TeamUI(conn);
		}

		/// <summary>
		/// Sent when clicking [Create Character] on char creation screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_COMMANDER_CREATE)]
		public void CB_COMMANDER_CREATE(LoginConnection conn, Packet packet)
		{
			var charPosition = packet.GetByte();
			var name = packet.GetString(65);
			var job = (Job)packet.GetShort();
			var gender = (Gender)packet.GetByte();
			var bx = packet.GetFloat();
			var by = packet.GetFloat();
			var bz = packet.GetFloat();
			var hair = packet.GetByte();


			if (conn.Account.GetCharacterByName(name) != null)
			{
				Send.BC_MESSAGE(conn, MsgType.CannotCreateCharacter);
				return;
			}

			var startingCity = StartingCity.Klaipeda;

			// Check starting city
			if (!Enum.IsDefined(typeof(StartingCity), startingCity))
			{
				Log.Warning("CB_COMMANDER_CREATE: User '{0}' tried to create character in invalid starting city '{1}'.", conn.Account.Name, startingCity);
				Send.BC_MESSAGE(conn, MsgType.CreateCharFail);
				return;
			}

			// Check job
			if (job != Job.Swordsman && job != Job.Wizard && job != Job.Archer && job != Job.Cleric)
			{
				Log.Warning("CB_COMMANDER_CREATE: User '{0}' tried to create character with invalid job '{1}'.", conn.Account.Name, job);
				conn.Close();
				return;
			}

			// Check gender
			if (gender < Gender.Male || gender > Gender.Female)
			{
				Log.Warning("CB_COMMANDER_CREATE: User '{0}' tried to create character with invalid gender '{1}'.", conn.Account.Name, gender);
				conn.Close();
				return;
			}

			// Check name
			if (LoginServer.Instance.Database.CharacterExists(conn.Account.Id, name))
			{
				Send.BC_MESSAGE(conn, MsgType.NameAlreadyExists);
				return;
			}

			// Get job data
			var jobData = LoginServer.Instance.ClientData.JobDB.FirstOrDefault(x => x.JobId == (int)job);
			if (jobData == null)
			{
				Log.Error("CB_COMMANDER_CREATE: Job '{0}' not found.", job);
				Send.BC_MESSAGE(conn, MsgType.CannotCreateCharacter);
				return;
			}

			// Get start city data
			var startingCityData = LoginServer.Instance.ClientData.StartingCityDB.FirstOrDefault(x => x.StartingCityId == startingCity);
			if (startingCityData == null)
			{
				Log.Error("CB_COMMANDER_CREATE: StartingCity Id '{0}' not found.", startingCity);
				Send.BC_MESSAGE(conn, MsgType.CannotCreateCharacter);
				return;
			}

			// Get map data
			var mapData = LoginServer.Instance.ClientData.MapDB.FirstOrDefault(x => x.ClassName == startingCityData.Map);
			if (mapData == null)
			{
				Log.Error("CB_COMMANDER_CREATE: Map '{0}' not found.", startingCityData.Map);
				Send.BC_MESSAGE(conn, MsgType.CannotCreateCharacter);
				return;
			}

			var pos = new Position(startingCityData.X, startingCityData.Y, startingCityData.Z);
			var character = conn.Account.CreateCharacter(name, gender, hair, jobData, mapData, pos);

			// persist the new character so that the ID may be sent to the client.
			LoginServer.Instance.Database.SaveAccount(conn.Account);

			Send.BC_COMMANDER_CREATE_SLOTID(conn, character);
			Send.BC_COMMANDER_CREATE(conn, character);
		}

		/// <summary>
		/// Sent when deleting a character.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_COMMANDER_DESTROY)]
		public void CB_COMMANDER_DESTROY(LoginConnection conn, Packet packet)
		{
			var characterId = packet.GetLong();

			var character = conn.Account.GetCharacterById(characterId);
			if (character == null)
			{
				Log.Warning("CB_COMMANDER_DESTROY: User '{0}' tried to delete a character he doesn't have ({1}).", conn.Account.Name, characterId);
				Send.BC_MESSAGE(conn, MsgType.CannotDeleteCharacter1);
				return;
			}

			var index = conn.Account.DeleteCharacter(character);

			LoginServer.Instance.Database.SaveAccount(conn.Account);
			Send.BC_COMMANDER_DESTROY(conn, index);
			Send.BC_NORMAL_TeamUI(conn);
		}

		/// <summary>
		/// Sent upon login, contains checksum of client files?
		/// </summary>
		[PacketHandler(Op.CB_CHECK_CLIENT_INTEGRITY)]
		public void CB_CHECK_CLIENT_INTEGRITY(LoginConnection conn, Packet packet)
		{
			var checksum = packet.GetString(64);

			// Ignore for now.
			// TODO: Add option for accepted checksums.
		}

		/// <summary>
		/// Sent when clicking [Start Game], to connect to the selected channel.
		/// </summary>
		[PacketHandler(Op.CB_START_GAME)]
		public void CB_START_GAME(LoginConnection conn, Packet packet)
		{
			var channel = packet.GetShort();
			var index = packet.GetByte();

			// Get character
			var character = conn.Account.GetCharacterByIndex(index);
			if (character == null)
			{
				Log.Warning("CB_START_GAME: User '{0}' tried log in with an invalid character ({1}).", conn.Account.Name, index);
				return;
			}

			Send.BC_START_GAMEOK(conn, character);
		}

		/// <summary>
		/// Sent when saving Team Name in Lodge Settings on barrack screen.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_BARRACKNAME_CHANGE)]
		public void CB_BARRACKNAME_CHANGE(LoginConnection conn, Packet packet)
		{
			var name = packet.GetString(64);

			if (!conn.Account.IsTeamNameValid(name))
			{
				Send.BC_BARRACKNAME_CHANGE(conn, TeamNameChangeResult.TeamChangeFailed);
				return;
			}

			var exists = LoginServer.Instance.Database.TeamNameExists(name);
			if (exists)
			{
				Send.BC_BARRACKNAME_CHANGE(conn, TeamNameChangeResult.TeamNameAlreadyExist);
				return;
			}

			if (String.IsNullOrEmpty(conn.Account.TeamName))
			{
				conn.Account.AssignTeamName(name);
				Send.BC_BARRACKNAME_CHANGE(conn, TeamNameChangeResult.Okay);
			}
			else
			{
				conn.Account.PurchaseTeamNameChange(name, 150);
				Send.BC_BARRACKNAME_CHANGE(conn, TeamNameChangeResult.Okay);
				Send.BC_ACCOUNT_PROP(conn, conn.Account);
				Send.BC_NORMAL_Run(conn, BCNormalMsg.THEMA_BUY_SUCCESS);
			}

			LoginServer.Instance.Database.SaveAccount(conn.Account);
		}

		/// <summary>
		/// Updates the character's position in the barrack.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_COMMANDER_MOVE)]
		public void CB_COMMANDER_MOVE(LoginConnection conn, Packet packet)
		{
			var index = packet.GetByte();
			var x = packet.GetFloat();
			var y = packet.GetFloat();
			var z = packet.GetFloat();
			var d1 = packet.GetFloat(); // ?
			var d2 = packet.GetFloat(); // ?

			// Weird byte sent when a new character is created.
			if (index == 0xFF)
				return;

			// Get character
			var character = conn.Account.GetCharacterByIndex(index);
			if (character == null)
			{
				Log.Warning("CB_COMMANDER_MOVE: User '{0}' tried to move invalid character ({1}).", conn.Account.Name, index);
				return;
			}

			var pos = new Position(x, y, z);
			character.Move(pos);
			Send.BC_NORMAL_SetPosition(conn, index, pos);
		}

		/// <summary>
		/// Sent when the client wants an update on zone traffic.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_REQ_CHANNEL_TRAFFIC)]
		public void CB_REQ_CHANNEL_TRAFFIC(LoginConnection conn, Packet packet)
		{
			Send.BC_NORMAL_ZoneTraffic(conn);
		}

		/// <summary>
		/// Sent when clicking [Purchase] on a barrack.
		/// </summary>
		[PacketHandler(Op.CB_BUY_THEMA)]
		public void CB_BUY_THEMA(LoginConnection conn, Packet packet)
		{
			var unkInt = packet.GetInt();
			var newMapId = packet.GetInt();
			var oldMapId = packet.GetInt();

			// Get barrack
			var mapData = LoginServer.Instance.ClientData.MapDB.FirstOrDefault(x => x.MapId == newMapId);
			if (mapData == null)
				return;

			var barrackData = LoginServer.Instance.ClientData.BarrackDB.FirstOrDefault(x => x.ClassName == mapData.ClassName);
			if (barrackData == null)
				return;

			if (!conn.Account.Money.CanAfford(barrackData.Price))
			{
				Log.Warning("CB_BUY_THEMA: User '{0}' tried to buy barrack without having the necessary coins.");
				return;
			}

			conn.Account.PurchaseBarrack(newMapId, barrackData.Price);

			Send.BC_ACCOUNT_PROP(conn, conn.Account);
			Send.BC_NORMAL_Run(conn, BCNormalMsg.THEMA_BUY_SUCCESS);
		}

		/// <summary>
		/// Send upon login, purpose unknown.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_CURRENT_BARRACK)]
		public void CB_CURRENT_BARRACK(LoginConnection conn, Packet packet)
		{
			var accountId = packet.GetLong();
		}

		/// <summary>
		/// Sent when the client attempts to purchase an additional character slot.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_REQ_SLOT_PRICE)]
		public void CB_REQ_SLOT_PRICE(LoginConnection conn, Packet packet)
		{
			Send.BC_REQ_SLOT_PRICE(conn);
		}

		[PacketHandler(Op.CB_CHANGE_BARRACK_LAYER)]
		public void CB_CHANGE_BARRACK_LAYER(LoginConnection conn, Packet packet)
		{
			var classId = packet.GetLong();
			var unused = packet.GetInt();


		}

		/// <summary>
		/// Sent when the user clicks the barrack number.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_SELECT_BARRACK_LAYER)]
		public void CB_SELECT_BARRACK_LAYER(LoginConnection conn, Packet packet)
		{
			var layer = packet.GetInt();

			conn.Account.SetCurrentBarrackLayer(layer);
			Send.BC_COMMANDER_LIST(conn, conn.Account.SelectedBarrackLayer);
		}

		/// <summary>
		/// Pets!
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_PET_PC)]
		public void CB_PET_PC(LoginConnection conn, Packet packet)
		{
			var petGuid = packet.GetLong();
			var characterId = packet.GetLong();
		}

		/// <summary>
		/// Represents a list of addons that are not allowed.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="packet"></param>
		[PacketHandler(Op.CB_NOT_AUTHORIZED_ADDON_LIST)]
		public void CB_NOT_AUTHORIZED_ADDON_LIST(LoginConnection conn, Packet packet)
		{
			var count = packet.GetInt();
			var addonNames = packet.GetString();
		}
	}
}
