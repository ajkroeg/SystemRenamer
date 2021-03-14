using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using BattleTech;
using HBS;
using HBS.Collections;
using BattleTech.Save;
using Org.BouncyCastle.Security;
using BattleTech.Common;
using BattleTech.Serialization;

namespace SystemRenamer
{
    class SystemRenamer
    {

        [HarmonyPatch(typeof(BattleTech.SimGameState), "OnDayPassed")]

        public static class OnDayPassed_Patch
        {
            public static void Postfix(SimGameState __instance, int timeLapse)
            {
                if (__instance.CompanyTags.Contains(ModInit.Settings.TriggerTag1))
                {
                    StarSystem modSystem = __instance.StarSystems.Find(StarSystem => StarSystem.Name == ModInit.Settings.TargetSystemName);
                    Traverse.Create(modSystem).Property("Name").SetValue(__instance.Commander.LastName+"'s Hole");
                }
            }
        }
    }
}
