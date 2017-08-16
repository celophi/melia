// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Dapper;
using Melia.Login.World;
using Melia.Shared.Const;
using Melia.Shared.Database;
using Melia.Shared.Util;
using Melia.Shared.Util.Security;
using Melia.Shared.World;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
{
	public class LoginDb : MeliaDb
	{
		/// <summary>
		/// Checks whether the SQL update file has already been applied.
		/// </summary>
		/// <param name="updateFile"></param>
		/// <returns></returns>
		public bool CheckUpdate(string updateFile)
		{
			using (var conn = this.GetConnection())
			{
				var query = @"SELECT COUNT(1) FROM `updates` WHERE `path` = @_path";
				return conn.ExecuteScalar<bool>(query, new { _path = updateFile });
			}
		}

		/// <summary>
		/// Executes SQL update file.
		/// </summary>
		/// <param name="updateFile"></param>
		public void RunUpdate(string updateFile)
		{
			try
			{
				using (var conn = this.GetConnection())
				{
					// Run update
					using (var cmd = new MySqlCommand(File.ReadAllText(Path.Combine("sql", updateFile)), conn))
						cmd.ExecuteNonQuery();

					// Log update
					using (var cmd = new InsertCommand("INSERT INTO `updates` {0}", conn))
					{
						cmd.Set("path", updateFile);
						cmd.Execute();
					}

					Log.Info("Successfully applied '{0}'.", updateFile);
				}
			}
			catch (Exception ex)
			{
				Log.Error("RunUpdate: Failed to run '{0}': {1}", updateFile, ex.Message);
				CliUtil.Exit(1);
			}
		}

		/// <summary>
		/// Returns true if accounts exists.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool AccountExists(string name)
		{
			using (var conn = this.GetConnection())
			{
				var query = @"SELECT COUNT(1) FROM `accounts` WHERE `name` = @_name";
				return conn.ExecuteScalar<bool>(query, new { _name = name });
			}
		}

		/// <summary>
		/// Persists the account.
		/// </summary>
		/// <param name="account"></param>
		public void SaveAccount(Account account)
		{
			using (ISession session = SessionFactory.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				session.SaveOrUpdate(account);
				tx.Commit();
			}
		}

		/// <summary>
		/// Returns account with given name, or null if it doesn't exist.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Account GetAccount(string name)
		{
			using (ISession session = SessionFactory.OpenSession())
			{
				var account = session.Query<Account>()
					.Where(x => x.Name == name)
					.FirstOrDefault();

				if (account != null)
				{
					// Upgrade MD5 hashes
					if (account.Password.Length == 32)
						account.Password = BCrypt.HashPassword(account.Password, BCrypt.GenerateSalt());
				}
				
				return account;
			}
		}

		/// <summary>
		/// Returns true if team name exists.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool TeamNameExists(string teamName)
		{
			using (var conn = this.GetConnection())
			{
				var query = @"SELECT COUNT(1) FROM `accounts` WHERE `teamName` = @_teamName";
				return conn.ExecuteScalar<bool>(query, new { _teamName = teamName });
			}
		}
		

		/// <summary>
		/// Changes the given account's auth level.
		/// </summary>
		/// <param name="accountName"></param>
		/// <param name="level"></param>
		/// <returns></returns>
		public bool ChangeAuth(string accountName, int level)
		{
			using (var conn = this.GetConnection())
			{
				var query = @"UPDATE `accounts` SET `authority` = @_level WHERE `name` = @_accountName";
				return conn.ExecuteScalar<bool>(query, new { _level = level, _accountName = accountName });
			}
		}

		/// <summary>
		/// Changes the given account's password. TODO: make this bcrypt!
		/// </summary>
		/// <param name="accountName"></param>
		/// <param name="password"></param>
		public bool SetAccountPassword(string accountName, string password)
		{
			var md5 = MD5.Create();
			var hashedPassword = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
			
			using (var conn = this.GetConnection())
			{
				var query = @"UPDATE `accounts` SET `password` = @_password WHERE `name` = @_accountName";
				return conn.ExecuteScalar<bool>(query, new { _password = password, _accountName = accountName });
			}
		}
	}
}
