using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class MapVisibility
	{
		public virtual long Id { get; protected set; }
		public virtual Account Account { get; protected set; }
		public virtual int Map { get; protected set; }
		public virtual byte[] Visible { get; set; }

		protected MapVisibility() { }

		public MapVisibility(Account account, int map, byte[] visible)
		{
			this.Account = account;
			this.Map = map;
			this.Visible = visible;
		}
	}
}
