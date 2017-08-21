// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Newtonsoft.Json.Linq;
using System;

namespace Melia.Shared.Data
{
	[Serializable]
	public class SkillData
	{
		public int SkillId { get; set; }
		public string ClassName { get; set; }
		public string EngName { get; set; }

		public float Angle { get; set; }
		public float MaxRange { get; set; }
		public float WaveLength { get; set; }

		public SplashType SplashType { get; set; }
		public float SplashRange { get; set; }
		public float SplashHeight { get; set; }
		public float SplashAngle { get; set; }
		public float SplashRate { get; set; }
	}

	public enum SplashType
	{
		Square,
		Circle,
		Fan,
	}
}
