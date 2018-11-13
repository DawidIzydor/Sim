using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    class BuildingProperties
    {
        public int Housing { get; set; } = 0;
        public int Wood { get; set; } = 0;
        public int Gold { get; set; } = 0;
        public int Iron { get; set; } = 0;

        public int Food { get; set; } = 0;

        public int WoodCost { get; set; } = 0;
        public int GoldCost { get; set; } = 0;
        public int IronCost { get; set; } = 0;

        public int FoodCost { get; set; } = 0;

        public int BuildingTime { get; set; } = 1;
    }
}
