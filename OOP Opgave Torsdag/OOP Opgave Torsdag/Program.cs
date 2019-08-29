using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Opgave_Torsdag
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * --OPG 1
             * 
             * Indkapsling kan man kalde for en slags bestyttelse af data, 
             * hvor man kan gøre så man ikke udfra kan se hvordan data er håndteret 
             * eller hvordan det bliver opbevaret.
             * 
             * Ja der er en codesnippet, hvis man dobbelt tab'er kan den ofte selv autofill.
             */

            /*
             *--OPG 2a
             */

            bool quit = false;
            int Quit;
            int valg;

            Køretøj Motor = new Køretøj();


            do
            {
                Console.Clear();

                do
                {
                    Console.WriteLine("Vælg mellem at starte eller slukke motoren");
                    Console.WriteLine("Tast 1 = Start, 2 = Sluk");
                    Console.Write("Tast her: ");
                    valg = Convert.ToInt32(Console.ReadLine());

                    if (valg < 1 || valg > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Fejl, prøv igen");
                    }

                } while (valg < 1 || valg > 2);

                Console.Clear();
                switch (valg)
                {
                    case 1:
                        Motor.TurnEngineON();
                        break;

                    case 2:
                        Motor.TurnEngineOFF();
                        break;
                }

                Console.WriteLine("Vil du forlade programmet?\nTast 1 Hvis ja\nTast 2 Hvis du vil køre det forfra");

            } while (quit == true);


            //Motor.TurnEngineON();
            //Console.ReadKey();
            //Motor.TurnEngineON();
            //Console.ReadKey();
            //Motor.TurnEngineOFF();
            //Console.ReadKey();
            //Motor.TurnEngineOFF();
            //Console.ReadKey();

            Console.ReadKey();

        }
    }

    /*
     * --OPG 2
     */

    class Køretøj
    {
        private bool Tændt = false;

        public void TurnEngineON()
        {
            if (Tændt == true)
            {
                Console.WriteLine("Motoren er allerede startet");
            }
            else
            {
                Tændt = true;
                Console.WriteLine("Motoren starter");
            }
        }

        public void TurnEngineOFF()
        {
            if (Tændt == false)
            {
                Console.WriteLine("Motoren er allerede slukket");
            }
            else
            {
                Tændt = false;
                Console.WriteLine("Motoren slukker");
            }
        }
    }
}
