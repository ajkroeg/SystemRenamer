using System;
using System.Collections.Generic;
using BattleTech;
using BattleTech.StringInterpolation;

namespace SystemRenamer
{
    public class SystemRenamer
    {
        public class RenamerConfig
        {
            public string TargetSystem;
            public string RenamerName;
        }

        [HarmonyPatch(typeof(BattleTech.SimGameState), "ApplySimGameEventResult", new Type[]{typeof(SimGameEventResult), typeof(List<object>), typeof(SimGameEventTracker)})]
        public static class SimGameState_ApplySimGameEventResult
        {
            public static void Postfix(SimGameEventResult result, List<object> objects, SimGameEventTracker tracker = null)
            {
                var sim = UnityGameInstance.BattleTechGame.Simulation;
                if (sim == null) return;
                if (result?.AddedTags == null) return;
                if (result.Scope != EventScope.Company) return;
                foreach (var tag in result.AddedTags)
                {
                    if (ModInit.Settings.RenamerConfigs.TryGetValue(tag, out var config))
                    {
                        StarSystem modSystem = sim.StarSystems.Find(starSystem => starSystem.Def.CoreSystemID == config.TargetSystem);
                        var parsedText = Interpolator.Interpolate(config.RenamerName, sim.Context, true);
                        modSystem.Name = parsedText;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(SimGameState), "Rehydrate")]
        public static class SimGameState_Rehydrate_Patch
        {
            public static void Postfix(SimGameState __instance)
            {
                foreach (var companyTag in __instance.companyTags)
                {
                    if (ModInit.Settings.RenamerConfigs.TryGetValue(companyTag, out var config))
                    {
                        StarSystem modSystem = __instance.StarSystems.Find(starSystem => starSystem.Def.CoreSystemID == config.TargetSystem);
                        var parsedText = Interpolator.Interpolate(config.RenamerName, __instance.Context, true);
                        modSystem.Name = parsedText;
                    }
                }
            }
        }
    }
}
