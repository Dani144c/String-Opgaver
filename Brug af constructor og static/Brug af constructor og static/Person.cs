using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brug_af_constructor_og_static
{
    class Person
    {
        #region Variabler
        static int Tæller = 0;
        public int ID;
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public string ByNavn { get; set; }
        #endregion

        #region Udskriv metode 1
        public void skrivPersonInstans(int id, string fornavn, string efternavn, string adresse, int postnr, string bynavn)
        {
            Console.WriteLine($"Navn : {fornavn} {efternavn}\nAdresse : {adresse}\nBy : {postnr} {bynavn} \nID : {id}\n\n");
        }
        #endregion

        #region Udskriv metode 2
        public static void skrivInstans(Person person)
        {
            Console.WriteLine($"Navn : {person.Fornavn} {person.Efternavn}\nID : {person.ID}\nTotale brugere : {Tæller}\n\n");
        }
        #endregion


        #region Constructor
        public Person()
        {
            Tæller++;
            ID = Tæller;
        }
        #endregion
    }
}
