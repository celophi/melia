// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Login.World;
using Melia.Shared.Const;
using Melia.Shared.Data.Database;
using Melia.Shared.Util;
using Melia.Shared.Util.Security;
using Melia.Shared.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
{
	/// <summary>
	/// A player's account.
	/// </summary>
	public class Account
	{
		private IList<Character> _characters;
		private object _key = new object();

		public virtual Money Money { get; protected set; }

		/// <summary>
		/// Account id.
		/// </summary>
		public virtual long Id { get; set; }

		/// <summary>
		/// Account name.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Account password.
		/// </summary>
		public virtual string Password { get; set; }

		/// <summary>
		/// Gets or sets account's team name, also updates all characters.
		/// </summary>
		public virtual string TeamName { get; set; }

		/// <summary>
		/// Amount of medals (iCoins).
		/// </summary>
		public virtual int Medals { get; set; } = 500;

		/// <summary>
		/// Id of the barrack map.
		/// </summary>
		public virtual int SelectedBarrack { get; set; } = 11;

		protected Account() { }

		/// <summary>
		/// Creates a new account.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="password"></param>
		public static Account New(string name, string password)
		{
			if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 16)
			{
				throw new Exception("Error. The name field may not be null and must be between 4 and 16 characters in length.");
			}

			if (string.IsNullOrWhiteSpace(password) || password.Length != 32)
			{
				throw new Exception("Error. The password field may not be null and must be between 4 and 16 characters in length.");
			}

			var encrypted = BCrypt.HashPassword(password, BCrypt.GenerateSalt());

			var account =  new Account
			{
				Name = name,
				Password = encrypted,
				_characters = new List<Character>()
			};
			account.Money = new Money(account);

			return account;
		}

		/// <summary>
		/// Creates a new character and registers it with the account.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="gender"></param>
		/// <param name="hair"></param>
		/// <param name="jobData"></param>
		/// <param name="mapData"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
		public virtual Character CreateCharacter(string name, Gender gender, byte hair, JobData jobData, MapData mapData, Position pos)
		{
			lock (this._key)
			{
				if (this.GetCharacterByName(name) != null)
					throw new Exception("Error. Unable to create character because an already existing character has the same name.");

				var character = Character.New(this, name, gender, hair, jobData, mapData, pos);

				for (byte i = 1; i <= byte.MaxValue; ++i)
				{
					if (!_characters.Any(a => a.Index == i))
					{
						character.Index = i;
						break;
					}
				}

				this._characters.Add(character);
				return character;
			}
		}

		/// <summary>
		/// Deletes a character from the account.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public virtual byte DeleteCharacter(Character character)
		{
			lock (this._key)
			{
				if (!this._characters.Contains(character))
					throw new Exception("Error. the character supplied does not exist.");

				this._characters.Remove(character);
				return character.Index;
			}
		}

		/// <summary>
		/// Assigns the team name for the account. This may be performed only once.
		/// </summary>
		/// <param name="name"></param>
		public virtual void AssignTeamName(string name)
		{
			lock (this._key)
			{
				if (!this.IsTeamNameValid(name))
					throw new Exception("Error. The team name did not meet the validation requirements.");

				this.TeamName = name;
			}
		}

		/// <summary>
		/// Checks to see if the team name meets the valid requirements.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public virtual bool IsTeamNameValid(string name)
		{
			lock (this._key)
			{
				return (name.Length <= 16 &&
					name.Length >= 4 &&
					!name.Any(a => Char.IsWhiteSpace(a)));
			}
		}

		/// <summary>
		/// Charges the account and makes the new barrack available to the account.
		/// </summary>
		/// <param name="barrack"></param>
		/// <param name="cost"></param>
		public virtual void PurchaseBarrack(int barrack, int cost)
		{
			lock (this._key)
			{
				if (!this.Money.CanAfford(cost))
					throw new Exception("Error. Cannot afford the barrack purchase price.");

				this.Money.Charge(cost);
				this.SelectedBarrack = barrack;
			}
		}

		public virtual void PurchaseCharacterSlot()
		{
			throw new NotImplementedException();
		}

		public virtual void PurchaseTeamNameChange()
		{
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// Returns list of all characters on account.
		/// </summary>
		/// <returns></returns>
		public virtual Character[] GetCharacters()
		{
			lock (_characters)
				return _characters.OrderBy(x => x.Index).ToArray();
		}

		/// <summary>
		/// Returns character by index, or null if it doesn't exist.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual Character GetCharacterByIndex(byte index)
		{
			lock (_characters)
				return _characters.FirstOrDefault(a => a.Index == index);
		}

		/// <summary>
		/// Returns character by character id, or null if it doesn't exist.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual Character GetCharacterById(long id)
		{
			lock (this._key)
				return _characters.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Returns a character by name or null if non-existent.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public virtual Character GetCharacterByName(string name)
		{
			lock (this._key)
				return this._characters.FirstOrDefault(x => x.Name == name);
		}
	}
}
