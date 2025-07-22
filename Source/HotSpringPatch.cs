using System.Reflection;
using HarmonyLib;
using Verse;
using DubsBadHygiene;

namespace DBHSpringWaterPatch
{
    [StaticConstructorOnStartup]
    public static class SpringWaterPatcher
    {
        static SpringWaterPatcher()
        {
            var harmony = new Harmony("azrazalea.dbh.springwater.patch");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(MapComponent_Hygiene), "SetWaterCellsCache")]
    public static class SetWaterCellsCachePatch
    {
        private static readonly MethodInfo areaSetMethod = typeof(Area).GetMethod("Set", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        public static void Postfix(MapComponent_Hygiene __instance, IntVec3 c)
        {
            TerrainDef terrain = c.GetTerrain(__instance.map);
            
            if (terrain?.defName == "HotSpring" || terrain?.defName == "AB_HealingSpringwater")
            {
                areaSetMethod?.Invoke(__instance.cleanWater, new object[] { c, true });
                areaSetMethod?.Invoke(__instance.dirtyWater, new object[] { c, false });
                areaSetMethod?.Invoke(__instance.oceanWater, new object[] { c, false });
            }
        }
    }
}