using HarmonyLib;
using EFT.Animations;

namespace SPTStances.Patches
{
    [HarmonyPatch(typeof(ProceduralWeaponAnimation), nameof(ProceduralWeaponAnimation.UpdateSway))]
    public class WeaponSwayPatch
    {
        static void Prefix(ProceduralWeaponAnimation __instance)
        {
            // Modify sway strength by current stance multiplier
            __instance.SwayFalloff *= StanceController.GetStanceSwayMultiplier();
            __instance.SwayIntensity *= StanceController.GetStanceSwayMultiplier();
        }
    }

    [HarmonyPatch(typeof(ProceduralWeaponAnimation), nameof(ProceduralWeaponAnimation.SetErgonomicWeight))]
    public class WeaponErgoPatch
    {
        static void Prefix(ref float ergonomicWeight)
        {
            ergonomicWeight *= StanceController.GetStanceErgoMultiplier();
        }
    }
}