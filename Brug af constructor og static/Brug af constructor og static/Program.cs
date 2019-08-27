using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brug_af_constructor_og_static
{
    class Program
    {
        static void Main(string[] args)
        {
            #region p1
            Person p1 = new Person()
            {
                Fornavn = "Karl",
                Efternavn = "Karlsen",
                Adresse = "Peter Bangs vej 72",
                PostNr = 2000,
                ByNavn = "Frederiksberg"
            };
            #endregion

            #region p2
            Person p2 = new Person()
            {
                Fornavn = "Søren",
                Efternavn = "Sørensen",
                Adresse = "Telegraf vej 7",
                PostNr = 2750,
                ByNavn = "Ballerup"
            };
            #endregion

            #region p3
            Person p3 = new Person()
            {
                Fornavn = "Daniel Rømer",
                Efternavn = "Matthiesen",
                Adresse = "P. G. Ramms Allé 29 stth",
                PostNr = 2000,
                ByNavn = "Frederiksberg"
            };
            #endregion

            #region Metode kald 1
            p3.skrivPersonInstans(p3.ID, p3.Fornavn, p3.Efternavn, p3.Adresse, p3.PostNr, p3.ByNavn);
            p1.skrivPersonInstans(p1.ID, p1.Fornavn, p1.Efternavn, p1.Adresse, p1.PostNr, p1.ByNavn);
            p2.skrivPersonInstans(p2.ID, p2.Fornavn, p2.Efternavn, p2.Adresse, p2.PostNr, p2.ByNavn);
            #endregion

            Console.WriteLine("-------------------------------------------\n");

            #region Metode kald 2
            Person.skrivInstans(p1);
            Person.skrivInstans(p2);
            Person.skrivInstans(p3);
            #endregion


            Console.ReadKey();
        }
    }
}
