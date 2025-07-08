// --- File: Patches/WeaponPosePatch.cs ---
using Core;
using HarmonyLib;
using UnityEngine;

namespace SPTStances.Patches
{
    [HarmonyPatch(typeof(EFT.Animations.ProceduralWeaponAnimation), "Update")]
    public class WeaponPosePatch
    {
        private static WeaponStance _lastStance = WeaponStance.Default;
        private static Vector3 _basePosition;
        private static Quaternion _baseRotation;

        static void Postfix(EFT.Animations.ProceduralWeaponAnimation __instance)
        {
            if (__instance?.HandsContainer?.WeaponRoot == null)
                return;

            if (StanceController.CurrentStance != _lastStance)
            {
                _basePosition = __instance.HandsContainer.WeaponRoot.localPosition;
                _baseRotation = __instance.HandsContainer.WeaponRoot.localRotation;
                _lastStance = StanceController.CurrentStance;
            }

            Vector3 stanceOffset = Vector3.zero;
            Quaternion stanceRotation = Quaternion.identity;

            switch (StanceController.CurrentStance)
            {
                case WeaponStance.HighReady:
                    stanceOffset = new Vector3(0f, 0.08f, -0.05f);
                    stanceRotation = Quaternion.Euler(10f, 0f, 0f);
                    break;
                case WeaponStance.LowReady:
                    stanceOffset = new Vector3(0f, -0.05f, -0.02f);
                    stanceRotation = Quaternion.Euler(-5f, 0f, 0f);
                    break;
                case WeaponStance.Compressed:
                    stanceOffset = new Vector3(0f, -0.1f, -0.08f);
                    stanceRotation = Quaternion.Euler(0f, 0f, 10f);
                    break;
                case WeaponStance.Default:
                    __instance.HandsContainer.WeaponRoot.localPosition = _basePosition;
                    __instance.HandsContainer.WeaponRoot.localRotation = _baseRotation;
                    return;
                default:
                    return;
            }

            __instance.HandsContainer.WeaponRoot.localPosition = _basePosition + stanceOffset;
            __instance.HandsContainer.WeaponRoot.localRotation = _baseRotation * stanceRotation;
        }
    }
}