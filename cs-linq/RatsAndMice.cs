using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_linq
{
    class RatsAndMice
    {
        public static void Run()
        {
            //purpose, examing why this isn't working as expected
            //var toUploadLogs = localLogData.Where(x => remoteLogs.Any(y => x.Date != y.Date));

            List<Rat> rats = new List<Rat>
            {
                new Rat { Number = 0, DTO = DateTimeOffset.Parse("2018-06-20")},
                new Rat { Number = 1, DTO = DateTimeOffset.Parse("2018-06-21")},
            };
            
            List<Mice> mice = new List<Mice>
            {
                new Mice { Number = 1, DTO = DateTimeOffset.Parse("2018-06-21")},
                new Mice { Number = 2, DTO = DateTimeOffset.Parse("2018-06-22")},
            };

            //rats.Aggregate()      //--> looking at autocomplete of Func<Rat,Rat,Rat> we realize it's not applicable. We aborted using this. 

            //rats.SelectMany(r => r.) //-->autocomplete shows Func<Rat, IEnumerable<TCollection>> means I have to do a lambda, and pass in rat before =>, and return some kind of collection after the =>.   In any case, we aborted using this too.

            var filteredRats = rats.Where(rat => mice.Any(m => m.DTO == rat.DTO));



            IEnumerable<Rat> Fn(IEnumerable<Rat> irats, IReadOnlyCollection<Mice> imice)
            {
                foreach (var r in irats)
                {
                    if (imice.Any(m => m.DTO == r.DTO))
                    {
                        yield return r;
                    }
                }
            }

            var foo = Fn(rats, mice);








            List<Rat> yyy = new List<Rat>
            {
                new Rat { Number = 1, DTO = DateTimeOffset.Parse("2018-06-21")},
                new Rat { Number = 2, DTO = DateTimeOffset.Parse("2018-06-22")},
            };


            var zzz = rats.Where(x => yyy.Any(y => x.DTO != y.DTO));
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

            //khaled says for transforming

            //like an inner join
            var zz = rats.Select(x => x.DTO).Intersect(yyy.Select(y => y.DTO)); //THE DATE OF 21 only

            //like a left join
            var z = rats.Select(x => x.DTO).Except(yyy.Select(y => y.DTO)); //THE DATE OF 20 only

            //how to get parent Rats?

            // Find all the people older than 30
            //var query1 = list.Where(person => person.Age > 30);
            // Find each person's name
            //var query2 = list.Select(person => person.Name);

            //https://stackoverflow.com/questions/7187996/intersect-two-lists-in-c-sharp
           // var newData = rats.Select(i => i.DTO).Intersect(yyy);




        }

        class Rat
        {
            public int Number { get; set; }
            public DateTimeOffset DTO { get; set; }
        }

        class Mice
        {
            public int Number { get; set; }
            public DateTimeOffset DTO { get; set; }
        }
    }
}
