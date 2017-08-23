using Melia.Shared.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Client
{
	public class ClientData
	{
		public readonly IList<CustomCommandData> CustomCommandDB = ClientData.Load<CustomCommandData>("customcommand.json");
		public readonly IList<DialogData> DialogDB = ClientData.Load<DialogData>("dialogues.json");
		public readonly IList<ExpData> ExpDB = ClientData.Load<ExpData>("exp.json");
		public readonly IList<HelpData> HelpDB = ClientData.Load<HelpData>("help.json");
		public readonly IList<ItemData> ItemDB = ClientData.Load<ItemData>("item.json");
		public readonly IList<MapData> MapDB = ClientData.Load<MapData>("maps.json");
		public readonly IList<MonsterData> MonsterDB = ClientData.Load<MonsterData>("monsters.json");
		public readonly IList<ShopData> ShopDB = ClientData.Load<ShopData>("shops.json");
		public readonly IList<SkillData> SkillDB = ClientData.Load<SkillData>("skills.json");

		public static IList<T> Load<T>(string filename)
		{
			var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Default.ClientDataFolder, filename);
			return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(dataPath));
		}
	}
}
