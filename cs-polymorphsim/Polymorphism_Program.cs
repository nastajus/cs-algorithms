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

            Riviera.Examine(Homer);
        }

        abstract class Person
        {
            public abstract void Breath();
            public abstract void Cough();
            public abstract void Peer();

        }


        class Patient : Person
        {
            public override void Breath()
            {
                throw new NotImplementedException();
            }

            public override void Cough()
            {
                throw new NotImplementedException();
            }

            public override void Peer()
            {
                throw new NotImplementedException();
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
            
            public override void Breath()
            {
                throw new NotImplementedException();
            }

            public override void Cough()
            {
                throw new NotImplementedException();
            }

            public override void Peer()
            {
                throw new NotImplementedException();
            }
        }
    }
}
