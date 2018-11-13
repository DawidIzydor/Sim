using Sim.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    class Program
    {
        static void Main(string[] args)
        {
            Town town = new Town("Indianapolis", 5);

            Farm farm = new Farm(town)
            {
            };

            Mine mine = new Mine(town)
            {
            };

            LumberMill mill = new LumberMill(town)
            {
            };
            
            town.Buildings.Add(farm);
            town.Buildings.Add(mine);
            town.Buildings.Add(mill);

            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                town.DoTurn();

                Console.WriteLine("Koniec tury");

                consoleKeyInfo = Console.ReadKey();

            } while (consoleKeyInfo.KeyChar != 'w');


        }
    }
}
