using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

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
//            var harmony = HarmonyInstance.Create(HarmonyPackage);
//            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), HarmonyPackage);
        }

    }
    public class SystemRenamerSettings
    {
        public Dictionary<string, SystemRenamer.RenamerConfig> RenamerConfigs =
            new Dictionary<string, SystemRenamer.RenamerConfig>(); //key is trigger key ID. Renamer Names should parse like normal simgametext?
        //public string TriggerTag1 = "Pirate_Lord";
        //public string TargetSystemName = "Rezak's Hole";

    }
}