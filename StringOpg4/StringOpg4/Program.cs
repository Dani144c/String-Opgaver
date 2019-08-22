using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOpg4
{
    class Program
    {
        static void Main(string[] args)
        {
            string tekst;
            string umtekst;
            int myWord = 1;
            int test;
            int tekstmmellem;
            int tekstumellem;
            Console.WriteLine("Skriv en tekst :");
            tekst = Console.ReadLine();
            test = tekst.Count();
            Console.Clear();
            //Console.WriteLine(test);
            //Console.ReadKey();

            tekst = tekst.Trim();
            while (tekst.Contains("  "))
                tekst = tekst.Replace("  "," ");
            tekstmmellem = tekst.Count();
            //Console.WriteLine(tekst);
            //Console.WriteLine(tekstmmellem);
            //Console.ReadKey();

            umtekst = tekst;
            while (umtekst.Contains(" "))
                umtekst = umtekst.Replace(" ", "");
            //Console.WriteLine(tekst);
            tekstumellem = umtekst.Count();
            //Console.WriteLine(tekstumellem);

            myWord = tekstmmellem - tekstumellem + 1;
            Console.WriteLine("Der er {0} ord i teksten", myWord);
            Console.WriteLine("Der er {0} karakterer med mellemrum", tekstmmellem);
            Console.WriteLine("Der er {0} karakterer uden mellemrum", tekstumellem);
            Console.WriteLine("\n\n\n\nTeksten var : {0}", tekst);

            Console.ReadKey();
        }
    }
}
