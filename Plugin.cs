using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace SPTStances
{
    [BepInPlugin("com.specter.sptstances", "SPT Stances", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        public static BepInEx.Configuration.ConfigEntry<KeyCode> ToggleKeybind;

        private void Awake()
        {
            Log = Logger;

            // Create config entry (user-configurable via F12 in SPT)
            ToggleKeybind = Config.Bind(
                "Controls",
                "ToggleStanceKey",
                KeyCode.Y,
                "Key to cycle between weapon stances."
            );

            // Create default config.json if it doesn't exist
            string configDir = Path.Combine(BepInEx.Paths.ConfigPath, "SPTStances");
            string configPath = Path.Combine(configDir, "config.json");

            ConfigHandler.CheckConfig(configPath, Log);

            if (!File.Exists(configPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configPath));
                var defaultConfig = new
                {
                    enableStances = true,
                    defaultStance = "Default",
                    multipliers = new
                    {
                        HighReady = new { sway = 0.8, ergo = 1.1 },
                        LowReady = new { sway = 0.6, ergo = 0.9 },
                        Compressed = new { sway = 0.5, ergo = 0.75 },
                        Default = new { sway = 1.0, ergo = 1.0 }
                    }
                };

                File.WriteAllText(configPath, JsonConvert.SerializeObject(defaultConfig, Newtonsoft.Json.Formatting.Indented));
                Log.LogInfo($"Created default config at {configPath}");
            }

            Log.LogInfo("=== SPT-Stances Mod Initialized ===");

            var harmony = new Harmony("com.specter.sptstances");
            harmony.PatchAll();
        }
    }
}