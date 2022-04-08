using AutoMapPins.Models;
using System.Collections.Generic;

namespace AutoMapPins.Context
{
    /// <summary>
    /// Handles storage and defaults for pin rules.
    /// </summary>
    public class PinRulesContext
    {
        public const string TIN = "$piece_deposit_tin";
        public const string COPPER = "$piece_deposit_copper";
        public const string OBSIDIAN = "$piece_deposit_obsidian";
        public const string SILVER = "$piece_deposit_silver";
        public const string SILVER_VEIN = "$piece_deposit_silvervein";

        public const string FOREST_DUNGEON = "$location_forestcrypt";
        public const string TROLL_CAVE = "$location_forestcave";

        public const string RASPBERRY_BUSH = "RaspberryBush(Clone)";
        public const string BLUEBERRY_BUSH = "BlueberryBush(Clone)";

        public const string MUSHROOM = "Pickable_Mushroom(Clone)";
        public const string THISTLE = "Pickable_Thistle(Clone)";

        public const string CARROT = "Pickable_SeedCarrot(Clone)";
        public const string DANDIES = "Pickable_Dandelion(Clone)";

        private static void AddRule(Dictionary<string, PinRule> dict, string name, string text, Minimap.PinType pinType)
        {
            var rule = new PinRule
            {
                ClusterRadius = 15f,
                IsEnabled = true,
                Name = name,
                PinType = pinType,
                Text = text
            };

            dict.Add(name, rule);
        }

        public static Dictionary<string, PinRule> GetDefaultPinRules()
        {
            var dict = new Dictionary<string, PinRule>();

            Minimap.PinType orePin = (Minimap.PinType)Bmp.orePinType.Value;
            Minimap.PinType pickPin = (Minimap.PinType)Bmp.pickablePinType.Value;
            Minimap.PinType cavePin = (Minimap.PinType)Bmp.cavePinType.Value;

            AddRule(dict, TIN, Bmp.tinText.Value, orePin);
            AddRule(dict, COPPER, Bmp.copperText.Value, orePin);
            AddRule(dict, OBSIDIAN, Bmp.obsidianText.Value, orePin);
            AddRule(dict, SILVER, Bmp.silverText.Value, orePin);
            AddRule(dict, SILVER_VEIN, Bmp.silverText.Value, orePin);

            AddRule(dict, RASPBERRY_BUSH, Bmp.raspberryBushText.Value, pickPin);
            AddRule(dict, BLUEBERRY_BUSH, Bmp.blueberryBushText.Value, pickPin);
            AddRule(dict, MUSHROOM, Bmp.mushroomText.Value, pickPin);
            AddRule(dict, CARROT, Bmp.carrotText.Value, pickPin);
            AddRule(dict, THISTLE, Bmp.thistleText.Value, pickPin);
            AddRule(dict, DANDIES, Bmp.dandyText.Value, pickPin);

            AddRule(dict, FOREST_DUNGEON, Bmp.forestDungeonText.Value, cavePin);
            AddRule(dict, TROLL_CAVE, Bmp.trollCaveText.Value, cavePin);

            return dict;
        }
    }
}
