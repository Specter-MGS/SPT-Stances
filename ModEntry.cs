// SPT-Stances Mod - Entry Point
using BepInEx;
using HarmonyLib;

namespace SPTStances
{
    [BepInPlugin("com.graham.spt.stances", "SPT-Stances", "1.0.0")]
    public class ModEntry : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("SPT-Stances Mod Loaded");
            var harmony = new Harmony("com.graham.spt.stances");
            harmony.PatchAll();

            // Add input listener
            gameObject.AddComponent<StanceInput>();
        }
    }
}