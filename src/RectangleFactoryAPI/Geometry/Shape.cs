using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Geometry
{
    public abstract class Shape : IShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public abstract bool isValid();

        public Shape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
