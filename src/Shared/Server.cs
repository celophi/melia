// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Shared.Data;
using Melia.Shared.Database;
using Melia.Shared.Util;
using Melia.Shared.Util.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared
{
	/// <summary>
	/// Base class for server applications.
	/// </summary>
	public abstract class Server
	{
		private bool _running;

		/// <summary>
		/// Configuration.
		/// </summary>
		public Conf Conf { get; private set; }

		/// <summary>
		/// File databases.
		/// </summary>
		//public MeliaData Data { get; private set; }

		/// <summary>
		/// Initializes class.
		/// </summary>
		public Server()
		{
			//this.Data = new MeliaData();
		}

		/// <summary>
		/// Starts the server.
		/// </summary>
		public virtual void Run()
		{
			if (_running)
				throw new Exception("Server is already running.");
			_running = true;

			this.NavigateToRoot();
		}

		/// <summary>
		/// Initializes database connection with data from Conf.
		/// </summary>
		protected void InitDatabase(MeliaDb db)
		{
			try
			{
				Log.Info("Initializing database...");
				db.Init(this.Conf.Database.Host, this.Conf.Database.User, this.Conf.Database.Pass, this.Conf.Database.Db);
			}
			catch (Exception ex)
			{
				Log.Error("Failed to initialize database: {0}", ex.Message);
				CliUtil.Exit(1, true);
			}
		}
		

		/// <summary>
		/// Loads configuration.
		/// </summary>
		protected void LoadConf()
		{
			try
			{
				Log.Info("Loading configuration...");
				this.Conf = new Conf();
				this.Conf.LoadAll();
			}
			catch (Exception ex)
			{
				Log.Error("Failed to load configuration: {0}", ex.Message);
				CliUtil.Exit(1, true);
			}
		}

		/// <summary>
		/// Tries to find root folder and changes the working directory to it.
		/// Exits if not successful.
		/// </summary>
		public void NavigateToRoot()
		{
			// Go back max 2 folders, the bins should be in [root]/bin/(Debug|Release)
			for (int i = 0; i < 3; ++i)
			{
				if (Directory.Exists("system") && Directory.Exists("user"))
				{
					//if (i != 0)
					//	Log.Info("Switched workign directory to '{0}'.", Directory.GetCurrentDirectory());
					return;
				}

				Directory.SetCurrentDirectory("..");
			}

			Log.Error("Unable to find root directory, that contains system and user folders.");
			CliUtil.Exit(1);
		}
	}

	[Flags]
	public enum DataToLoad
	{
		Items = 0x01,
		Maps = 0x02,
		Jobs = 0x04,
		Servers = 0x08,
		Barracks = 0x10,
		Monsters = 0x20,
		Skills = 0x40,
		Exp = 0x80,
		Dialogues = 0x100,
		Shops = 0x200,
		StartingCities = 0x400,
		Help = 0x800,
		CustomCommand = 0x1000,

		All = 0x7FFFFFFF,
	}
}
