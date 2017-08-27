using Melia.Shared.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Client
{
	public class ClientData
	{
		public readonly IList<BarrackMapData> BarrackDB = ClientData.Load<BarrackMapData>("barrackmap.json");
		public readonly IList<ItemData> ItemDB = ClientData.Load<ItemData>("item.json");
		public readonly IList<JobData> JobDB = ClientData.Load<JobData>("jobs.json");
		public readonly IList<MapData> MapDB = ClientData.Load<MapData>("maps.json");
		public readonly IList<StartingCityData> StartingCityDB = ClientData.Load<StartingCityData>("startingcities.json");

		public static IList<T> Load<T>(string filename)
		{
			var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ClientDataFolder, filename);
			return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(dataPath));
		}
	}
}
