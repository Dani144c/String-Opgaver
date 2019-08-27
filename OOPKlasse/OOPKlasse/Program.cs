using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person;

namespace OOPKlasse
{
    class Program
    {
        static void Main(string[] args)
        {
            person p1 = new person();
            p1.Navn = "Bent";
            p1.Alder = 15;

            person p2 = new person() { Navn = "Jørgen", Alder = 17 };

            Console.WriteLine("Navn: " + p1.Navn + "\nAlder: " + p1.Alder + "\nID: " + p1.ID + "\n\n");
            Console.WriteLine("\nNavn: " + p2.Navn + "\nAlder: " + p2.Alder + "\nID: " + p2.ID + "\n\n");


            Console.ReadKey();
        }
    }
}
