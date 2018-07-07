using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace cs_events_timer
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerThingy tt = new TimerThingy();
            PewPew pp = new PewPew();
            pp.GenerateShotsForever();

            Console.ReadKey();
        }
    }

    class TimerThingy
    {
        public TimerThingy()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e) //matching, oh right.
        {
            //Console.WriteLine("well, i'll do something, on a timed basis, for sure");
            OnShotShot();
        }

        public static event Action ShotShot;

        private void OnShotShot()
        {
            ShotShot?.Invoke();
        }

    }

    class PewPew
    {
        public void GenerateShotsForever()
        {

            while (true)
            {
                Random rand = new Random();
                var waitingMilliseconds = rand.Next(500, 1000);
                System.Threading.Thread.Sleep(waitingMilliseconds);
                //ShootShoot();     //??? nah ???
                TimerThingy.ShotShot += ShootShoot; //yaaaa
            }
        }

        void ShootShoot()
        {
            //i'm shooting some event at TimerThingy's event ... thingy?  (event handler...)
            Console.WriteLine("pew pew");
        }
    }

}
