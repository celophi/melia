using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class ChatMacro
	{
		public virtual Account Account { get; protected set; }

		public virtual long Id { get; protected set; }

		/// <summary>
		/// Index where to place the macro in the UI
		/// </summary>
		public virtual int Slot { get; protected set; }

		/// <summary>
		/// Content of the macro. This can be a classID ex. @dicID_^*$ETC_20151001_014770$*^
		/// </summary>
		public virtual string Message { get; protected set; }

		/// <summary>
		/// Pose associated with the macro.
		/// </summary>
		public virtual int Pose { get; protected set; }

		protected ChatMacro() { }

		public ChatMacro(Account account, int slot, string message, int pose = 0)
		{
			this.Account = account;
			this.Slot = slot;
			this.Message = message;
			this.Pose = pose;
		}

		/// <summary>
		/// Updates a chat macro.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="pose"></param>
		public virtual void Update(string message, int pose)
		{
			this.Message = message;
			this.Pose = pose;
		}
	}
}
