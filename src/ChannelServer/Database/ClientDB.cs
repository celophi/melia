using Melia.Shared.Data;
using Melia.Shared.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Melia.Channel.Database
{
	public class ClientDB
	{
		public const string CLIENT_DB_DIR = "ClientDB";
		public const string ITEM_FILE = "item.json";
		public const string MAPS_FILE = "maps.json";
		public const string HELP_FILE = "help.json";
		public const string SKILLS_FILE = "skills.json";
		public const string MONSTER_FILE = "monsters.json";
		public const string EXP_FILE = "exp.json";
		public const string SHOPS_FILE = "shops.json";
		public const string DIALOGUES_FILE = "dialogues.json";
		public const string CUSTOM_COMAND_FILE = "customcommand.json";

		public IList<ItemData> ItemDB;
		public IList<MapData> MapDB;
		public IList<HelpData> HelpDB;
		public IList<SkillData> SkillDB;
		public IList<MonsterData> MonsterDB;
		public IList<ExpData> ExpDB;
		public IList<ShopData> ShopDB;
		public IList<DialogData> DialogDB;
		public IList<CustomCommandData> CustomCommandDB;


		public ClientDB()
		{
			var configDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ClientDB.CLIENT_DB_DIR);
			if (!Directory.Exists(configDir))
			{
				Log.Error("Error. The client data directory '{0}' does not exist.", configDir);
				return;
			}

			try
			{
				this.ItemDB = this.Load<ItemData>(Path.Combine(configDir, ClientDB.ITEM_FILE));
				this.MapDB = this.Load<MapData>(Path.Combine(configDir, ClientDB.MAPS_FILE));
				this.HelpDB = this.Load<HelpData>(Path.Combine(configDir, ClientDB.HELP_FILE));
				this.SkillDB = this.Load<SkillData>(Path.Combine(configDir, ClientDB.SKILLS_FILE));
				this.MonsterDB = this.Load<MonsterData>(Path.Combine(configDir, ClientDB.MONSTER_FILE));
				this.ExpDB = this.Load<ExpData>(Path.Combine(configDir, ClientDB.EXP_FILE));
				this.ShopDB = this.Load<ShopData>(Path.Combine(configDir, ClientDB.SHOPS_FILE));
				this.DialogDB = this.Load<DialogData>(Path.Combine(configDir, ClientDB.DIALOGUES_FILE));
				this.CustomCommandDB = this.Load<CustomCommandData>(Path.Combine(configDir, ClientDB.CUSTOM_COMAND_FILE));
			} catch (Exception e)
			{
				Log.Error(e.Message, e.TargetSite, e.StackTrace);
				throw;
			}
			
		}

		private IList<T> Load<T>(string filePath)
		{
			return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
		}
	}
}
