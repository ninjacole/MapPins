using AutoMapPins.Context;
using AutoMapPins.Models;
using System.Collections.Generic;


namespace AutoMapPins.Services
{
    /// <summary>
    /// Service for CRUD of PinRules.
    /// </summary>
    public static class PinRulesService
    {
        static PinRulesService()
        {
            PinRules = PinRulesContext.GetDefaultPinRules();
        }

        public static Dictionary<string, PinRule> PinRules { get; set; }

        public static PinRule GetPinRule(string name)
        {
            PinRules.TryGetValue(name, out PinRule rule);
            return rule;
        }
    }
}
