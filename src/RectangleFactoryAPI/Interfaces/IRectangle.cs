using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRectangle : IShape
    {
        int area(); //{ get { return this.Height ?? 0 * this.Width ?? 0; } }
    }
}
