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
		public virtual float Percentage { get; protected set; }

		protected MapVisibility() { }

		public MapVisibility(Account account, int map, byte[] visible)
		{
			this.Account = account;
			this.Map = map;
			this.Visible = visible;
		}

		/// <summary>
		/// Sets the explored percentage for a map.
		/// </summary>
		/// <param name="percentage"></param>
		public virtual void SetPercentage(float percentage)
		{
			if (percentage < 0 || percentage > 100)
				throw new Exception(string.Format("Error. Unable to set explored percentage value of '{0}' because it was invalid.", percentage));

			this.Percentage = percentage;
		}
	}
}
