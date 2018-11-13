using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Buildings
{
    class Farm : Building
    {
        public Farm(Town town) : base(town)
        {
            this.Name = "Farma";

            this.Properties = new BuildingProperties()
            {
                WoodCost = 2,
                Food = 4,
            };

            MaxPeople = 5;
        }
    }
}
