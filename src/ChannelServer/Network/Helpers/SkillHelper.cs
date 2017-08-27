// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using Melia.Shared.Const;
using Melia.Shared.Network;
using System.Linq;
using Melia.Shared.Client.Logic;

namespace Melia.Channel.Network.Helpers
{
	public static class SkillHelper
	{
		public static void AddSkill(this Packet packet, int skillId)
		{
			var skill = ChannelServer.Instance.ClientData.SkillDB.FirstOrDefault(x => x.ClassID == skillId);
			if (skill == null)
				throw new NullReferenceException("Tried to add non-existing skill'" + skillId + "' ");
			packet.PutLong(0); // skill object id (can be used to change skill properties with ZC_OBJECT_PROPERTY)
			packet.PutInt(skillId);
			packet.PutShort(8 * 3); // properties size
			packet.PutEmptyBin(2); // alignment
			packet.PutInt(0); // ?
			packet.PutShort(0); // ?
			packet.PutEmptyBin(2); // alignment
			// Properties
			//packet.PutInt(ObjectProperty.Skill["WaveLength"]);
			//packet.PutFloat(skill.WaveLength);
			//packet.PutInt(ObjectProperty.Skill["SplAngle"]);
			//packet.PutFloat(skill.SplashAngle);
			//packet.PutInt(ObjectProperty.Skill["SplRange"]);
			//packet.PutFloat(skill.SplashRange);

            //
            packet.PutInt(ObjectProperty.Skill["CoolDown"]);
            packet.PutFloat(SkillPropertyCalculation.Run(skill.CoolDown, skill));

            packet.PutInt(ObjectProperty.Skill["SpendItemCount"]);
            packet.PutFloat(SkillPropertyCalculation.Run(skill.SpendItemCount, skill));

            packet.PutInt(ObjectProperty.Skill["Level"]);
            //packet.PutFloat(SkillPropertyCalculation.Run(skill.Level, skill));
            packet.PutFloat(10);
        }

	}
}
