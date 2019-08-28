using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arv_Opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            Figur k1 = new Kvadrat(150);
            Figur k2 = new Kvadrat(200);
            Figur c1 = new Cirkel(250);
            Figur c2 = new Cirkel(300);

            List<Figur> ListeFigur = new List<Figur>();

            ListeFigur.Add(k1);
            ListeFigur.Add(k2);
            ListeFigur.Add(c1);
            ListeFigur.Add(c2);

            foreach (var Element in ListeFigur)
            {
                Element.GetAreal();
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }

    class Figur
    {
        public double Size { get; set; }

        public Figur()
        {
        }

        public Figur(int size)
        {
            Size = size;
        }

        public virtual void GetAreal() { }
    }

    class Kvadrat : Figur
    {
        public Kvadrat(int size) : base(size)
        {

        }
        public override void GetAreal()
        {
            Console.WriteLine("Arealet er : " + Size * Size);
        }
        
    }

    class Cirkel : Figur
    {
        public Cirkel(int size) : base(size) {}
        public override void GetAreal()
        {
            Console.WriteLine("Arealet er : " + Math.PI * ((Size / 2) * (Size / 2)));
        }
    }
}