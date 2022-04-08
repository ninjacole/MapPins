using AutoMapPins.Log;
using AutoMapPins.Models;
using AutoMapPins.Services;
using HarmonyLib;

namespace AutoMapPins.Patches
{
    /// <summary>
    /// Patch which adds a pin for a dungeon when
    /// hovering over the entrance.
    /// </summary>
    [HarmonyPatch(typeof(Teleport))]
    public class DungeonPatch
    {
        [HarmonyPatch(nameof(Teleport.GetHoverText))]
        public static void Prefix(Teleport __instance)
        {
            AutoMapPinsLogger.Debug(__instance.m_enterText);

            PinRule rule = PinRulesService.GetPinRule(__instance.m_enterText);

            if (rule != null)
            {
                PinService.AddPin(__instance.transform.position, rule);
            }
        }
    }
}
