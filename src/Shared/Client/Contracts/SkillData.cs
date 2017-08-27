// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Newtonsoft.Json.Linq;
using System;

namespace Melia.Shared.Data
{
	[Serializable]
	public class SkillData
	{
		public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string EngName { get; set; }
        public int BasicCoolDown { get; set; }
        public int BasicSP { get; set; }
        public int CancelTime { get; set; }
        public string CoolDown { get; set; }
        public int DeadHitDelay { get; set; }
        public int EnableAngle { get; set; }
        public int KDownHAngle { get; set; }
        public int KDownValue { get; set; }
        public int KDRank { get; set; }
        public int KnockDownHitType { get; set; }
        public int LvUpSpendSp { get; set; }
        public int MaxRValue { get; set; }
        public int MinCoolDown { get; set; }
        public int OverHeatDelay { get; set; }
        public int ReadyFix { get; set; }
        public string ReadyTime { get; set; }
        public int ShootTime { get; set; }
        public int SklAtkAddByLevel { get; set; }
        public int SklFactorByLevel { get; set; }
        public int SklHitCount { get; set; }
        public int SklSplAngle { get; set; }
        public int SklSplRange { get; set; }
        public int SklSR { get; set; }
        public int SklUseOverHeat { get; set; }
        public int SklWaveLength { get; set; }
        public int SpendHP { get; set; }
        public int SpendItemBaseCount { get; set; }
        public string SpendItemCount { get; set; }
        public int SplHeight { get; set; }
        public string SplType { get; set; }
        public string Level { get; set; }
        public int LevelByDB { get; set; }
        public int Level_BM { get; set; }
        public int GemLevel_BM { get; set; }
    }

	public enum SplashType
	{
		Square,
		Circle,
		Fan,
	}
}
