// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Melia.Shared.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared.World
{
	public abstract class BaseCharacter
	{
		/// <summary>
		/// Character's id.
		/// </summary>
		public virtual long Id { get; set; }

		/// <summary>
		/// Id of the character's account.
		/// </summary>
		public virtual long AccountId { get; set; }

		/// <summary>
		/// Character's name.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// Character's team name.
		/// </summary>
		public virtual string TeamName { get; set; }

		/// <summary>
		/// Character's job.
		/// </summary>
		public virtual Job Job { get; set; }

		/// <summary>
		/// Character's gender.
		/// </summary>
		public virtual Gender Gender { get; set; }

		/// <summary>
		/// Character's hair style.
		/// </summary>
		public virtual byte Hair { get; set; }
		

		/// <summary>
		/// The map the character is in.
		/// </summary>
		public virtual int MapId { get; set; }

		/// <summary>
		/// Character's position.
		/// </summary>
		public virtual Position Position { get; set; }

		/// <summary>
		/// Character's direction.
		/// </summary>
		public virtual Direction Direction { get; set; }

		/// <summary>
		/// Character's head's direction.
		/// </summary>
		public virtual Direction HeadDirection { get; set; }
	

		/// <summary>
		/// Returns stance, based on job and other factors.
		/// </summary>
		public virtual int Stance
		{
			get
			{
				var cls = this.Job.ToClass();

				// The stance is affected by the equipped items, we might
				// have to move this to a place where we have proper access
				// to the character's items, and we need item types.
				// Maybe we can use ItemData on Login, so we don't need
				// another Item class.
				// For the official conditions see stancecondition.ies.

				switch (cls)
				{
					default:
					case Class.Swordsman:
						return 10000;

					case Class.Wizard:
						return 10006;

					case Class.Archer:
						return 10008;

					case Class.Cleric:
					case Class.GM:
						return 10004;
				}
			}
		}

		/// <summary>
		/// Sets character's position.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public virtual void SetPosition(float x, float y, float z)
		{
			this.Position = new Position(x, y, z);
		}

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void SetDirection(float x, float y)
		{
			this.Direction = new Direction(x, y);
		}

		/// <summary>
		/// Sets character's direction.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void SetHeadDirection(float x, float y)
		{
			this.HeadDirection = new Direction(x, y);
		}
	}
}
