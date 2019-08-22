using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GætEtTal
{
    class Program
    {
        static void Main(string[] args)
        {
            int gæt;
            int tallet;
            string prøvigen; 
            Random rnd = new Random();
            do
            {
                tallet = rnd.Next(0, 100);
                do
                {
                    gæt = TestAfTal();
                    Console.Clear();
                    Console.WriteLine("Du gættede : {0}", gæt);
                    if (gæt < tallet)
                    {
                        Console.WriteLine("Tallet er højere");
                    }
                    if (gæt > tallet)
                    {
                        Console.WriteLine("Tallet er mindre");
                    }

                } while (gæt != tallet);
                Console.WriteLine("Hurra du gættede det!\nTallet var {0}", tallet);

                do
                {
                    Console.Write("Vil du prøve igen? ");
                    prøvigen = Console.ReadLine().ToLower();

                    if (prøvigen != "ja" && prøvigen != "nej")
                    {
                        Console.Clear();
                        Console.WriteLine("Prøv igen, skriv enten: ja eller nej");
                    }

                } while (prøvigen != "ja" && prøvigen != "nej");

                Console.Clear();
            } while (prøvigen == "ja");

            Console.ReadKey();

        }

        private static int TestAfTal()
        {
            bool EtTal = false;
            int Gæt = 0;

            do
            {
                Console.Write("Indtast dit gæt her : ");
                try
                {
                    Gæt = Convert.ToInt32(Console.ReadLine());
                    EtTal = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Prøv igen");
                }
            } while (EtTal != true);

            return Gæt;
        }
    }
}
