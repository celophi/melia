using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.World
{
	public class Stats
	{
		public virtual Character Character { get; protected set; }
		public virtual int Level { get; set; }
		public virtual int MaxHP { get; set; }
		public virtual int MaxSP { get; set; }
		public virtual int MaxStamina { get; set; }
		public virtual float STR { get; set; }
		public virtual float CON { get; set; }
		public virtual float INT { get; set; }

		/// <summary>
		/// MNA
		/// </summary>
		public virtual float SPR { get; set; }
		public virtual float DEX { get; set; }
		public virtual int HP { get; set; }
		public virtual int SP { get; set; }
		public virtual int Stamina { get; set; }
		public virtual int Exp { get; set; }
		public virtual int MaxExp { get; set; }

		private Dictionary<string, int> _dummyStats = new Dictionary<string, int>
		{
			{ "MSPD", 30},
			{ "RHPTIME", 20000 },
			{ "MNA", 3 },
			{ "Permission", 3 },
			{ "NowWeight", 350 },
			{ "MaxWeight", 8000 },
			{ "Sta_Recover", 500 },
			{ "CAST", 1 },
			{ "SDR", 1 },
			{ "DR", 2 },
			{ "HR", 3 },
			{ "SR", 4 },
			{ "RHP", 20 },
			{ "CRTATK", 20 },
			{ "SkillAngle", 8 },
			{ "MDEF", 27 },
			{ "BLK_BREAK", 2 },
			{ "LUCK", 1 },
			{ "Sta_Step", 2500 },
			{ "Sta_Runable", 250 },
			{ "Sta_R_Delay", 1000 },
			{ "Sta_Run", 125 },
			{ "ADD_Cooldown", 1 },
			{ "MAXPATK_SUB", 34 },
			{ "MINPATK_SUB", 34 },
			{ "JumpPower", 350 },
			{ "HPDrain", 2 },
			{ "Const", 2 },
			{ "BOOST", 1 },
			{ "MGP", 2 },
			{ "ArmorMaterial_ID", 2 },
			{ "MAXMATK", 24 },
			{ "MINMATK", 24 },
			{ "MAXPATK", 56 },
			{ "MINPATK", 54 },
			{ "KDBonusDefence", 40 },
			{ "KDBonusDamage", 130 },
		};

		protected Stats() { }

		public Stats(Character character)
		{
			this.Character = character;
		}

		/// <summary>
		/// Returns a dummy stat until we can determine the logic needed to calculate all of these.
		/// </summary>
		/// <param name="property"></param>
		/// <returns></returns>
		public int GetDummyStat(string property)
		{
			if (this._dummyStats.ContainsKey(property))
			{
				return this._dummyStats[property];
			} else
			{
				return 0;
			}
		}

		/// <summary>
		/// Gets the initial stat list needed to send to the client.
		/// </summary>
		/// <returns></returns>
		public IList<string> GetListOfInitialStats()
		{
			return new List<string>
			{
				"MSPD",
				"RHPTIME",
				"MNA",
				"Permission",
				"NowWeight",
				"MaxWeight",
				"BLK",
				"IceDefFactor_PC",
				"IceAtkFactor_PC",
				"HolyDefFactor_PC",
				"EarthDefFactor_PC",
				"LightningDefFactor_PC",
				"PoisonDefFactor_PC",
				"FireDefFactor_PC",
				"MissileDefFactor_PC",
				"StrikeDefFactor_PC",
				"SlashDefFactor_PC",
				"AriesDefFactor_PC",
				"DarkAtkFactor_PC",
				"HolyAtkFactor_PC",
				"EarthAtkFactor_PC",
				"LightningAtkFactor_PC",
				"PoisonAtkFactor_PC",
				"FireAtkFactor_PC",
				"MissileAtkFactor_PC",
				"StrikeAtkFactor_PC",
				"SlashAtkFactor_PC",
				"AriesAtkFactor_PC",
				"DarkDefFactor_PC",
				"Sta_Recover",
				"Revive",
				"JobName",
				"CAST",
				"SkillPower",
				"SDR",
				"CRTDR",
				"DR",
				"HR",
				"SR",
				"CRTHR",
				"ASPD",
				"RHP",
				"Dark_Atk",
				"Holy_Atk",
				"Poison_Atk",
				"Ice_Atk",
				"Fire_Atk",
				"RSP",
				"DEF",
				"CRTDEF",
				"CRTATK",
				"HitCount",
				"SkillAngle",
				"SkillRange",
				"MDEF",
				"MHR",
				"BLK_BREAK",
				"Lightning_Atk",
				"Iron_Atk",
				"Leather_Atk",
				"Cloth_Atk",
				"LargeSize_Atk",
				"MiddleSize_Atk",
				"SmallSize_Atk",
				"Earth_Atk",
				"ResEarth",
				"ResDark",
				"ResHoly",
				"ResLightning",
				"ResPoison",
				"ResIce",
				"ResFire",
				"DefStrike",
				"DefSlash",
				"DefAries",
				"ResSoul",
				"Soul_Atk",
				"Ghost_Atk",
				"Velnias_Atk",
				"Paramune_Atk",
				"Klaida_Atk",
				"Widling_Atk",
				"Forester_Atk",
				"LUCK",
				"LUCK_ADD",
				"MNA_ADD",
				"INT_ADD",
				"CON_ADD",
				"DEX_ADD",
				"STR_ADD",
				"MovingShotable",
				"Sta_Step",
				"Sta_Jump",
				"Sta_Runable",
				"Sta_R_Delay",
				"Sta_Run",
				"Sta_RunStart",
				"AddFever",
				"ADD_Cooldown",
				"ADD_OverHeat",
				"Guardable",
				"MAXPATK_SUB",
				"MINPATK_SUB",
				"JumpPower",
				"PlayTime",
				"StunRate",
				"HPDrain_ADD",
				"HPDrain",
				"Const",
				"BOOST",
				"Chain_Atk",
				"MGP",
				"ArmorMaterial_ID",
				"SoulAtkFactor_PC",
				"SoulDefFactor_PC",
				"BLKABLE",
				"MAXMATK",
				"MINMATK",
				"MAXPATK",
				"MINPATK",
				"PostDelay",
				"KDBonusDefence",
				"KDBonusDamage",
				"KnockDownHit",
			};
		}
	}
}
