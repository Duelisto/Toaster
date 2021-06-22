using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace ConsoleApp5
{
    class Toaster
    {
        string color { get; set; }
        System.Timers.Timer time { get; set; }
        int shafts { get; set; }
        public double temperature { get; set; }


        bool currentlyToasting;

        List<Toast> allToasts;
        List<Toast> finishedToasts;

        public Toaster()
        {

            time = new System.Timers.Timer();
            time.AutoReset = false;
            time.Interval = 1000 * 20;
            time.Elapsed += new ElapsedEventHandler(TimerEvent);
            currentlyToasting = false;
            allToasts = new List<Toast>();
            finishedToasts = new List<Toast>();
            Console.Write("Welche Farbe soll der Toaster haben? ");
            color = Console.ReadLine();

            while (true)
            {
                Console.Write("Wie viele Schächte soll der Toaster haben? ");
                try
                {
                    shafts = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch { }
            }
        }

        private void TimerEvent(object source, ElapsedEventArgs e)
        {
            StopToasting();
        }

        public void SetTime(int seconds)
        {
            time.Interval = 1000 * seconds;
        }

        public void PutInToasts(int number)
        {
            if (allToasts.Count + number <= shafts)
            {
                for (int i = 0; i < number; i++)
                {
                    allToasts.Add(new Toast());
                }
            }
            else
            {
                Console.WriteLine("ERROR: Die Anzahl der Toasts übersteigt die Anzahl der Schächte");
            }
        }

        public void TakeOutToast(int number)
        {
            if (currentlyToasting == false)
            {
                if (number <= allToasts.Count)
                {
                    allToasts = allToasts.OrderBy(o => o.heatingTime.Elapsed).ToList();
                    allToasts.Reverse();

                    for (int i = 0; i < number; i++)
                    {
                        finishedToasts.Add(allToasts[i]);
                        allToasts.RemoveAt(i);
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Sie wollen mehr Toasts entfernen als sie reingemacht haben");
                }
            }
            else
            {
                Console.WriteLine("ERROR: Sie können kein Toast enterfen während getoastet wird");
            }
        }

        public void StartToasting()
        {
            time.Start();

            Thread thread = new Thread(new ThreadStart(Heat));
            thread.Start();

            if (currentlyToasting == false)
            {
                foreach (Toast toast in allToasts)
                {
                    toast.StartHeat();
                }
            }
            else
            {
                Console.WriteLine("ERROR: Der Toaster ist bereits am toasten");
            }
            currentlyToasting = true;
        }

        public void StopToasting()
        {
            time.Stop();

            if (currentlyToasting == true)
            {
                foreach (Toast toast in allToasts)
                {
                    toast.StopHeat();
                }
            }
            else
            {
                Console.WriteLine("ERROR: Der Toaster ist nicht am toasten");
            }
            currentlyToasting = false;
        }

        private void Heat()
        {
            while (currentlyToasting)
            {
                temperature += 1;
                Thread.Sleep(1000);
            }

            temperature = 0;
        }


        public string GetStateOfToasts()
        {
            string toastReport = "";
            for (int i = 0; i < allToasts.Count; i++)
            {
                toastReport += "Toast: " + (i + 1) + ": " + allToasts[i].GetState() + Environment.NewLine;
            }
            return toastReport;
        }
    }
}
