using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person() { Fornavn = "Jens", Efternavn = "Hansen" };

            int tal = 4;

            Console.WriteLine(p1.GetType());

            Console.WriteLine(tal.ToString());

            Console.WriteLine(p1.ToString());

            Console.ReadKey();
        }
    }

    class Person
    {
        private int tæller;

        public int Tæller
        {
            get { return this.tæller; }
            set { this.tæller = value; }
        }
        public string Fornavn { get; set; }

        public string Efternavn { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return Fornavn + " " + Efternavn;
        }
    }
}
