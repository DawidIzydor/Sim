using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim.Buildings
{
    class LumberMill : Building
    {

        public LumberMill(Town town) : base(town)
        {
            this.Name = "Tartak";

            this.Properties = new BuildingProperties()
            {
                WoodCost = 3,
                Wood = 2,
            };

            MaxPeople = 4;

        }
    }
}
