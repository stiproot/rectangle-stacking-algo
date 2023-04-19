using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IShape
    {
        int X { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        bool isValid();
    }
}
