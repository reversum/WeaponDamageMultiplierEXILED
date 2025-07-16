using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using PlayerStatsSystem;
using System;
using System.Collections.Generic;

namespace HitboxWeaponDamageMultiplier
{
	public class Main : Plugin<Config>
	{
		public override string Name => "WeaponDamageMultiplier";
		public override string Author => "YannikAufDie1";
		public override PluginPriority Priority { get; } = PluginPriority.Last;
		public override void OnEnabled()
		{
			Exiled.Events.Handlers.Player.Hurting += OnHurting;
			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Player.Hurting -= OnHurting;
			base.OnDisabled();
		}

		private void OnHurting(HurtingEventArgs ev)
		{
			if (!ev.IsAllowed || ev.Attacker == null) return;

			if (ev.Attacker.IsScp && !Config.DamageSCPs) return;

			string weaponName = GetWeaponName(ev);

			if (Config.Debug)
			{
				Log.Debug($"[DEBUG] Weaponname: {weaponName}");
			}

			StandardDamageHandler standardDamageHandler = (StandardDamageHandler)ev.DamageHandler;
			string hitbox = standardDamageHandler.Hitbox.ToString().ToLower();

			Dictionary<string, float> multipliers = Config.DefaultMultipliers;

			if (Config.WeaponMultipliers.ContainsKey(weaponName))
			{
				multipliers = Config.WeaponMultipliers[weaponName];
			}

			float multiplier = multipliers.ContainsKey(hitbox) ? multipliers[hitbox] : 1.0f;

			if (multiplier != 1.0f)
			{
				float oldDamage = ev.Amount;
				ev.Amount *= multiplier;

				if (Config.Debug)
				{
					Log.Debug($"[DEBUG] {ev.Attacker.Nickname} → {ev.Player.Nickname} | Weapon: {weaponName}, Hitbox: {hitbox}, Multiplier: x{multiplier}, Damage: {oldDamage} → {ev.Amount}");
				}
			}
		}

		private string GetWeaponName(HurtingEventArgs ev)
		{
			if (ev.Attacker.CurrentItem is Firearm firearm)
				return firearm.Type.ToString();
			else if (ev.Attacker.Role.Team == Team.SCPs)
				return ev.Attacker.Role.Type.ToString();
			else
				return "Unknown";
		}
	}
}
