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
		public virtual float SPR { get; set; }
		public virtual float DEX { get; set; }
		public virtual int HP { get; set; }
		public virtual int SP { get; set; }
		public virtual int Stamina { get; set; }
		public virtual int Exp { get; set; }
		public virtual int MaxExp { get; set; }

		protected Stats() { }

		public Stats(Character character)
		{
			this.Character = character;
		}
	}
}
