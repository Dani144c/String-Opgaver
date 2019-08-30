using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Beer
{
    class Program
    {
        static void Main(string[] args)
        {
            Beer beer1 = new Beer("Karl", Beer.BeerType.Porter, 21, 2000);
            Beer beer2 = new Beer("Øller", Beer.BeerType.Pilsner, 53, 1000);
            Beer beer3 = new Beer("Møller", Beer.BeerType.Bock, 32, 1500);
            Beer beerSamlet = new Beer();

            beerSamlet = beer1 + beer3;

            List<Beer> beerListe = new List<Beer>() { beer1, beer2, beer3, beerSamlet };

            beerListe.Sort();

            foreach (var Enhed in beerListe)
            {
                Console.WriteLine(Enhed);
            }

            Console.ReadKey();
        }
    }

    class Beer : IComparable<Beer>
    {
        public string Navn { get; set; }
        public enum BeerType { Lager, Pilsner, Münchener, WeinerDortmunder, Bock, Doppelbock, Porter, Mix}
        public BeerType Slags { get; set; }
        public float Procent { get; set; }
        public int Volumen { get; set; }
        public double Alkohol { get; set; }

        public Beer()
        {

        }

        public Beer(string navn, BeerType slags, float procent, int volumen)
        {
            Navn = navn;
            Slags = slags;
            Procent = procent;
            Volumen = volumen;
            Alkohol = GetUnits();
        }

        public double GetUnits()
        {
            double Alkohol = (Volumen * (Procent / 100)) / 150;
            return Alkohol;
        }

        public override string ToString()
        {
            return "\nNavn      : " + Navn + "\nSlags     : " + Slags + "\nProcent   : " + Math.Round(Procent, 2) + " %\nVolumen   : " + Volumen + " ml\nGenstande : " + Math.Round(Alkohol, 2) + "\n___________________________________";
        }

        public static Beer operator +(Beer beer1, Beer beer2)
        {
            Beer nyBeer = new Beer();
            if (beer1.Navn == beer2.Navn)
            {
                nyBeer.Navn = beer1.Navn;
            }
            else
            {
                nyBeer.Navn = beer1.Navn + " Blandet med " + beer2.Navn;
            }
            if (beer1.Slags == beer2.Slags)
            {
                nyBeer.Slags = beer1.Slags;
            }
            else
            {
                nyBeer.Slags = BeerType.Mix;
            }
            nyBeer.Procent = ((beer1.Volumen * beer1.Procent) + (beer2.Volumen * beer2.Procent)) / (beer1.Volumen + beer2.Volumen);
            nyBeer.Volumen = beer1.Volumen + beer2.Volumen;
            nyBeer.Alkohol = beer1.Alkohol + beer2.Alkohol;

            return nyBeer;
        }

        public int CompareTo(Beer obj)
        {
            if (this.Volumen < obj.Volumen)
            {
                return -1;
            }
            if (this.Volumen > obj.Volumen)
            {
                return 1;
            }
            return 0;
        }
    }
}
