# DBH Spring Water Patch

A small compatibility patch that makes Hot Springs and Healing Springs work with Dubs Bad Hygiene.

## What it does

Makes these terrain types usable as clean water sources:
- **Hot Springs** (from Odyssey DLC)  
- **Healing Springs** (from Alpha Biomes mod)

Your pawns can now drink from and wash in these special water features without getting sick.

## Requirements

- [Dubs Bad Hygiene](https://steamcommunity.com/sharedfiles/filedetails/?id=836308268)
- Odyssey DLC (for hot springs)
- Alpha Biomes mod (for healing springs)

The patch works fine if you only have one of the DLCs/mods - it'll just add support for whichever terrain types are available.

## Installation

1. Download the mod
2. Put it in your RimWorld mods folder
3. Load it **after** Dubs Bad Hygiene in your mod list

## Why this was needed

By default, DBH only recognizes vanilla water terrains. The special spring types from Odyssey and Alpha Biomes weren't tagged properly, so pawns would ignore them even when thirsty or dirty.

This patch hooks into DBH's water detection system and adds the missing terrain types as clean water sources.

## Technical stuff

Uses a simple Harmony postfix on `SetWaterCellsCache` to mark spring terrains as clean water in DBH's area grids. Pretty straightforward - no compatibility issues expected.

## Issues?

If you run into problems, check that:
- DBH is loading before this patch
- You have the DLCs/mods that add the spring types you want to use

Otherwise feel free to report bugs.