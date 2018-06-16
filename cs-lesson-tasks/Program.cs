using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_lesson_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public async Task TaskExample()
        {
            try
            {
                var result1 = await DelayedDog();


                var result2 = await DelayedDog();
                var result3 = await DelayedDog();
                var result4 = await DelayedDog();
                var result5 = await DelayedDog();
                var result6 = await DelayedDog();
            }
            catch (Exception e)
            {

            }
            Console.WriteLine("I'm done with 1!");
        }

        public async Task TaskExample2()
        {
            await ApiService.CreateSession(Timestamp.FromDateTime(DateTime.Now), Duration.FromTimeSpan(TimeSpan.FromSeconds(5)));
            Console.WriteLine("I'm done with 1!");
        }

        public void AntiPattern()
        {
            var task = DelayedDog();

            var result = task.Result; // NO! This blocks the thread!

            Console.WriteLine(result.name);


        }
        public void CallbackExample()
        {
            var task = DelayedDog();

            task.ContinueWith(dogtask =>
            {
                if (dogtask.IsFaulted)
                {
                    Console.Error.WriteLine("AAAAAAH no dog!");
                }
                else
                {
                    Console.WriteLine($"Dog is cool and it's name is {dogtask.Result}");
                }

                DelayedDog().ContinueWith(dogtask2 =>
                {

                })
            });

        }

        public void CallbackExample()
        {
            ApiService.CreateSession(
                Timestamp.FromDateTime(DateTime.Now),
                Duration.FromTimeSpan(TimeSpan.FromSeconds(5))
                ).ContinueWith(finishedTask =>
                {
                    if (finishedT   ask.IsFaulted)
                    {

                    }
                    Console.WriteLine("I'm done with 1!");
                });
        }

        public class Dog
        {
            public string name;
        }

        public async Task<Dog> DelayedDog()
        {
            await Task.Delay(1000);
            return new Dog { name = "fido" };
        }

    }
}
}
