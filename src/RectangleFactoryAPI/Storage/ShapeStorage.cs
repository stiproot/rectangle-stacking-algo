using System;
using System.Collections;
using System.Linq;
using Interfaces;
//using Geometry;
using System.Collections.Generic;

namespace Storage
{
    public static class ShapeStorage
    {
        private static Dictionary<int, IAlgorithm> data = new Dictionary<int, IAlgorithm>();

        public static IAlgorithm GetAlgorithm(int? n)
        {
            if (!data.Any())
            {
                return null;
            }

            if (n == null)
            {
                return data.LastOrDefault().Value;
            }

            return data.Where(d => d.Key == n).Select(d => d.Value).FirstOrDefault();
        }

        public static bool StoreAlgorithm(int n, IAlgorithm algorithm)
        {
            data.Remove(n);

            data.Add(n, algorithm);

            return true;
        }
    }
}
