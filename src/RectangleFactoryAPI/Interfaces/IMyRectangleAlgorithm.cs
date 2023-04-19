using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IMyRectangleAlgorithm : IAlgorithm
    {
        //dataset algorithm will run against
        IEnumerable<IShape> dataset { get; set; }
        //algorithm result
        IEnumerable<IShape> output { get; set; }
    }
}
