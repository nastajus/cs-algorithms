using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Any;

namespace cs_extensions_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string rats = "rat king";
            bool result; 
            result = rats.IsBanana();
            result = rats.IsString();
            Console.ReadKey();
        }
    }
}

namespace Any
{
    static class Any
    {
        public static bool IsBanana(this string s)
        {
            if (s.GetType() == typeof(Banana))
            {
                return true;
            }

            return false;
        }

        public static bool IsString(this string s)
        {
            if (s.GetType() == typeof(string))
            {
                return true;
            }

            return false;
        }
    }

    class Banana
    {

    }
}
