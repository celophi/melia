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
	public class ItemData
	{
		public int ItemId { get; set; }
		public string ClassName { get; set; }
		public string Name { get; set; }
		public InventoryCategory Category { get; set; }
		public int Weight { get; set; }
		public int MaxStack { get; set; }
		public int Price { get; set; }
		public int SellPrice { get; set; }
	}
}
