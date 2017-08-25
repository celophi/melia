using Melia.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared.Client.Logic
{
    public static class SkillPropCalc
    {
        // Incomplete
        [ClientScriptAttribute("SCR_GET_SKL_COOLDOWN")]
        public static float GetSkillCooldown(SkillData skill)
        {
            return skill.BasicCoolDown;
        }

        // Incomplete
        [ClientScriptAttribute("SCR_GET_SKL_COOLDOWN_WIZARD")]
        public static float GetWizardSkillCooldown(SkillData skill)
        {
            var effective = skill.BasicCoolDown;
            
            if (effective < skill.MinCoolDown)
                return skill.MinCoolDown;

            return effective;
        }
    }
}
