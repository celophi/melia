using Melia.Shared.Data;
using Melia.Shared.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Melia.Login.Database
{
	public class ClientDB
	{
		public const string CLIENT_DB_DIR = "ClientDB";
		public const string BARRACK_FILE = "barracks.json";
		public const string ITEM_FILE = "item.json";
		public const string JOBS_FILE = "jobs.json";
		public const string MAPS_FILE = "maps.json";
		public const string SERVERS_FILE = "servers.json";
		public const string STARTING_CITIES_FILE = "startingcities.json";

		public IList<BarrackData> BarrackDB;
		public IList<ItemData> ItemDB;
		public IList<JobData> JobDB;
		public IList<MapData> MapDB;
		public IList<StartingCityData> StartingCityDB;

		public ClientDB()
		{
			var configDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ClientDB.CLIENT_DB_DIR);
			if (!Directory.Exists(configDir))
			{
				Log.Error("Error. The client data directory '{0}' does not exist.", configDir);
				return;
			}

			this.BarrackDB = this.Load<BarrackData>(Path.Combine(configDir, ClientDB.BARRACK_FILE));
			this.ItemDB = this.Load<ItemData>(Path.Combine(configDir, ClientDB.ITEM_FILE));
			this.JobDB = this.Load<JobData>(Path.Combine(configDir, ClientDB.JOBS_FILE));
			this.MapDB = this.Load<MapData>(Path.Combine(configDir, ClientDB.MAPS_FILE));
			this.StartingCityDB = this.Load<StartingCityData>(Path.Combine(configDir, ClientDB.STARTING_CITIES_FILE));
		}

		private IList<T> Load<T>(string filePath)
		{
			return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
		}
	}
}
