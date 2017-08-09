﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Channel.Scripting;
using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Channel.Database
{
	/// <summary>
	/// A player's account.
	/// </summary>
	public class Account
	{
		/// <summary>
		/// Account id
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Account name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Account's team name
		/// </summary>
		public string TeamName { get; set; }

		/// <summary>
		/// The account's authority level, used to determine if a character
		/// can use a specific GM command.
		/// </summary>
		public int Authority { get; set; }

		/// <summary>
		/// The account's settings.
		/// </summary>
		public AccountSettings Settings { get; private set; }

		/// <summary>
		/// Account's scripting variables.
		/// </summary>
		public Variables Variables { get; private set; }


		/// <summary>
		/// Amount of medals (iCoins).
		/// </summary>
		public int Medals { get; set; }

		/// <summary>
		/// Id of the barrack map.
		/// </summary>
		public int SelectedBarrack { get; set; }

		/// <summary>
		/// Contains all visible portions of maps.
		/// </summary>
		public Dictionary<int, byte[]> MapVisibility { get; set; }

		/// <summary>
		/// List of chat macros.
		/// </summary>
		private List<ChatMacro> _chatMacros;

		/// <summary>
		/// lock for updating the account
		/// </summary>
		private object _key = new object();

		/// <summary>
		/// Creates new account.
		/// </summary>
		public Account()
		{
			this.Medals = 500;
			this.SelectedBarrack = 11;

			this.Settings = new AccountSettings();
			this.Variables = new Variables();
			this._chatMacros = new List<ChatMacro>();
		}

		/// <summary>
		/// Returns the chat macros for an account.
		/// </summary>
		/// <returns></returns>
		public IReadOnlyList<ChatMacro> GetChatMacros()
		{
			return this._chatMacros.AsReadOnly();
		}

		/// <summary>
		/// Adds a chat macro to the account.
		/// </summary>
		/// <param name="macro"></param>
		public void AddChatMacro(ChatMacro macro)
		{
			lock(this._key)
			{
				var old = this._chatMacros.FirstOrDefault(x => x.Slot == macro.Slot);
				if (old != null)
					this._chatMacros.Remove(old);

				this._chatMacros.Add(macro);
			}
		}

		/// <summary>
		/// Loads account with given name from database and returns it.
		/// </summary>
		/// <param name="accountName"></param>
		/// <returns></returns>
		public static Account LoadFromDb(string accountName)
		{
			return ChannelServer.Instance.Database.GetAccount(accountName);
		}

		/// <summary>
		/// Saves account database.
		/// </summary>
		public void Save()
		{
			ChannelServer.Instance.Database.SaveAccount(this);
		}
	}
}
