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

            Køretøj Motor = new Køretøj();

            Motor.TurnEngineON();
            Console.ReadKey();
            Motor.TurnEngineON();
            Console.ReadKey();
            Motor.TurnEngineOFF();
            Console.ReadKey();
            Motor.TurnEngineOFF();
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
