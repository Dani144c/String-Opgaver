using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Operator_overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box1 = new Box(10, 15, 20, Box.boxType.LilleBox);
            Box box2 = new Box(20, 25, 40, Box.boxType.MellemBox);
            Box box3 = new Box(7, 13, 18, Box.boxType.LilleBox);
            Box box4 = new Box(50, 60, 90, Box.boxType.StorBox);
            Box boxSamlet = new Box();

            boxSamlet = box1 + box2;

            List<Box> boxListe = new List<Box>() { box1, box2, box3, box4, boxSamlet };
            boxListe.Sort();

            //Udskriver uden ToString metoden
            foreach (var Boxes in boxListe)
            {
                Console.WriteLine("Højde     : " + Boxes.Højde);
                Console.WriteLine("Bredde    : " + Boxes.Bredde);
                Console.WriteLine("Længde    : " + Boxes.Længde);
                Console.Write("Volume    : ");
                Boxes.GetVolume();
                Console.WriteLine("\nStørresle : " + Boxes.Størrelse);
                Console.WriteLine("______________________");
                Console.WriteLine();
            }

            //Bruger ToString Override metoden
            foreach (var Boxes in boxListe)
            {
                Console.WriteLine(Boxes);
            }

            Console.ReadKey();
        }
    }

    class Box : IComparable<Box>
    {
        public double Højde { get; set; }
        public double Bredde { get; set; }
        public double Længde { get; set; }
        public enum boxType { LilleBox, MellemBox, StorBox}
        public boxType Størrelse { get; set; }
        public double Volume;

        public Box()
        {

        }

        //Tilføjer alle values
        public Box(double højde, double bredde, double længde, boxType box)
        {
            Højde = højde;
            Bredde = bredde;
            Længde = længde;
            Størrelse = box;
            Volume = højde * bredde * længde;
        }

        //Overrider ToString så man kan udskrive det hele på en gang
        public override string ToString()
        {
            return "Højde     : " + Højde + "\nBredde    : " + Bredde + "\nLængde    : " + Længde + "\nStørrelse : " + Størrelse + "\nVolume    : " + Volume +"\n\n";
        }

        //beregner Volume
        public void GetVolume()
        {
            double volume = Højde * Bredde * Længde;
            Console.Write(volume);
        }

        //Beregner når 2 boxes bliver sat sammen
        public static Box operator +(Box b1, Box b2)
        {
            Box nyBox = new Box();
            nyBox.Højde = (b1.Højde + b2.Højde) * 0.95;
            nyBox.Bredde = (b1.Bredde + b2.Bredde) * 0.95;
            nyBox.Længde = (b1.Længde + b2.Længde) * 0.95;
            if (b1.Størrelse == boxType.LilleBox && b2.Størrelse == boxType.LilleBox)
            {
                nyBox.Størrelse = boxType.MellemBox;
            }
            else
            {
                nyBox.Størrelse = boxType.StorBox;
            }
            nyBox.Volume = nyBox.Højde * nyBox.Bredde * nyBox.Længde;
            return nyBox;
        }

        //Sorterer instancerne i listen
        public int CompareTo(Box obj)
        {
            if (this.Volume < obj.Volume)
            {
                return -1;
            }
            if (this.Volume > obj.Volume)
            {
                return 1;
            }
            return 0;
        }

    }
}
