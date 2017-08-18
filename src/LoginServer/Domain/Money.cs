using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Domain
{
	public class Money
	{
		private object _key = new object();
		public readonly Account Account;
		public virtual int Medal { get; protected set; }
		public virtual int GiftMedal { get; protected set; }
		public virtual int PremiumMedal { get; protected set; }

		protected Money() { }

		public Money(Account account) : this()
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
				return (cost <= this.Medal + this.GiftMedal + this.PremiumMedal);
			}
		}

		/// <summary>
		/// Charges an account with a purchase.
		/// </summary>
		/// <param name="money"></param>
		/// <param name="cost"></param>
		/// <returns></returns>
		public static Money operator -(Money money, int cost)
		{
			lock (money._key)
			{
				if (!money.CanAfford(cost))
					throw new Exception("Error. Unable to complete the purchase because of insufficient funds.");

				var balance = new Money(money.Account)
				{
					Medal = money.Medal,
					GiftMedal = money.GiftMedal,
					PremiumMedal = money.PremiumMedal
				};

				balance.GiftMedal -= cost;
				if (balance.GiftMedal >= 0)
					return balance;

				balance.PremiumMedal -= balance.GiftMedal;
				balance.GiftMedal = 0;
				if (balance.PremiumMedal >= 0)
					return balance;

				balance.Medal -= balance.Medal;
				balance.PremiumMedal = 0;
				if (balance.Medal >= 0)
					return balance;

				throw new Exception("Error. Unable to complete the purchase because of insufficient funds.");
			}
		}
	}
}
