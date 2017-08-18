using Melia.Shared.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Domain
{
	public class Stats
	{
		public readonly Character Character;
		public virtual int Level { get; protected set; }
		public virtual int MaxHP { get; protected set; }
		public virtual int MaxSP { get; protected set; }
		public virtual int MaxStamina { get; protected set; }
		public virtual int STR { get; protected set; }
		public virtual int CON { get; protected set; }
		public virtual int INT { get; protected set; }
		public virtual int SPR { get; protected set; }
		public virtual int DEX { get; protected set; }

		protected Stats() { }

		public Stats(Character character, JobData data) : this()
		{
			this.Character = character;
			this.Level = 1;
			this.MaxHP = 100;
			this.MaxSP = 50;
			this.MaxStamina = 25000;
			this.STR = data.Str;
			this.CON = data.Con;
			this.INT = data.Int;
			this.SPR = data.Spr;
			this.DEX = data.Dex;
		}
	}
}