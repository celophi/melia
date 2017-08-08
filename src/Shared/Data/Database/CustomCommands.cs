using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class CustomCommandData
	{
		public int ClassId { get; set; }
		public string ClassName { get; set; }
		public string Script { get; set; }
		public bool UseTx { get; set; }
	}
	
	public class CustomCommandDb : DatabaseJsonIndexed<int, CustomCommandData>
	{
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("ClassId", "ClassName", "Script", "UseTx");

			var info = new CustomCommandData();

			info.ClassId = entry.ReadInt("ClassId");
			info.ClassName = entry.ReadString("ClassName");
			info.Script = entry.ReadString("Script");
			info.UseTx = entry.ReadString("UseTx") == "YES";

			this.Entries[info.ClassId] = info;
		}
	}
}
