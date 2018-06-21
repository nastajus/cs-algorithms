using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_comparisons
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringifiedNums = { "001", "49", "017", "0080", "00027", "2" };
            bool contains = stringifiedNums.Contains("2", new MyStringifiedNumberComparer());
            Console.WriteLine(contains);

        }
    }

    public class MyStringifiedNumberComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return (Int32.Parse(x) == Int32.Parse(y));
        }

        public int GetHashCode(string obj)
        {
            return Int32.Parse(obj).ToString().GetHashCode();
        }
    }

}
