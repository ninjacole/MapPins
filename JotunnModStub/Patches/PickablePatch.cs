using AutoMapPins.Log;
using AutoMapPins.Models;
using AutoMapPins.Services;
using HarmonyLib;

namespace AutoMapPins.Patches
{
    /// <summary>
    /// Pickable patch which adds pins when hovering over known and
    /// configured pickable types.
    /// </summary>
    [HarmonyPatch(typeof(Pickable), nameof(Pickable.GetHoverName))]
    public class PickablePatch
    {
        private static void Prefix(ref Pickable __instance)
        {
            AutoMapPinsLogger.Debug(__instance.name);
            PinRule rule = PinRulesService.GetPinRule(__instance.name);

            if (rule != null)
            {
                PinService.AddPin(__instance.transform.position, rule);
            }
        }
    }
}
