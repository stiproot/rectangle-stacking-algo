using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IAlgorithm
    {
        void executeAlgorithm();
        IEnumerable<IShape> generateRandomDataset(Random random, int randomLimit, int n);
    }
}
