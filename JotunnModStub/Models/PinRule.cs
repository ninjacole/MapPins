using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapPins.Models
{
    /// <summary>
    /// Describes configurable options for how
    /// pins will be added automatically.
    /// </summary>
    public class PinRule
    {
        public string Text { get; set; }

        public Minimap.PinType PinType { get; set; }

        public float ClusterRadius { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; set; }
    }
}
