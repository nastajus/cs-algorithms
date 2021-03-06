﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Generics_Mosh
    {
        public static void Init()
        {
            var f = Max(1, 2);
            var g = Max<int>(3, 4);
            var h = Max<string>("cat", "dog");
        }

        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

    }
}
