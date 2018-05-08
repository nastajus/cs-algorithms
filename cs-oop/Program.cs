using System;
using static System.Diagnostics.Debug;
using System.Drawing;
using System.Numerics;

namespace cs_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Polymorphism();
        }

        static void Polymorphism()
        {
            VehiclesSimpleInheritance();
            FruitsPermutationsOfAbstractOverrideVirtual();

        }

        static void VehiclesSimpleInheritance()
        {
            RaceCar raceCar = new RaceCar();
            raceCar.Stop();
        }

        static void FruitsPermutationsOfAbstractOverrideVirtual()
        {

        }


        class Vehicle
        {
            Wheel[] wheels = new Wheel[4];
            //...
            void Drive(Vector3 destination) { }
            public void Stop() { }
        }

        class RaceCar : Vehicle
        {
            void NitroBoost() {}

            //Stop without killing passenger
            public void Stop() {}
        }

        class ConstructionDumpTruck : Vehicle
        {
            void Dump(bool pistonLifts) {}
            void StabilityStruts(bool extendStruts) { }
        }


        class Wheel
        {
            public float radius;
            public string brand;
        }




        enum EnumFruitShape { Sphere, Crescent, Ellipsoid }

        abstract class Fruit
        {
            //protected string name;
            //protected Color color;
            //protected EnumFruitShape shape;
        }

        class Banana : Fruit
        {
            string name = typeof(Banana).ToString(); 
            Color color = Color.FromArgb(255, 215, 0);
            EnumFruitShape shape = EnumFruitShape.Crescent;
        }


    }
}
