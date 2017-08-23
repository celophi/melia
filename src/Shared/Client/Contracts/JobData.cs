// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Melia.Shared.Const;

namespace Melia.Shared.Data
{
	[Serializable]
	public class JobData
	{
		public int JobId { get; set; }
		public string ClassName { get; set; }
		public string Initial { get; set; }
		public string Name { get; set; }
		public int Rank { get; set; }
		public int Str { get; set; }
		public int Con { get; set; }
		public int Int { get; set; }
		public int Spr { get; set; }
		public int Dex { get; set; }
		public int BarrackStance { get; set; }
	}
}
