using AutoMapPins.Context;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace AutoMapPins
{
    /// <summary>
    /// Startup class registers harmony patches and sets
    /// up the harmony project to work with unity.
    /// </summary>
    [BepInPlugin(PROJECT_GUID, "Auto Map Pins", "1.0.0")]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Bmp : BaseUnityPlugin
    {
        private const string PROJECT_GUID = "724F3A51-4D24-4A4A-AB39-202BB53EF1F6";
        private readonly Harmony harmony;

        public static ConfigEntry<string> tinText;
        public static ConfigEntry<string> copperText;
        public static ConfigEntry<string> obsidianText;
        public static ConfigEntry<string> silverText;
        public static ConfigEntry<string> forestDungeonText;
        public static ConfigEntry<string> trollCaveText;
        public static ConfigEntry<string> raspberryBushText;
        public static ConfigEntry<string> blueberryBushText;
        public static ConfigEntry<string> mushroomText;
        public static ConfigEntry<string> thistleText;
        public static ConfigEntry<string> carrotText;
        public static ConfigEntry<string> dandyText;

        public static ConfigEntry<PinOptions> orePinType;
        public static ConfigEntry<PinOptions> pickablePinType;
        public static ConfigEntry<PinOptions> cavePinType;

        /// <summary>
        /// Called by the unity engine.
        /// </summary>
        void Awake()
        {
            // Uses reflection to find your methods decorated with the HarmonyPatch attribute.
            // Harmony applies your decorated methods to prefix/postfix operations on the methods
            // you are affecting in valheim.
            harmony.PatchAll();

            string iconSection = "1- Icons";
            string caveSection = "2- Cave labels";
            string oreSection = "3- Ore labels";
            string pickupSection = "4- Pickup labels";

            cavePinType = Config.Bind(iconSection, "Cave", PinOptions.Icon0);
            orePinType = Config.Bind(iconSection, "Ore", PinOptions.Icon3);
            pickablePinType = Config.Bind(iconSection, "Pickup", PinOptions.Icon3);

            forestDungeonText = Config.Bind(caveSection, "Forest Dungeon", "Forest Dungeon");
            trollCaveText = Config.Bind(caveSection, "Troll Cave", "Troll Cave");

            copperText = Config.Bind(oreSection, "Copper", "Copper");
            tinText = Config.Bind(oreSection, "Tin", "Tin");
            obsidianText = Config.Bind(oreSection, "Obsidian", "Obsidian");
            silverText = Config.Bind(oreSection, "Silver", "Silver");

            raspberryBushText = Config.Bind(pickupSection, "Raspberry Bush", "Rasp");
            blueberryBushText = Config.Bind(pickupSection, "Blueberry Bush", "Blue");
            mushroomText = Config.Bind(pickupSection, "Red Mushroom", "Red Shrooms");
            thistleText = Config.Bind(pickupSection, "Thistle", "Thistle");
            carrotText = Config.Bind(pickupSection, "Carrot", "Carrots");
            dandyText = Config.Bind(pickupSection, "Dandelion", "Dandies");
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        public Bmp()
        {
            harmony = new Harmony(PROJECT_GUID);
        }
    }
}