// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Melia.Shared.Data
{
	[Serializable]
	public class MapData
	{
		public int MapId { get; set; }
		public string ClassName { get; set; }
		public string EngName { get; set; }
		public string LocalKey { get; set; }
	}
}
