// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.Network;
using Melia.Channel.Scripting;
using Melia.Shared.Const;
using Melia.Shared.Network;
using Melia.Shared.Network.Helpers;
using Melia.Shared.Util;
using Melia.Shared.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.World
{
	public class Character : Shared.World.BaseCharacter, IEntity
	{
		private bool _warping;

		private object _lookAroundLock = new object();
		private Monster[] _visibleMonsters = new Monster[0];
		private Character[] _visibleCharacters = new Character[0];

		/// <summary>
		/// Connection this character uses.
		/// </summary>
		public virtual ChannelConnection Connection { get; set; }

		/// <summary>
		/// Index in world collection?
		/// </summary>
		public virtual int Handle { get; set; }

		private Map _map = Map.Limbo;
		/// <summary>
		/// The map the character is currently on.
		/// </summary>
		/// <remarks>
		/// Since every map change includes a reconnect, the map reference
		/// will only ever be set once, upon connection.
		/// </remarks>
		public virtual Map Map { get { return _map; } set { _map = value ?? Map.Limbo; } }

		/// <summary>
		/// Gets or sets whether the character is moving.
		/// </summary>
		public virtual bool IsMoving { get; set; }

		public virtual int Hp { get { return this.Stats.HP; } protected set { } }

		/// <summary>
		/// Gets or sets whether the character is sitting.
		/// </summary>
		public virtual bool IsSitting { get; set; }

		/// <summary>
		/// Gets or sets whether the character is standing on the ground.
		/// </summary>
		public virtual bool IsGrounded { get; set; }

		/// <summary>
		/// Holds the order of successive changes in character HP.
		/// A higher value indicates the latest damage taken.
		/// I'm not sure when this gets rolled over.
		/// </summary>
		public virtual int HPChangeCounter { get; set; } = 0;

		/// <summary>
		/// The character's inventory.
		/// </summary>
		public virtual Inventory Inventory { get; protected set; }

		/// <summary>
		/// Returns combined weight of all items the character is currently carrying.
		/// </summary>
		public virtual float NowWeight { get { return this.Inventory.GetNowWeight(); } }

		/// <summary>
		/// Stat points.
		/// </summary>
		public virtual float StatPoints { get { return (this.StatByLevel + this.StatByBonus - this.UsedStat); } }

		/// <summary>
		/// Stat points acquired by leveling?
		/// </summary>
		public virtual float StatByLevel { get; set; }

		/// <summary>
		/// Bonus stat points?
		/// </summary>
		public virtual float StatByBonus { get; set; }

		/// <summary>
		/// Amount of stat points spent.
		/// </summary>
		public virtual float UsedStat { get; set; }

		/// <summary>
		/// Returns maximum weight the character can carry.
		/// </summary>
		/// <remarks>
		/// Base 5000, plus 5 for each Str/Con.
		/// </remarks>
		public virtual float MaxWeight { get { return (5000 + this.Stats.STR * 5 + this.Stats.CON * 5); } }

		/// <summary>
		/// Returns ratio between NowWeight and MaxWeight.
		/// </summary>
		public virtual float WeightRatio { get { return 100f / this.MaxWeight * this.NowWeight; } }

		/// <summary>
		/// Character's current speed.
		/// </summary>
		public virtual float Speed { get; set; }

		/// <summary>
		/// Specifies whether the character currently updates the visible
		/// entities around the character.
		/// </summary>
		public virtual bool EyesOpen { get; protected set; }

		/// <summary>
		/// Character's scripting variables.
		/// </summary>
		public virtual Variables Variables { get; protected set; }

		public virtual Stats Stats { get; protected set; }

		/// <summary>
		/// Creates new character.
		/// </summary>
		public Character()
		{
			this.Handle = ChannelServer.Instance.World.CreateHandle();
			this.Inventory = new Inventory(this);
			this.Variables = new Variables();
			this.Speed = 30;
			this.Direction = new Direction(0);
		}

		/// <summary>
		/// Returns character's current speed.
		/// </summary>
		/// <returns></returns>
		public virtual float GetSpeed()
		{
			return this.Speed;
		}

		/// <summary>
		/// Returns character's current jump strength.
		/// </summary>
		/// <returns></returns>
		public virtual float GetJumpStrength()
		{
			return 300;
		}

		/// <summary>
		/// Returns character's jump type.
		/// </summary>
		/// <returns></returns>
		public virtual int GetJumpType()
		{
			return 1;
		}

		/// <summary>
		/// Starts movement.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public virtual void Move(float x, float y, float z, float dx, float dy, float unkFloat)
		{
			this.SetPosition(x, y, z);
			this.SetDirection(dx, dy);
			this.IsMoving = true;

			Send.ZC_MOVE_DIR(this, x, y, z, dx, dy, unkFloat);
		}

		/// <summary>
		/// Stops movement.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public virtual void StopMove(float x, float y, float z, float dx, float dy)
		{
			this.SetPosition(x, y, z);
			this.SetDirection(dx, dy);
			this.IsMoving = false;

			// Sending ZC_MOVE_STOP works as well, but it doesn't have
			// a direction, so the character stops and looks north
			// on other's screens.
			Send.ZC_PC_MOVE_STOP(this, this.Position, this.Direction);
		}

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="mapId"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <exception cref="ArgumentException">Thrown if map doesn't exist in data.</exception>
		public virtual void Warp(string mapName, float x, float y, float z)
		{
			var map = ChannelServer.Instance.ClientData.MapDB.FirstOrDefault(m => m.EngName == mapName);
			if (map == null)
				throw new ArgumentException("Map '" + mapName + "' not found in data.");

			this.Warp(map.MapId, x, y, z);
		}

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="loc"></param>
		public virtual void Warp(Location loc)
		{
			this.Warp(loc.MapId, loc.X, loc.Y, loc.Z);
		}

		/// <summary>
		/// Warps character to given location.
		/// </summary>
		/// <param name="mapId"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <exception cref="ArgumentException">Thrown if map doesn't exist in world.</exception>
		public virtual void Warp(int mapId, float x, float y, float z)
		{
			var map = ChannelServer.Instance.World.GetMap(mapId);
			if (map == null)
				throw new ArgumentException("Map with id '" + mapId + "' doesn't exist in world.");

			this.Position = new Position(x, y, z);

			if (this.MapId == mapId)
			{
				Send.ZC_SET_POS(this);
			}
			else
			{
				this.MapId = mapId;
				_warping = true;

				Send.ZC_MOVE_ZONE(this.Connection);
			}
		}

		/// <summary>
		/// Finalizes warp, after client announced readiness.
		/// </summary>
		public virtual void FinalizeWarp()
		{
			// Check permission
			if (!_warping)
			{
				Log.Warning("Character.FinalizeWarp: Player '{0}' tried to warp without permission.", this.AccountId);
				return;
			}

			_warping = false;

			ChannelServer.Instance.Database.SaveCharacter(this);
			Send.ZC_MOVE_ZONE_OK(this.Connection, this.MapId);
		}

		/// <summary>
		/// Increases character's level by the given amount of levels.
		/// </summary>
		public virtual void LevelUp(int amount)
		{
			this.Stats.Level += amount;
			this.StatByLevel += amount;

			var exp = ChannelServer.Instance.ClientData.ExpDB[0].Exp;
			if (this.Stats.Level < 1)
				return;

			if (this.Stats.Level > exp.Count)
				this.Stats.MaxExp = 0;

			this.Stats.MaxExp = exp[this.Stats.Level - 1];

			// packet = new Packet(Op.ZC_OBJECT_PROPERTY);
			//packet.PutLong(target.Id);
			//packet.PutBinFromHex("8E 10 00 00 00 40 98 10 00 00 40 41 33 11 00 00 E4 42 29 11 00 80 83 43 36 11 00 00 A0 40 37 11 00 00 A0 40 59 11 00 00 00 41 70 11 00 00 10 41 2F 11 00 00 A0 40 6B 11 00 00 10 41 D5 11 00 00 E0 40 CD 11 00 00 E0 40 CF 11 00 00 50 41 D2 11 00 00 40 41 E0 11 00 00 48 42 D7 11 00 00 0C 43 DE 10 53 9A 0E 40");
			//conn.Send(packet);

			//packet = new Packet(Op.ZC_NORMAL);
			//packet.PutBinFromHex("1C 00 00 00 ");
			//packet.PutInt(target.Handle);
			//packet.PutBinFromHex("00 75 77 78 04 00 00 00 00 9A E7 8A C4 74 76 82 43 39 0C 09 C4 F2 04 35 BF F4 04 35 BF 00 00 00 00 00 00 00 00 00 00 00 00");
			//conn.Send(packet);

			//packet = new Packet(Op.ZC_UPDATE_ALL_STATUS);
			//packet.PutInt(target.Handle);
			//packet.PutBinFromHex("07 01 00 00 07 01 00 00 72 00 72 00 09 00 00 00");
			//conn.Send(packet);

			Send.ZC_MAX_EXP_CHANGED(this, 0);
			Send.ZC_PC_LEVELUP(this);
			Send.ZC_OBJECT_PROPERTY(this, ObjectProperty.PC["StatByLevel"]);
			Send.ZC_NORMAL_LevelUp(this);

			//packet = new Packet(Op.ZC_PC_PROP_UPDATE);
			//packet.PutBinFromHex("DA 10 00");
			//conn.Send(packet);

			//packet = new Packet(Op.ZC_PC_PROP_UPDATE);
			//packet.PutBinFromHex("0F 11 00");
			//conn.Send(packet);
		}

		/// <summary>
		/// Increases character's level by one.
		/// </summary>
		public virtual void LevelUp()
		{
			this.LevelUp(1);
		}

		/// <summary>
		/// Grants exp to character and handles level ups.
		/// </summary>
		/// <param name="exp"></param>
		public virtual void GiveExp(int exp, int jobExp, Monster monster)
		{
			this.Stats.Exp += exp;
			// TODO: jobExp

			Send.ZC_EXP_UP_BY_MONSTER(this, exp, 0, monster);
			Send.ZC_EXP_UP(this, exp, 0);

			while (this.Stats.Exp >= this.Stats.MaxExp)
			{
				this.Stats.Exp -= this.Stats.MaxExp;
				this.LevelUp();
			}
		}

		/// <summary>
		/// Returns ids of equipped items.
		/// </summary>
		/// <returns></returns>
		public virtual int[] GetEquipIds()
		{
			return this.Inventory.GetEquipIds();
		}

		/// <summary>
		/// Updates visible entities around character.
		/// </summary>
		public virtual void LookAround()
		{
			if (!this.EyesOpen)
				return;

			lock (_lookAroundLock)
			{
				// Get lists
				var currentlyVisibleMonsters = this.Map.GetVisibleMonsters(this);
				var currentlyVisibleCharacters = this.Map.GetVisibleCharacters(this);

				// Appears
				var appearMonsters = currentlyVisibleMonsters.Except(_visibleMonsters);
				var appearCharacters = currentlyVisibleCharacters.Except(_visibleCharacters);

				// Disappears
				var disappearMonsters = _visibleMonsters.Except(currentlyVisibleMonsters);
				var disappearCharacters = _visibleCharacters.Except(currentlyVisibleCharacters);

				// Monsters
				foreach (var monster in appearMonsters)
				{
					Send.ZC_ENTER_MONSTER(this.Connection, monster);
					Send.ZC_FACTION(this.Connection, monster);
				}

				foreach (var monster in disappearMonsters)
					Send.ZC_LEAVE(this.Connection, monster);

				// Characters
				foreach (var character in appearCharacters)
					Send.ZC_ENTER_PC(this.Connection, character);

				foreach (var character in disappearCharacters)
					Send.ZC_LEAVE(this.Connection, character);

				// Save lists for next run
				_visibleMonsters = currentlyVisibleMonsters;
				_visibleCharacters = currentlyVisibleCharacters;
			}
		}

		/// <summary>
		/// Starts auto-updates of visible entities.
		/// </summary>
		public virtual void OpenEyes()
		{
			this.EyesOpen = true;
			this.LookAround();
		}

		/// <summary>
		/// Stops auto-updates of visible entities.
		/// </summary>
		public virtual void CloseEyes()
		{
			this.EyesOpen = false;

			lock (_lookAroundLock)
			{
				foreach (var monster in _visibleMonsters)
					Send.ZC_LEAVE(this.Connection, monster);

				foreach (var character in _visibleCharacters)
					Send.ZC_LEAVE(this.Connection, character);

				_visibleMonsters = new Monster[0];
				_visibleCharacters = new Character[0];
			}
		}

		/// <summary>
		/// Sets direction and updates clients.
		/// </summary>
		/// <param name="d1"></param>
		/// <param name="d2"></param>
		public virtual void Rotate(float d1, float d2)
		{
			this.SetDirection(d1, d2);
			Send.ZC_ROTATE(this);
		}

		/// <summary>
		/// Sets direction and updates clients.
		/// </summary>
		/// <param name="d1"></param>
		/// <param name="d2"></param>
		public virtual void RotateHead(float d1, float d2)
		{
			this.SetHeadDirection(d1, d2);
			Send.ZC_HEAD_ROTATE(this);
		}
	}
}
