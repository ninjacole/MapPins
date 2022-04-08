using System.ComponentModel;

namespace AutoMapPins.Context
{
    public enum PinOptions
    {
        [Description("Campfire Icon")]
        Icon0 = Minimap.PinType.Icon0,
        [Description("House Icon")]
        Icon1 = Minimap.PinType.Icon1,
        Icon2 = Minimap.PinType.Icon2,
        [Description("Circle Icon")]
        Icon3 = Minimap.PinType.Icon3,
    }
}
