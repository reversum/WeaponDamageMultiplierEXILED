using Exiled.API.Interfaces;
using MapGeneration.Distributors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace HitboxWeaponDamageMultiplier
{
	public sealed class Config : IConfig
	{
		[Description("Whether the plugin is enabled.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Enable debug logs.")]
		public bool Debug { get; set; } = false;

		[Description("Default multipliers used if no weapon-specific multipliers are defined.")]
		public Dictionary<string, float> DefaultMultipliers { get; set; } = new Dictionary<string, float>()
		{
			{ "headshot", 1.0f },
			{ "body", 1.0f },
			{ "limb", 1.0f },
		};

		[Description("Weapon-specific damage multipliers per hitbox.")]
		public Dictionary<string, Dictionary<string, float>> WeaponMultipliers { get; set; } =
			new Dictionary<string, Dictionary<string, float>>()
		{
			{ "GunCOM15", new Dictionary<string, float>()
				{
					{ "headshot", 3.0f },
					{ "body", 1.0f },
					{ "limb", 0.8f },
				}
			},
			{ "GunE11SR", new Dictionary<string, float>()
				{
					{ "headshot", 3.0f },
					{ "body", 1.0f },
					{ "limb", 0.8f },
				}
			}
		};
	}
}
