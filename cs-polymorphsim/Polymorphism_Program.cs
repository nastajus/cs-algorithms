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
            var didBreath = Homer.Breathe(); //throws exception, as invokes Patient's, but wasn't intended.
            Homer.Cough();
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
            bool? Breathe();
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

            public bool? Breathe()
            {
                return false;
                //i give up. was being thrown. maybe because of nullable? return type? wild guess.
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

            public new bool? Breathe()
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

            public new bool? Breathe()
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
            public new bool? Breathe()
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
            public new bool? Breathe()
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
            //Compiler Warning level 4: does not hide an inherited member. the new keyword is not required
            public new bool? Breathe()
            {
                return true;
                throw new NotImplementedException();
            }

            public new Phlegm Cough()
            {
                base.Breathe(); //oh. fuck. maybe this was executing???
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
                //this crashes because i'm directly calling "person's Breathe" 
                //even tho I extened Person, invoking person's method directly avoids that inheritence.
                //i'd just been assuming the lowest-called member is always called.
                //hmm
                //i was of the impression that polymorphism would execute the "child member" here...
                //but
                //the example i was given here https://stackoverflow.com/questions/12756048/why-and-when-use-polymorphism
                //showed a virtual - override relationship...
                // what i'm doing is a nil - new relationship...
                //  so that's probably why it's not working? maybe? 
                //   yet "hiding" was supposed to occur... 
                //    i guess i dunno what is meant by hiding.

                // ok so based on here: https://stackoverflow.com/questions/38139838/how-is-the-new-keyword-used-to-hide-a-method
                // i see if instead i did 
                    // Homer.Breathe() instead of person.Breathe() I would have executed that particular instance class' Breathe (Patient's Breathe()) && and that base.Breathe wouldn't have been accessible from inside that instance class's Breathe()

                return (person.Breathe(),
                        person.Cough(),
                        person.Peer()
                    );
            }
            
            public new bool? Breathe()
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
