using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_start_opgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime Nu = DateTime.Now;
            //Opg 3/3b
            Person p1 = new Person()
            {
                Fornavn = "Abraham",
                Efternavn = "Lincoln",
                tlfnr = "23234545"
            };
            Person p2 = new Person()
            {
                Fornavn = "Gilbert",
                Efternavn = "Skysovs",
                tlfnr = "45566778"
            };
            Person p3 = new Person()
            {
                Fornavn = "Flomme",
                Efternavn = "Karlsen",
                tlfnr = "12233221"
            };
            Person p4 = new Person()
            {
                Fornavn = "Blomme",
                Efternavn = "Bentsen",
                tlfnr = "09988990"
            };
            Person p5 = new Person()
            {
                Fornavn = "Alexander",
                Efternavn = "Sørensen",
                tlfnr = "45566554"
            };
            //Opg 4
            List<Person> PersonListe = new List<Person>();

            p1.IndsætDato(Convert.ToDateTime("20.12.00")); //p1.Alder(Convert.ToDateTime("20.12.00"));
            p2.IndsætDato(Convert.ToDateTime("04.10.02")); //p2.Alder(Convert.ToDateTime("04.10.02"));
            p3.IndsætDato(Convert.ToDateTime("23.03.01")); //p3.Alder(Convert.ToDateTime("23.03.01"));
            p4.IndsætDato(Convert.ToDateTime("01.01.05")); //p4.Alder(Convert.ToDateTime("01.01.05"));
            p5.IndsætDato(Convert.ToDateTime("10.04.99")); //p5.Alder(Convert.ToDateTime("10.04.99"));

            int ÅrNu = DateTime.Now.Year;
            int Årp1 = p1.Alder.Year;
            p1.alder = ÅrNu - Årp1;

            int Årp2 = p2.Alder.Year;
            p2.alder = ÅrNu - Årp1;

            int Årp3 = p3.Alder.Year;
            p3.alder = ÅrNu - Årp1;

            int Årp4 = p4.Alder.Year;
            p4.alder = ÅrNu - Årp1;

            int Årp5 = p5.Alder.Year;
            p5.alder = ÅrNu - Årp1;


            PersonListe.Add(p1);
            PersonListe.Add(p2);
            PersonListe.Add(p3);
            PersonListe.Add(p4);
            PersonListe.Add(p5);


            foreach (var person in PersonListe)
            {
                Console.Write(person.Fornavn + " ");
                Console.WriteLine(person.Efternavn);
                Console.WriteLine("Alder: " + person.alder + "\n");
                
            }


            //int År1 = Fødselsdato.Year;
            //int ÅrNu = DateTime.Now.Year;
            //int alder = ÅrNu - År1;


            Console.ReadKey();
        }
    }

    //Opg 1
    public class Person
    {
        //Opg 2
        public string Fornavn;
        public string Efternavn;
        public string tlfnr;
        private DateTime Fødselsdato;
        public int alder;

        //Opg 5
        public void IndsætDato(DateTime Dag)
        {
            Fødselsdato = Dag;
        }

        public DateTime Alder
        {
            get { return Fødselsdato;  }
            set
            {
                Fødselsdato = value;
            }

        }
    }
}