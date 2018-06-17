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
            Patient Homer = new Patient();
            Drunkard Barney = new Drunkard();
            Sicky Burns = new Sicky();
            Bartender Moe = new Bartender();


            Riviera.Examine(Homer);
        }

        abstract class Person
        {
            public abstract bool? Breath();
            public abstract Phlegm Cough();
            public abstract bool Peer();

            public abstract bool AcceptBeer(Beer beer);

        }

        class Bartender : Person
        {
            public Beer ServeBeerTo(Person person)
            {

            }

            public override bool? Breath()
            {
                throw new NotImplementedException();
            }

            public override Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public override bool Peer()
            {
                throw new NotImplementedException();
            }
        }

        class Beer { public string Vintage;}

        class Phlegm { public string Description; }

        class Sicky : Person {

            public override bool? Breath()
            {
                return false;
            }

            public override Phlegm Cough()
            {
                return new Phlegm { Description = "Yucky and Green" };
            }

            public override bool Peer()
            {
                return false;
            }
        }

        class Drunkard : Person
        {
            public override bool? Breath()
            {
                return true;
            }

            public override Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public override bool Peer()
            {
                throw new NotImplementedException();
            }
        }


        class Baby : Person
        {
            public override bool? Breath()
            {
                return null;
            }

            public override Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public override bool Peer()
            {
                return true;
            }
        }

        class Patient : Person
        {
            public override bool? Breath()
            {
                throw new NotImplementedException();
            }

            public override Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public override bool Peer()
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
            
            public override bool? Breath()
            {
                throw new NotImplementedException();
            }

            public override Phlegm Cough()
            {
                throw new NotImplementedException();
            }

            public override bool Peer()
            {
                throw new NotImplementedException();
            }
        }
    }
}
