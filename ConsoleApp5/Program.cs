using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperToaster toaster = new SuperToaster();
            //int action;

            while (true)
            {
                int action = UserInputInt("Was ist ihre nächste Aktion? 1 = Toastscheiben einlegen, 2 = Toastscheiben herausnehmen, 3 = Zeit einstellen, 4 = Toasten starten, 5 = Toasten beenden, 6 = Zustand der Toasts abfragen,  7 = Programm beenden");



                switch (action)
                {
                    case 1:
                        {
                            int number = UserInputInt("Wie viele Scheiben möchten sie einlegen?");
                            toaster.PutInToasts(number);
                        }
                        break;
                    case 2:
                        {
                            int number = UserInputInt("Wie viele Scheiben möchten sie herausnehmen? (Die am längsten getoasteten werden herausgenommen)");
                            toaster.TakeOutToast(number);
                        }
                        break;
                    case 3:
                        {
                            int number = UserInputInt("Wie lang soll der Toaster toasten?");
                            toaster.SetTime(number);
                        }
                        break;
                    case 4:
                        {
                            toaster.StartToasting();
                        }
                        break;
                    case 5:
                        {
                            toaster.StopToasting();
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine(toaster.GetStateOfToasts());
                        }
                        break;
                    case 7:
                        {
                            Environment.Exit(0);
                        }
                        break;
                }

            }
        }

        static private int UserInputInt(string instruction)
        {
            int number;
            while (true)
            {
                Console.WriteLine(instruction);
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch { }
            }

            return number;


        }
    }
}

