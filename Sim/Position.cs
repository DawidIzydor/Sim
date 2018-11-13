using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim
{
    class Position
    {
        public int X { get; set; }

        public int Y { get; set; }
        
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Position to)
        {
            return DistanceTo(to.X, to.Y);
        }

        public double DistanceTo(int toX, int toY)
        {
            return Math.Sqrt((X - toX) * (X - toX) + (Y - toY) * (Y - toY));
        }
    }
}
