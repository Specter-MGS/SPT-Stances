using HarmonyLib;
using UnityEngine;

namespace SPTStances.Patches
{
    [HarmonyPatch(typeof(EFT.Animations.ProceduralWeaponAnimation), "Update")]
    public class WeaponPosePatch
    {
        static void Postfix(EFT.Animations.ProceduralWeaponAnimation __instance)
        {
            if (__instance?.HandsContainer?.WeaponRoot == null)
                return;

            // Base values
            Vector3 stanceOffset = Vector3.zero;
            Quaternion stanceRotation = Quaternion.identity;

            switch (SPTStances.StanceController.CurrentStance)
            {
                case SPTStances.WeaponStance.HighReady:
                    stanceOffset = new Vector3(0f, 0.08f, -0.05f);
                    stanceRotation = Quaternion.Euler(10f, 0f, 0f);
                    break;
                case SPTStances.WeaponStance.LowReady:
                    stanceOffset = new Vector3(0f, -0.05f, -0.02f);
                    stanceRotation = Quaternion.Euler(-5f, 0f, 0f);
                    break;
                case SPTStances.WeaponStance.Compressed:
                    stanceOffset = new Vector3(0f, -0.1f, -0.08f);
                    stanceRotation = Quaternion.Euler(0f, 0f, 10f);
                    break;
                case SPTStances.WeaponStance.Default:
                default:
                    return; // Don't offset in Default stance
            }

            __instance.HandsContainer.WeaponRoot.localPosition += stanceOffset;
            __instance.HandsContainer.WeaponRoot.localRotation *= stanceRotation;
        }
    }
}