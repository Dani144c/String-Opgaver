using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinFørsteKlasse
{
    class Program
    {
        static void Main(string[] args)
        {
            Elev e1 = new Elev();
            Elev e2 = new Elev();

            e1.Fornavn = "Søren";
            e1.Efternavn = "Sørensen";
            e1.Adresse = "Sørens gade 42";

            Console.WriteLine(e1.Fornavn + " " + e1.Efternavn + "\n" + e1.Adresse);

            e2.Fornavn = "Karl";
            e2.Efternavn = "Karlsen";
            e2.Adresse = "Karlsgade 1337";

            
            Console.WriteLine("\n" + e2.Fornavn + " " + e2.Efternavn + "\n" + e2.Adresse);

            Elev e3 = new Elev()
            {
                Fornavn = "Hans",
                Efternavn = "Hansen",
                Adresse = "Hansens allé 59"
            };

            Console.WriteLine("\n" + e3.Fornavn + " " + e3.Efternavn + "\n" + e3.Adresse + "\n");


            List<int> talListe = new List<int>() { 1, 4, 5, 7, 9, 3, 10 };

            talListe.Add(4);

            foreach (int tal in talListe)
            {
                Console.WriteLine(tal);
            }

            List<Elev> ElevListe = new List<Elev>();

            ElevListe.Add(e3);
            ElevListe.Add(e2);
            ElevListe.Add(e1);

            Console.WriteLine();

            foreach (var elev in ElevListe)
            {
                Console.Write(elev.Fornavn+" ");
                Console.WriteLine(elev.Efternavn);
                Console.WriteLine(elev.Adresse+"\n");
            }

            Console.ReadKey();
        }
    }

    public class Elev
    {
        public string Fornavn;
        public string Efternavn;
        public string Adresse;
        
        
        //private string tlf;

        /*public void AngivTelefonnr(string tlfnr)
        {
            tlf = tlfnr;
        }*/

    }
}
