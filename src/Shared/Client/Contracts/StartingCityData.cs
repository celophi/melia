// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using Newtonsoft.Json.Linq;
using Melia.Shared.Const;

namespace Melia.Shared.Data
{
	[Serializable]
	public class StartingCityData
	{
		public StartingCity StartingCityId { get; set; }
		public string Map { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }
	}
}
