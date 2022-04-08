using AutoMapPins.Log;
using AutoMapPins.Services;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapPins.Patches
{
    /// <summary>
    /// Debugging commands for deleting pins and printing
    /// them to the console.
    /// </summary>
    public static class ChatCommandPatch
    {
        private const string DELETE = @"/bmpdelete";
        private const string SHOW_ALL_PINS = @"/bmpshowall";

        [HarmonyPatch(typeof(Chat), "InputText")]
        public class ChatPatchInputText
        {
            private static bool Prefix(Chat __instance)
            {
                string text = __instance.m_input.text;

                if (text != null)
                {
                    if (text.ToLower().Contains(DELETE))
                    {
                        string[] parts = text.Split(' ');
                        if (parts.Length > 1)
                        {
                            string pinName = parts[1].Trim();
                            PinService.RemovePinsByName(pinName);
                        }
                    }
                    else if (text == SHOW_ALL_PINS)
                    {
                        ShowPinsCommand();

                    }
                }

                return true;
            }
        }

        private static void ShowPinsCommand()
        {
            if (Traverse.Create(Minimap.instance).Field("m_pins").GetValue() is List<Minimap.PinData> pins)
            {
                foreach (var pin in pins)
                {
                    if (pin != null)
                    {
                        AutoMapPinsLogger.Debug("Pin ==============");
                        AutoMapPinsLogger.Debug($"Type: {pin.m_type}");
                        AutoMapPinsLogger.Debug($"Save: {pin.m_save}");
                        AutoMapPinsLogger.Debug($"Checked: {pin.m_checked}");

                        if (!string.IsNullOrEmpty(pin.m_name))
                        {
                            AutoMapPinsLogger.Debug($"Name: {pin.m_name}");
                        }

                        if (pin.m_nameElement != null)
                        {
                            AutoMapPinsLogger.Debug($"Name element: {pin.m_nameElement.text}");
                        }
                    }
                }
            }
        }
    }
}
