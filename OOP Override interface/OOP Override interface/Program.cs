using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Override_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Hund Fido = new Hund("Puddel", "Han", 15, Hund.Farve.Hvid);
            Hund Line = new Hund("Labrador", "Tæve", 10, Hund.Farve.Sort);
            Hund Gadekryds = new Hund();

            Gadekryds = Fido + Line;

            //Console.WriteLine(Gadekryds.Race + " " + Gadekryds.Køn + " " + Gadekryds.Vægt);

            List<Hund> hListe = new List<Hund>() { Fido, Line, Gadekryds };
            hListe.Sort();

            Console.WriteLine("______________________\n");

            foreach (var vov in hListe)
            {
                Console.WriteLine("Race  : " + vov.Race);
                Console.WriteLine("Køn   : " + vov.Køn);
                Console.WriteLine("Vægt  : " + vov.Vægt);
                Console.WriteLine("Farve : " + vov.HundeFarve);
                Console.WriteLine("______________________");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    class Hund : IComparable<Hund>
    { 
        public enum Farve { Sort, Hvid, Grå}
        public Farve HundeFarve { get; set; }
        public string Race { get; set; }
        public string Køn { get; set; }
        public double Vægt { get; set; }

        public Hund()
        {

        }

        public Hund(string race, string køn, double vægt, Farve f)
        {
            Race = race;
            Køn = køn;
            Vægt = vægt;
            HundeFarve = f; //YMCA YMCA
        }

        public static Hund operator +(Hund h1, Hund h2)
        {
            Hund nyHund = new Hund();
            nyHund.Race = h1.Race + " " + h2.Race + " Hvalp";
            nyHund.Køn = "Se selv efter";
            nyHund.Vægt = (h1.Vægt + h2.Vægt) / 10;
            nyHund.HundeFarve = Farve.Grå;

            return nyHund;
        }
        //Young man
        public int CompareTo(Hund obj)
        {
            if (this.Vægt < obj.Vægt)
            {
                return -1;
            }
            if (this.Vægt > obj.Vægt)
            {//There's no need to feel down
                return 1;
            }
            return 0;
        }
    }
}
