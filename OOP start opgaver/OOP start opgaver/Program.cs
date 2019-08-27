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
            DateTime Dato;
            //Opg 3
            Person p1 = new Person()
            {
                Fornavn = "Abraham",
                Efternavn = "Lincoln"
            };
            Person p2 = new Person()
            {
                Fornavn = "Gilbert",
                Efternavn = "Skysovs"
            };
            Person p3 = new Person()
            {
                Fornavn = "Flomme"
            };
            Person p4 = new Person()
            {
                Fornavn = "Blomme"
            };
            Person p5 = new Person()
            {
                Fornavn = "Alexander"
            };

            //opg 3b

            p3.Efternavn = "";
            p4.Efternavn = "";
            p5.Efternavn = "";
            p1.tlfnr = "";
            p2.tlfnr = "";
            p3.tlfnr = "";
            p4.tlfnr = "";
            p5.tlfnr = "";

            //Opg 4
            List<Person> PersonListe = new List<Person>();
            PersonListe.Add(p1);
            PersonListe.Add(p2);
            PersonListe.Add(p3);
            PersonListe.Add(p4);
            PersonListe.Add(p5);

            foreach (var person in PersonListe)
            {
                int i = 1;
                Console.Write(i + " " + person.Fornavn + " ");
                Console.WriteLine(person.Efternavn + "\n");
                i++;
            }

            

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

        //Opg 5
        public void IndsætDato()
        {
            DateTime Dag = Convert.ToDateTime(Console.ReadLine());
            Fødselsdato = Dag;
        }
    }
}