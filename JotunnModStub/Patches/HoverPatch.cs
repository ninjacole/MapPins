using AutoMapPins.Models;
using AutoMapPins.Services;
using HarmonyLib;
using System;
using UnityEngine;

namespace AutoMapPins.Patches
{
    /// <summary>
    /// HoverText patch which adds pins when hovering over
    /// configured and known types of destructible objects.
    /// </summary>
    [HarmonyPatch(typeof(HoverText), nameof(HoverText.GetHoverText))]
    public class HoverPatch
    {
        private static void Prefix(ref HoverText __instance)
        {
            //BmpLogger.Debug(__instance.m_text);
            PinRule rule = PinRulesService.GetPinRule(__instance.m_text);

            if (rule != null)
            {
                Destructible des = __instance.GetComponent<Destructible>();
                Vector3 position = des.transform.position;
                PinService.AddPin(position, rule);
            }
        }
    }
}
