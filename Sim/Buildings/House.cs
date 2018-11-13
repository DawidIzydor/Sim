using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Buildings
{
    class House : Building
    {
        public House(Town town) : base(town)
        {
            this.Name = "Dom";

            this.Properties = new BuildingProperties()
            {
                Housing = 4,
                WoodCost = 4
            };

            this.MaxPeople = 0;
        }
    }
}
