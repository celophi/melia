using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Melia.Shared.Data
{
	[Serializable]
	public class CustomCommandData
	{
		public int ClassId { get; set; }
		public string ClassName { get; set; }
		public string Script { get; set; }
		public string UseTx { get; set; }
	}
}
