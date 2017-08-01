using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	public class ChatMacro
	{
		/// <summary>
		/// Index where to place the macro in the UI
		/// </summary>
		public int Slot { get; private set; }

		/// <summary>
		/// Content of the macro. This can be a classID ex. @dicID_^*$ETC_20151001_014770$*^
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		/// Pose associated with the macro.
		/// </summary>
		public int Pose { get; private set; }

		public ChatMacro(int slot, string message, int pose = 0)
		{
			this.Slot = slot;
			this.Message = message;
			this.Pose = pose;
		}
	}
}
