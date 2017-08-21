// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Melia.Shared.Data
{
	[Serializable]
	public class ExpData
	{
		public IList<int> Exp { get; set; }
		public IList<ClassExpData> ClassExp { get; set; }

		public class ClassExpData
		{
			public int Rank { get; set; }
			public int Level { get; set; }
			public int Exp { get; set; }
		}
		
	}
}
