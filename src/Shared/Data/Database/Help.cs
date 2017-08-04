using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class HelpData
	{
		public int HelpId { get; set; }
		public string Name { get; set; }
		public bool DBSave { get; set; } = true;
		public bool BasicHelp { get; set; } = true;
	}

	/// <summary>
	/// Help database
	/// </summary>
	public class HelpDb : DatabaseJsonIndexed<int, HelpData>
	{
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("helpId", "className", "dbSave", "basicHelp");

			var info = new HelpData();

			info.HelpId = entry.ReadInt("helpId");
			info.Name = entry.ReadString("className");
			info.DBSave = entry.ReadString("dbSave") == "YES";
			info.BasicHelp = entry.ReadString("basicHelp") == "YES";

			this.Entries[info.HelpId] = info;
		}
	}
}
