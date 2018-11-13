using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    abstract class Building
    {
        public string Name { get; protected set; }

        public BuildingProperties Properties { get; set; }

        public int PeopleInside { get; set; }

        public int MaxPeople { get; set; }

        public Town Town { get; }

        public Building(Town town)
        {
            Town = town;
        }

        public void DoTurn()
        {
            if(Properties.BuildingTime > 0)
            {
                Properties.BuildingTime--;
                Console.WriteLine(this.Name + " wybudowano");
                return;
            }

            if (Properties.Gold != 0)
            {
                Town.Gold += PeopleInside * Properties.Gold;

                Console.WriteLine(this.Name + " dodano " + PeopleInside * Properties.Gold + " złota");
            }

            if (Properties.Iron != 0)
            {
                Town.Iron += PeopleInside * Properties.Iron;

                Console.WriteLine(this.Name + " dodano " + PeopleInside * Properties.Iron + " stali");
            }

            if (Properties.Wood != 0)
            {
                Town.Wood += PeopleInside * Properties.Wood;

                Console.WriteLine(this.Name + " dodano " + PeopleInside * Properties.Wood + " drewna");
            }

            if (Properties.Food != 0)
            {
                Town.Food += PeopleInside * Properties.Food;

                Console.WriteLine(this.Name + " dodano " + PeopleInside * Properties.Food + " jedzenia");
            }
        }
    }
}
