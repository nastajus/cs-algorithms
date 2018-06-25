using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_expando_object.somtxt
{
    class SomTxtRdr
    {
        public static void Init()
        {
            StreamReader r = File.OpenText(Path.Combine(Environment.CurrentDirectory, "sombl.txt"));
            //StreamReader r = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sombl.txt"));
            string line;

            while ((line = r.ReadLine()) != null)
            {

            }
        }
    }
}
