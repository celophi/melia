using Melia.Shared.Data;
using Melia.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared.Client.Logic
{
    public static class SkillPropertyCalculation
    {
        private delegate float CalculationFunc(SkillData skill);
        private static Dictionary<string, CalculationFunc> _handlers = new Dictionary<string, CalculationFunc>();

        public static void Init()
        {
            try
            {
                var methods = typeof(SkillPropertyCalculation).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
                .Where(x => x.GetCustomAttributes(typeof(ClientScriptAttribute), false).Length > 0);

                foreach (var method in methods)
                {
                    var attr = (ClientScriptAttribute)method.GetCustomAttributes(typeof(ClientScriptAttribute), false).First();
                    var func = (CalculationFunc)Delegate.CreateDelegate(typeof(CalculationFunc), method);
                    SkillPropertyCalculation._handlers.Add(attr.Name, func);
                }
            } catch (Exception e)
            {
                Log.Error("Error. Unable to initialize skill property calculations!");
                throw e;
            }
        }

        /// <summary>
        /// Runs a skill property calculation function.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        public static float Run(string function, SkillData skill)
        {
            if (SkillPropertyCalculation._handlers.Count == 0)
                SkillPropertyCalculation.Init();

            CalculationFunc handler;
            _handlers.TryGetValue(function, out handler);

            if (handler == null)
                throw new ArgumentException(string.Format("Error. Unable to find handler for specified function '{0}'!", function));

            return handler(skill);
        }

        // Incomplete
        [ClientScriptAttribute("SCR_GET_SKL_COOLDOWN")]
        private static float GetSkillCooldown(SkillData skill)
        {
            float effective = skill.BasicCoolDown;
            //effective += GetAbilityAddSpendValue() ???

            // Check buffs
            // Not implemented

            effective = (float)(Math.Floor(effective) / 1000) * 1000;
            return effective;
        }

        // Incomplete
        [ClientScriptAttribute("SCR_GET_SKL_COOLDOWN_WIZARD")]
        private static float GetWizardSkillCooldown(SkillData skill)
        {
            var effective = skill.BasicCoolDown;
            
            if (effective < skill.MinCoolDown)
                return skill.MinCoolDown;

            return effective;
        }

        /// <summary>
        /// Returns the spend item base count.
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        [ClientScriptAttribute("SCR_GET_SPENDITEM_COUNT")]
        private static float GetSpendItemCount(SkillData skill)
        {
            return skill.SpendItemBaseCount;
        }

        // Incomplete
        [ClientScriptAttribute("SCR_GET_SKILLLV_WITH_BM")]
        private static float GetSkillLevelWithBM(SkillData skill)
        {
            // Get the fixed level

            if (skill.LevelByDB == 0)
                return 0;
            
            var result = skill.Level_BM + skill.LevelByDB;
            if (skill.GemLevel_BM > 0)
                result += 1;

            if (result < 1)
                return 1;

            return result;
        }

        //[ClientScriptAttribute("SCR_Get_SplRange")]
        //private static float GetSplRange(SkillData skill)
        //{

        //}
    }
}
