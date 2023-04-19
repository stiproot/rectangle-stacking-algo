using System;
using Interfaces;

namespace Geometry
{
    public class Rectangle : Shape, IRectangle
    {
        public int area()
        {
            return this.Height * this.Width;
        }

        public override bool isValid()
        {
            return this.Height > 0 && this.Width > 0;
        }

        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
