// --- File: StanceController.cs ---
using UnityEngine;

namespace SPTStances.Core
{
    public enum WeaponStance
    {
        Default,
        HighReady,
        LowReady,
        Compressed
    }

    public class StanceController : MonoBehaviour
    {
        public static WeaponStance CurrentStance = WeaponStance.Default;

        public static void CycleStance()
        {
            CurrentStance = (WeaponStance)(((int)CurrentStance + 1) % System.Enum.GetValues(typeof(WeaponStance)).Length);
            Debug.Log($"[SPT-Stances] Switched to stance: {CurrentStance}");
        }

        public static float GetStanceSwayMultiplier()
        {
            return CurrentStance switch
            {
                WeaponStance.HighReady => 0.8f,
                WeaponStance.LowReady => 0.6f,
                WeaponStance.Compressed => 0.5f,
                _ => 1.0f
            };
        }

        public static float GetStanceErgoMultiplier()
        {
            return CurrentStance switch
            {
                WeaponStance.HighReady => 1.1f,
                WeaponStance.LowReady => 0.9f,
                WeaponStance.Compressed => 0.75f,
                _ => 1.0f
            };
        }
    }
}