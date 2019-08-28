using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arv
{
    class Program
    {
        static void Main(string[] args)
        {
            Top t1 = new Top();
            Højre h1 = new Højre();
            Venstre v1 = new Venstre();

            List<Top> ListeArv = new List<Top>();
            ListeArv.Add(t1);
            ListeArv.Add(h1);
            ListeArv.Add(v1);

            foreach (var element in ListeArv)
            {
                Console.WriteLine(element.UdskrivType());
                Console.WriteLine(element.Tal+"\n");
            }
            
            Console.ReadKey();
        }
    }

    class Top
    {
        public string Type { get; set; }
        public int Tal { get; set; }
        public Top()
        {
            Tal = 14;
            Type = "Top";
        }

        public string UdskrivType()
        {
            return Type;
        }
    }

    class Højre : Top
    {
        public Højre()
        {
            Type = "Højre";
        }
    }

    class Venstre : Top
    {
        public Venstre()
        {
            Tal = Tal + 2;
            Type = "Venstre";
        }
    }
}

