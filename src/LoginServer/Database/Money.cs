using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
{
	public class Money
	{
		private object _key = new object();
		public Account Account { get; protected set; }
		public virtual int TP { get; protected set; }
		public virtual int FreeTP { get; protected set; }
		public virtual int EventTP { get; protected set; }

		#region NHibernate
		protected Money() { }
		#endregion

		/// <summary>
		/// Creates an object used to manage account related currencies.
		/// </summary>
		/// <param name="account"></param>
		public Money(Account account)
		{
			this.Account = account;
		}

		/// <summary>
		/// Used to determine if enough combined TP exists to make a purchase.
		/// </summary>
		/// <param name="cost"></param>
		/// <returns></returns>
		public virtual bool CanAfford(int cost)
		{
			lock (this._key)
			{
				return (cost <= this.TP + this.FreeTP + this.EventTP);
			}
		}

		/// <summary>
		/// Charges an account with a purchase.
		/// </summary>
		/// <param name="cost"></param>
		public virtual void Charge(int cost)
		{
			lock (this._key)
			{
				if (!this.CanAfford(cost))
				{
					throw new Exception("Error. Unable to complete the purchase because of insufficient funds.");
				}

				this.FreeTP -= cost;
				if (this.FreeTP >= 0)
					return;

				this.EventTP -= this.FreeTP;
				this.FreeTP = 0;
				if (this.EventTP >= 0)
					return;

				this.TP -= this.EventTP;
				this.EventTP = 0;
				if (this.TP >= 0)
					return;

				throw new Exception("Error. Unable to complete the purchase because of insufficient funds.");
			}
		}
	}
}
