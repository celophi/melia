﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Melia.Shared.Const;

namespace Melia.Shared.Data
{
	[Serializable]
	public class BarrackMapData
	{
		public int ClassID { get; set; }
		public string ClassName { get; set; }
		public int Price { get; set; }
        public int BaseSlot { get; set; }
    }
}