# WeaponDamageMultiplier
 Allows to add a damage multiplier to specific guns & bones
## Config
```
# Whether the plugin is enabled.
is_enabled: true
# Enable debug logs.
debug: true
# Default multipliers used if no weapon-specific multipliers are defined.
default_multipliers:
  headshot: 1
  body: 1
  limb: 1
# Weapon-specific damage multipliers per hitbox.
weapon_multipliers:
  GunCOM15:
    headshot: 2
    body: 1
    limb: 0.899999976
  GunE11SR:
    headshot: 3
    body: 1
    limb: 0.899999976
```
