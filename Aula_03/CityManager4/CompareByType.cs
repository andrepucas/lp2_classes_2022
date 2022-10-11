using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityManager4
{
    public class CompareByType : IComparer<Building>
    {
        private readonly bool SORT_ORDER;

        public CompareByType(bool order)
        {
            SORT_ORDER = order;
        }

        public int Compare(Building x, Building y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return SORT_ORDER ? x.Type.CompareTo(y.Type) : y.Type.CompareTo(x.Type);
        }
    }
}