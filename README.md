# Cooler Stages Continued

Continuation of the original Cooler Stages since Nuxlar stopped development of the mod.

Currently a lot of the new DLC Stages are not yet included and the ones that are, are not as perfect as those by Nuxlar.
I might add/improve them if I have the time.

### SUBMIT ANY ISSUES USING THE LINK ABOVE

### USE v1.9.3 FOR DOWNPATCHED GAMES

Randomized, 9 material themes and 6 custom post processing profiles for stages 1-6, doesn't work on modded stages.

Configurable, can disable each custom post processing profile. Disabling all of the profiles will break the mod.

If you don't like the variant, `set_scene sceneName` (using the mod DebugToolkit) and it'll give a new randomized theme.

Stage materials and post process profile print to the console on stage load. `alt + ctrl + ~` to open the console

## Credits

[StageAesthetic](https://thunderstore.io/package/HIFU/StageAesthetic/) by HIFU

[Cooler Stages](https://github.com/Nuxlar/CoolerStages) by Nuxlar

## Screenshots

![dreary](https://i.ibb.co/9twGH5Z/cs1.png)

![fantasy](https://i.ibb.co/qdgw1kX/cs2.png)

![auburn](https://i.ibb.co/Rcd2WHM/cs3.png)

![winter](https://i.ibb.co/NWVnW4c/cs4.png)

![afternoon](https://i.ibb.co/kyyT4SL/verdant.png)

## Changelog

**2.2.4**

- Add the option to turn off specific textures

**2.2.0**

- Add Helminth Hatchery to the available stages. Also includes option to switch it off.

**2.1.0**

- Sync Randomization for Multiplayer

**2.0.0**

- Fix for SoTS
- Does not modify a lot of the new Stages

**1.9.3**

- Small tweaks to some post processing profiles
- Adds "Verdant" material theme
- Removes "Scorched" material theme

**1.9.2**

- Reduces red on Auburn profile
- Reduces pink on Fantasy profile
- Reduces skybox visibility on Auburn profile
- Increases light intensity on some stages

**1.9.1**

- Tweaked profiles to stand out more from each other
- Added config for disabling profiles

**1.9.0**

- Removed vanilla post processing themes
- Removed Sky Meadow material theme
- Removed grass from stages
- Added Verdant Falls to list
- Added Void Sky Meadow material theme
- Added 6 custom post processing profiles
- Re-did dynamic lighting
- Fixed material applying to moon godrays

**1.8.3**

- Removes a bunch of post process themes that made the lighting not great
- Adds a sky meadow material theme
- Removes jungle theme

**1.8.2**

- Changes light color brightening to be less aggressive (shouldn't have neon-esque light colors)
- Increases sun light brightness on certain materials
- Changes "Void Abyssal" gold material to something less offensive to the eyes

**1.8.1**

- Fixes modded/non-whitelisted maps not spawning interactables

**1.8.0**

- Removes/Replaces post processing profiles that were causing darker stages
- Removes 1 material theme (Locus) because the terrain was wonky
- Enhances color lightening method
- Adds conditions to account for specific materials/post processing causing darker stages
- Fixes certain stages accounting for wrong terrain material

**1.7.0**

- Adds ambient lighting that matches dynamic color
- Increases brighten threshold on darkness check
- Re-Fixes moon fog having terrain material (phantom walls at mass)
- Replaces README photos

**1.6.3**

- Changes "Scorched" terrain material to one that's less monotone
- Changes Abyssal material matching
- Fixes "Void Meadow" tree material
- Fixes Abyssal being dark a lot of the time
- Fixes moon material matching not applying to everything (soul pillar ramp)
- Adds check that brightens darker light colors
- Adds Abyssal Lighting, cave crystals and prop lights now match the dynamic sun color
- Brightens moon slightly
- Removes moon escape sequence post processing

**1.6.2**

- Adds new material theme "Bazaar"
- Changes Acres' and Aphelian's ambient lighting to be more neutral
- Changes Acres' and Aphelian's lighting value to be closer to the post processing
- Changes lighting to be flat values (prevent BRIGHT stages)
- Changes a material in Void Abyssal's theme
- Fixes Aphelian's wonky materials

**1.6.1**

- Enhances dynamic lighting to prevent dark stages (thanks Lawlzee)
- Removes ambient lighting (no longer needed)

**1.6.0**

- Adds dynamic lighting that matches the post process profile
- Adds ambient lighting to _try_ and prevent darker stages
- Removes unused R2API dependency and skybox code

**1.5.0**

- Adds "randomized" themes
- Adds themes to Moon2 stage
- Adds new icon
- Removes predefined themes

**1.0.4**

- Makes orange variant less orange
- Makes void stages less bright
- Swaps void rock and ruin materials on sundered grove

**1.0.3**

- Fixes "mod not working" bug

**1.0.2**

- Fixes _the ring_
- Fixes incompats (Desolate Reef)
- Reduces Ruin shadow strength
- Change rock material for Scorched
- Changes tree material for Scorched
- Change rock material for Void

**1.0.1**

- Removes planets from Scorched skybox
- Fixes occasional crashes
- Fixes terrain fog on Pools
- Aphelian changes to look better
- Changes void rock material
- Other slight fixes/tweaks for better looking themes

**1.0.0**

- Release
