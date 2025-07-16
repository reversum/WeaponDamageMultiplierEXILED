# WeaponDamageMultiplier
 Allows to add a damage multiplier to specific guns & bones
## Config
```
# Whether the plugin is enabled.
is_enabled: true
# Enable debug logs.
debug: false
# Enables/Disables if a human should also give the SCPs more damage.
damage_s_c_ps: false
# Default multipliers used if no weapon-specific multipliers are defined.
default_multipliers:
  headshot: 1
  body: 1
  limb: 1
# Weapon-specific damage multipliers per hitbox.
weapon_multipliers:
  GunCOM15:
    headshot: 3
    body: 1
    limb: 0.800000012
  GunE11SR:
    headshot: 3
    body: 1
    limb: 0.800000012
```
