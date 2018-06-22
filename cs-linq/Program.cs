using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //purpose, examing why this isn't working as expected
            //var toUploadLogs = localLogData.Where(x => remoteLogs.Any(y => x.Date != y.Date));

            List<Rat> xxx = new List<Rat>
            {
                new Rat { Number = 0, DTO = DateTimeOffset.Parse("2018-06-20")},
                new Rat { Number = 1, DTO = DateTimeOffset.Parse("2018-06-21")},
            };

            List<Rat> yyy = new List<Rat>
            {
                new Rat { Number = 1, DTO = DateTimeOffset.Parse("2018-06-21")},
                new Rat { Number = 2, DTO = DateTimeOffset.Parse("2018-06-22")},
            };

            var zzz = xxx.Where(x => yyy.Any(y => x.DTO != y.DTO));
            //why doesn't this return { 0 and 2 } as expected, but instead returns null?

            //var zzz = xxx.Where(x => yyy.All(y => x.DTO != y.DTO));
            //still null
            //https://stackoverflow.com/questions/9027530/linq-not-any-vs-all-dont
            //https://softwareengineering.stackexchange.com/questions/296445/whats-the-use-of-any-in-a-c-list

            //var zz = xxx.Select(i => i.DTO).Intersect(yyy);
            //var zz = xxx.Where( o => yyy.Intersect())
            //var zz = xxx.Where(u => yyy.Intersect().Any());

            //int[] Results = FirstArray.Intersect(SecondArray).ToArray();  
            //var zz = xxx.Intersect(yyy).Where()

            //like an inner join
            var zz = xxx.Select(x => x.DTO).Intersect(yyy.Select(y => y.DTO)); //21 only

            //like a left join
            var z = xxx.Select(x => x.DTO).Except(yyy.Select(y => y.DTO)); //20 only


        }

        class Rat
        {
            public int Number { get; set; }
            public DateTimeOffset DTO { get; set; }
        }
    }
}
