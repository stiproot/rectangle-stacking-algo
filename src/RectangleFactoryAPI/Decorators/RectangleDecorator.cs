using System;
using Geometry;
using Interfaces;

namespace Decorators
{
    public class RectangleDecorator : IRectangle
    {
        public Rectangle rectangle { get; set; }
        public int index { get; set; }
        public bool isProcessed { get; set; } = false;
        public RectangleDecorator next { get; set; }
        public RectangleDecorator previous { get; set; }

        public int X
        {
            get
            {
                return this.rectangle.X;
            }
            set { }
        }
        public int Y
        {
            get
            {
                return this.rectangle.Y;
            }
            set { }
        }
        public int Width
        {
            get
            {
                return this.rectangle.Width;
            }
            set { }
        }
        public int Height
        {
            get
            {
                return this.rectangle.Height;
            }
            set { }
        }

        public bool isValid()
        {
            return this.rectangle.isValid();
        }
        public int area()
        {
            return this.rectangle.area();
        }

        //subject.noSpaceBetween(rectangleInQuestion)
        public bool noSpaceBetween(RectangleDecorator otherDecorator)
        {
            //1. other decorator is this decorator.
            if (this.index == otherDecorator.index)
            {
                //no space between it and itself
                return true;
            }

            //2. other to left of this
            else if (this.index > otherDecorator.index)
            {
                return otherDecorator.Height >= this.Height && noSpaceBetween(otherDecorator.next);
            }

            //3. other rectangle is to the right
            else if (this.index < otherDecorator.index)
            {
                return otherDecorator.Height >= this.Height && noSpaceBetween(otherDecorator.previous);
            }

            return false;
        }
    }
}
