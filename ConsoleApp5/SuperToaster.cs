using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp5
{
    class SuperToaster: Toaster
    {
        public SuperToaster()
        {
            Thread thread = new Thread(new ThreadStart(CheckTemperature));
            thread.Start();
        }

        private void CheckTemperature()
        {
            while(true)
            {
                if (temperature > 500)
                {
                    StopToasting();
                }
            }
        }
    }
}
