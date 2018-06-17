using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_polymorphsim
{
    class Polymorphism_Program
    {
        public static void Main2(string[] args)
        {
            Doctor Riviera = new Doctor();
            Person Homer = new Patient();
            Drunkard Barney = new Drunkard();
            Sicky Burns = new Sicky();
            Bartender Moe = new Bartender();


            Riviera.Examine(Homer);
            Moe.ServeAnyBeerTo(Homer);
            //Moe.ServeAnyBeerTo(Barney);
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
        abstract class Person : IAlcoholicBehaviors
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

        class Beer { public string Vintage;}

        class Phlegm { public string Description; }

        class Sicky : Person, IPatientBehaviors {

            public bool? Breath()
            {
                return false;
            }

            public Phlegm Cough()
            {
                return new Phlegm { Description = "Yucky and Green" };
            }

            public bool Peer()
            {
                return false;
            }
        }

        class Drunkard : Person
        {
            public bool? Breath()
            {
                return true;
            }

            public Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public bool Peer()
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
            public bool? Breath()
            {
                return null;
            }

            public Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public bool Peer()
            {
                return true;
            }
        }

        class Patient : Person
        {
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
                return true;
            }
        }



        class Doctor : Person
        {

            public void Examine(Person person)
            {
                person.Breath();
                person.Cough();
                person.Peer();
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
    }
}
