using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Melia.Shared.Data
{
	[Serializable]
	public class HelpData
	{
		public int HelpId { get; set; }
		public string ClassName { get; set; }
		public string DBSave { get; set; }
		public string BasicHelp { get; set; }
	}
}
