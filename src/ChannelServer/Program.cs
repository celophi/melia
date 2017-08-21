// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Melia.Channel
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ChannelServer.Instance.Run();
			}
			catch (Exception ex)
			{
				Log.Error("Error on startup: {0}, {1}\r\n{2}\r\n{3}", ex.GetType().Name, ex.Message, ex.TargetSite, ex.StackTrace);
				CliUtil.Exit(1, true);
			}
		}
	}
}
