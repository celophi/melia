﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.Client;
using Melia.Login.Database;
using Melia.Login.Network;
using Melia.Login.Util;
using Melia.Shared;
using Melia.Shared.Database;
using Melia.Shared.Network;
using Melia.Shared.Util;
using Melia.Shared.Util.Commands;
using Melia.Shared.Util.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login
{
	public class LoginServer : Server
	{
		public static readonly LoginServer Instance = new LoginServer();

		/// <summary>
		/// Login server's database.
		/// </summary>
		public LoginDb Database { get; private set; }

		/// <summary>
		/// Represents client specific data from IES files.
		/// </summary>
		public ClientData ClientData { get; private set; }

		/// <summary>
		/// Login's console commands.
		/// </summary>
		public ConsoleCommands ConsoleCommands { get; private set; }

		/// <summary>
		/// Starts the server.
		/// </summary>
		public override void Run()
		{
			base.Run();

			CliUtil.WriteHeader("Login", ConsoleColor.Magenta);
			CliUtil.LoadingTitle();

			// Conf
			this.LoadConf();

			// Database
			this.Database = new LoginDb();
			this.InitDatabase(this.Database);
			SessionFactory.Init(this.Database._connectionString);

			// Check if there are any updates
			this.CheckDatabaseUpdates();

			// Data
			this.ClientData = new ClientData();

			// Packet handlers
			LoginPacketHandler.Instance.RegisterMethods();

			// Server
			var mgr = new ConnectionManager<LoginConnection>(Int32.Parse(Settings.Default.LoginServerPort));
			mgr.Start();

			// Ready
			CliUtil.RunningTitle();
			Log.Status("Server ready, listening on {0}.", mgr.Address);

			// Commands
			this.ConsoleCommands = new LoginConsoleCommands();
			this.ConsoleCommands.Wait();
		}

		private void CheckDatabaseUpdates()
		{
			Log.Info("Checking for updates...");

			var files = Directory.GetFiles("sql");
			foreach (var filePath in files.Where(file => Path.GetExtension(file).ToLower() == ".sql"))
				this.RunUpdate(Path.GetFileName(filePath));
		}

		private void RunUpdate(string updateFile)
		{
			if (LoginServer.Instance.Database.CheckUpdate(updateFile))
				return;

			Log.Info("Update '{0}' found, executing...", updateFile);

			LoginServer.Instance.Database.RunUpdate(updateFile);
		}
	}
}
