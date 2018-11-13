using Sim.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    class Town
    {
        public string Name { get; private set; }

        public int Population { get; private set; }

        public int JoblessPopulation { get; private set; }
        public int JobsAvaible { get; private set; }
        
        public Position Coordinates { get; private set; }

        public List<Building> Buildings { get; } = new List<Building>();

        public Player Player { get; set; }

        public int Wood { get; set; } = 20;
        public int Iron { get; set; } = 20;
        public int Gold { get; set; } = 20;
        public int Food { get; set; } = 20;

        public int HungerTurns { get; private set; }


        public int FoodPerTurn { get; private set; }
        public int IronPerTurn { get; private set; }
        public int WoodPerTurn { get; private set; }
        public int GoldPerTurn { get; private set; }

        public int Housing { get; private set; }

        public Town(string name, int StartingPopulation)
        {
            Name = name;
            Population = StartingPopulation;
        }

        Random RandomGenerator = new Random();
        

        private void RecalculateJobs()
        {
            JoblessPopulation = Population;
            JobsAvaible = 0;

            FoodPerTurn = 0;
            WoodPerTurn = 0;
            IronPerTurn = 0;
            GoldPerTurn = 0;

            Housing = 0;
            
            foreach (Building building in Buildings)
            {
                JoblessPopulation -= building.PeopleInside;
                if (building.MaxPeople > building.PeopleInside)
                {
                    JobsAvaible += building.MaxPeople - building.PeopleInside;
                }

                if(building.Properties.Food > 0)
                {
                    FoodPerTurn += building.PeopleInside * building.Properties.Food;
                }

                if(building.Properties.Iron > 0)
                {
                    IronPerTurn += building.PeopleInside * building.Properties.Iron;
                }

                if(building.Properties.Wood > 0)
                {
                    WoodPerTurn += building.PeopleInside * building.Properties.Wood;
                }

                if (building.Properties.Gold > 0)
                {
                    WoodPerTurn += building.PeopleInside * building.Properties.Gold;
                }

                if(building.Properties.Housing > 0)
                {
                    Housing += building.Properties.Housing;
                }
            }
        }

        private void ReallocatePeople()
        {
            Console.WriteLine("Ponowne przypisywanie pracownikow");

            foreach(var building in Buildings)
            {
                building.PeopleInside = 0;
            }

            RecalculateJobs();

            AllocatePeople();
        }

        private void AllocatePeople()
        {
            List<Building> buildingsWithJobs = new List<Building>();
            buildingsWithJobs.AddRange(Buildings);

            if (JoblessPopulation > 0)
            {
                for(int a = JoblessPopulation; a > 0; --a)
                {
                    bool allocated = false;

                    for(int i = 0; i < buildingsWithJobs.Count; ++i)
                    {
                        if (buildingsWithJobs[i].PeopleInside >= buildingsWithJobs[i].MaxPeople)
                        {
                            buildingsWithJobs.RemoveAt(i);
                            continue;
                        }

                        int needed = buildingsWithJobs[i].MaxPeople - buildingsWithJobs[i].PeopleInside;
                        int dice = (int)(RandomGenerator.Next(1, JoblessPopulation)*0.5);

                        if(Food < 0 && buildingsWithJobs[i].Properties.Food > 0
                            ||dice < needed
                            )
                        {
                            Console.WriteLine("Dodano pracownika do " + buildingsWithJobs[i].Name);
                            allocated = true;
                            buildingsWithJobs[i].PeopleInside++;
                            JoblessPopulation--;

                            break;
                        }
                    }

                    if(!allocated)
                    {
                        if (buildingsWithJobs.Count > 0)
                        {
                            Console.WriteLine("Dodano pracownika do " + buildingsWithJobs[0].Name);
                            buildingsWithJobs[0].PeopleInside++;
                            JoblessPopulation--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void Breed()
        {
            if(Food > 1 && Housing > Population)
            {
                if(Population < RandomGenerator.Next(1, Food))
                {
                    int newPeople = (int)(Population * 1.5 + 1);

                    if(Population + newPeople > Housing)
                    {
                        newPeople = Housing - Population;
                        if(newPeople <= 0)
                        {
                            return;
                        }
                    }

                    Population += newPeople;
                    Console.WriteLine("Populacja zwiekszyla sie o " + newPeople);
                }
            }
        }

        private void Build()
        {
            RecalculateJobs();

            if (Population > Housing)
            {
                Buildings.Add(new House(this));
            }

            if (JoblessPopulation > 0)
            {
                if(FoodPerTurn < Population)
                {
                    Buildings.Add(new Farm(this));
                }
                else
                {
                    int dice = RandomGenerator.Next(0, 100);

                    if(dice > 75)
                    {
                        Buildings.Add(new Farm(this));
                    }else if (dice > 50)
                    {
                        Buildings.Add(new LumberMill(this));
                    }else if (dice > 25)
                    {
                        Buildings.Add(new Mine(this));
                    }else if (dice > 25)
                    {
                        Buildings.Add(new Mine(this));
                    }
                    else
                    {
                        Buildings.Add(new House(this));
                    }
                }
            }
            else
            {
                Buildings.Add(new House(this));
            }
        }

        public void DoTurn()
        {
            Console.WriteLine(Name);

            RecalculateJobs();
            AllocatePeople();

            foreach(Building building in Buildings)
            {
                building.DoTurn();
            }

            Food -= Population;

            if (Food < 0)
            {
                Console.WriteLine("Ludzie gloduja!");

                HungerTurns++;

                if (HungerTurns > 2)
                {
                    int maxDie = (Food * -1 > Population / 2 ? Population / 2 : Food * -1) * HungerTurns/8;

                    int PopToKill = RandomGenerator.Next(0, maxDie);

                    Population -= PopToKill;

                    Console.WriteLine(PopToKill + " ludzi zmarlo z glodu!");

                    ReallocatePeople();
                }
            }
            else
            {
                HungerTurns = 0;
                Breed();
            }

            Build();

            Console.WriteLine("Koneic tury (Populacja: "+Population+", " + Food + " jedzenia, " + Wood + " drewna, " + Iron + " zelaza, " + Gold + " zlota)");
        }

    }
}
