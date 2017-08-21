﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.Database;
using Melia.Channel.Network;
using Melia.Channel.Scripting;
using Melia.Channel.Util;
using Melia.Channel.World;
using Melia.Shared;
using Melia.Shared.Database;
using Melia.Shared.Network;
using Melia.Shared.Util;
using Melia.Shared.Util.Commands;
using Melia.Shared.Util.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel
{
	public class ChannelServer : Server
	{
		public static readonly ChannelServer Instance = new ChannelServer();

		/// <summary>
		/// Login server's database.
		/// </summary>
		public ChannelDb Database { get; private set; }

		/// <summary>
		/// Represents client specific data from IES files.
		/// </summary>
		public ClientDB Data { get; private set; }

		/// <summary>
		/// Channel's console commands.
		/// </summary>
		public ConsoleCommands ConsoleCommands { get; private set; }

		/// <summary>
		/// GM commands.
		/// </summary>
		public GmCommands GmCommands { get; private set; }

		/// <summary>
		/// The world~
		/// </summary>
		public WorldManager World { get; private set; }

		/// <summary>
		/// Channel's script manager.
		/// </summary>
		public ScriptManager ScriptManager { get; private set; }

		/// <summary>
		/// Connection acceptor and manager.
		/// </summary>
		public ConnectionManager<ChannelConnection> ConnectionManager { get; private set; }

		/// <summary>
		/// Creates new channel server.
		/// </summary>
		private ChannelServer()
		{
			this.World = new WorldManager();
			this.ScriptManager = new ScriptManager();
		}

		/// <summary>
		/// Starts the server.
		/// </summary>
		public override void Run()
		{
			base.Run();

			CliUtil.WriteHeader("Channel", ConsoleColor.DarkGreen);
			CliUtil.LoadingTitle();

			// Conf
			this.LoadConf();

			// Database
			this.Database = new ChannelDb();
			this.InitDatabase(this.Database);
			SessionFactory.Init(this.Database._connectionString);

			// Data
			this.Data = new ClientDB();

			// GM Commands
			this.GmCommands = new GmCommands();

			// Packet handlers
			ChannelPacketHandler.Instance.RegisterMethods();

			// World
			Log.Info("Initializing world...");
			this.World.Initialize();
			Log.Info("  done loading {0} maps.", this.World.Count);

			// Script manager
			this.ScriptManager.Initialize();
			this.ScriptManager.Load();
			
			// Server
			this.ConnectionManager = new ConnectionManager<ChannelConnection>(Int32.Parse(Settings.Default.ZoneServerPort));
			this.ConnectionManager.Start();

			// Ready
			CliUtil.RunningTitle();
			Log.Status("Server ready, listening on {0}.", this.ConnectionManager.Address);

			// Commands
			this.ConsoleCommands = new ConsoleCommands();
			this.ConsoleCommands.Wait();
		}
	}
}
