using Harmony;
using System;
using System.Reflection;
using Newtonsoft.Json;
using BattleTech.UI;
using BattleTech;
using System.Diagnostics.Eventing.Reader;

namespace SystemRenamer
{

    public static class ModInit
    {
        public static SystemRenamerSettings Settings = new SystemRenamerSettings();
        public const string HarmonyPackage = "us.tbone.SystemRenamer";
        public static void Init(string directory, string settingsJSON)
        {
            try
            {
                ModInit.Settings = JsonConvert.DeserializeObject<SystemRenamerSettings>(settingsJSON);
            }
            catch (Exception)
            {
                ModInit.Settings = new SystemRenamerSettings();
            }
            var harmony = HarmonyInstance.Create(HarmonyPackage);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }
    public class SystemRenamerSettings
    {
        public string TriggerTag1 = "Pirate_Lord";
        public string TargetSystemName = "Rezak's Hole";

    }
}