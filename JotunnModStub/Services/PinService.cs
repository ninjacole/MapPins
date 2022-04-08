using AutoMapPins.Log;
using AutoMapPins.Models;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutoMapPins.Services
{
    /// <summary>
    /// Service for managing minimap pins.
    /// </summary>
    public class PinService
    {
        public static List<Minimap.PinData> GetPins()
        {
            return Traverse.Create(Minimap.instance).Field("m_pins").GetValue() as List<Minimap.PinData>;
        }

        public static Minimap.PinData GetPin(Vector3 position, PinRule rule)
        {
            Minimap.PinData foundPin = null;

            List<Minimap.PinData> pins = GetPins();

            if (pins != null && position != null)
            {
                foreach (var pin in pins)
                {
                    bool sameText = Equals(pin.m_name, rule.Text);
                    float distance = Vector3.Distance(position, pin.m_pos);

                    if (sameText && distance < rule.ClusterRadius)
                    {
                        foundPin = pin;
                        break;
                    }
                }
            }

            return foundPin;
        }

        public static void AddPin(Vector3 position, PinRule rule)
        {
            Minimap.PinData pin = GetPin(position, rule);

            if (pin == null)
            {
                Minimap.instance.AddPin(position, rule.PinType, rule.Text, true, false);
            }
        }

        public static void RemovePin(Vector3 position, PinRule rule)
        {
            Minimap.PinData pin = GetPin(position, rule);
            Minimap.instance.RemovePin(pin);
        }

        public static void RemovePinsByName(string name)
        {
            AutoMapPinsLogger.Debug($"Deleting pins with name: [{name}]");

            List<Minimap.PinData> pins = GetPins();
            var copy = new List<Minimap.PinData>(pins.Where(x => x.m_name == name));
            foreach (var pin in copy)
            {
                Minimap.instance.RemovePin(pin);
            }
        }
    }
}
