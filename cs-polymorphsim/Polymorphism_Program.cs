using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Program
    {
        public static void Main(string[] args)
        {
            Doctor Riviera = new Doctor();
            Patient Homer = new Patient();
            Drunkard Barney = new Drunkard();
            Sicky Burns = new Sicky();
            Bartender Moe = new Bartender();


            List<Person> peopleWaitingDoctorsOffice = new List<Person>()
            {
                Homer, Barney, Burns, Moe
            };


            Riviera.Examine(Homer);
            Moe.ServeAnyBeerTo(Homer);
            //Moe.ServeAnyBeerTo(Barney);

            //actually want to examine each of Homer, Barney, Burns, 
            //and ... what? return different results? 
            // enjoy poly morph ism ... !

            foreach (var person in peopleWaitingDoctorsOffice)
            {
                // tuple response
                var result = Riviera.Examine(person);

                // iterate tuple response
                foreach (var tupleResult in result.GetType().GetProperties()
                    .Select(property => property.GetValue(result)))
                {
                    Console.WriteLine(tupleResult);
                }
            }

            Console.ReadKey();
        }

        interface IPatientBehaviors
        {
            bool? Breath();
            Phlegm Cough();
            bool Peer();
        }

        interface IAlcoholicBehaviors
        {
            bool AcceptBeer(Beer beer);
        
        }

        interface IDecrepit
        {
            void FallOver();
            void InjureSelf();
            void InjureOthers(List<Person> otherPeopleInjured);
        }

        /// <summary>
        ///     implements "IPatientBehavior"... 
        ///     As all people COULD POTENTIALLY BE patients... etc...
        ///     But now find that implementation "too heavy"...
        ///     Yet if I kept it here I'd be ABLE TO ITERATE spefifically such functions.
        /// </summary>
        abstract class Person : IPatientBehaviors, IAlcoholicBehaviors
        {
            private List<object> acceptedThings = new List<object>();

            public bool AcceptBeer(Beer beer)
            {
                throw new NotImplementedException();
            }

            public bool Accept(object obj)
            {
                if (obj == null) return false;
                acceptedThings.Add(obj);
                return true;
            }

            public bool? Breath()
            {
                throw new NotImplementedException();
            }

            public Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public bool Peer()
            {
                throw new NotImplementedException();
            }
        }

        class Bartender : Person
        {
            private List<Beer> beerInventory = new List<Beer>
            {
                new Beer {Vintage = "Heineken"},
                new Beer {Vintage = "Steam Whistle"},
                new Beer {Vintage = "Sapporo"},
                new Beer {Vintage = "Crabby's"}
            };

            public Beer ServeBeerTo(Beer beer, Person person)
            {
                person.Accept(beer);
                return beer;
            }

            public Beer ServeAnyBeerTo(Person person)
            {
                Beer beer = beerInventory.Last();
                person.Accept(beer);
                return beer;
            }

            public new bool? Breath()
            {
                throw new NotImplementedException();
            }

            public new Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public new bool Peer()
            {
                throw new NotImplementedException();
            }
        }

        class Beer { public string Vintage;}

        class Phlegm { public string Description; }

        class Sicky : Person, IPatientBehaviors {

            public new bool? Breath()
            {
                return false;
            }

            public new Phlegm Cough()
            {
                return new Phlegm { Description = "Yucky and Green" };
            }

            public new bool Peer()
            {
                return false;
            }
        }

        class Drunkard : Person
        {
            public new bool? Breath()
            {
                return true;
            }

            public new Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public new bool Peer()
            {
                throw new NotImplementedException();
            }

            public new bool AcceptBeer(Beer beer)
            {
                return Drink(beer);
            }

            bool Drink(Beer beer)
            {
                return beer != null;
            }
        }


        class Baby : Person
        {
            public new bool? Breath()
            {
                return null;
            }

            public new Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public new bool Peer()
            {
                return true;
            }
        }

        class Patient : Person
        {
            public new bool? Breath()
            {
                throw new NotImplementedException();
            }

            public new Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public new bool Peer()
            {
                return true;
            }
        }



        class Doctor : Person
        {

            public (bool?, Phlegm, bool) Examine(Person person)
            {
                //this crashes because i'm directly calling "person's Breath" 
                //even tho I extened Person, invoking person's method directly avoids that inheritence.
                //i'd just been assuming the lowest-called member is always called.
                //hmm
                return (person.Breath(),
                        person.Cough(),
                        person.Peer()
                    );
            }
            
            public new bool? Breath()
            {
                throw new NotImplementedException();
            }

            public new Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public new bool Peer()
            {
                throw new NotImplementedException();
            }
        }
    }
}
