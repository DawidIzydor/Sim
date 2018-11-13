using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Buildings
{
    class Mine : Building
    {
        public Mine(Town town) : base(town)
        {
            this.Name = "Kopalnia";

            this.Properties = new BuildingProperties()
            {
                Iron = 1,
                WoodCost = 8
            };

            this.MaxPeople = 3;
        }
    }
}
