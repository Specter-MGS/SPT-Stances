using System.IO;
using Newtonsoft.Json;
using BepInEx.Logging;

namespace SPTStances
{
    public static class ConfigHandler
    {
        public static void CheckConfig(string configPath, ManualLogSource log)
        {
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

                File.WriteAllText(configPath, JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
                log.LogInfo($"[SPTStances] Created default config at: {configPath}");
            }
        }
    }
}