using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp5
{
    class Toast
    {
        public Stopwatch heatingTime;
        public Toast()
        {
            heatingTime = new Stopwatch();
        }

        public void StartHeat()
        {
            heatingTime.Start();
        }

        public void StopHeat()
        {
            heatingTime.Stop();
        }

        public string GetState()
        {
            double seconds = heatingTime.Elapsed.TotalSeconds;
            if (seconds > 30)
            {
                return "Verbrannt";
            }
            else if(seconds > 15)
            {
                return "Stark getoastet";
            }
            else if(seconds > 0)
            {
                return "Leicht getoastet";
            }
            else
            {
                return "Ungetoastet";
            }
        }

    }
}
