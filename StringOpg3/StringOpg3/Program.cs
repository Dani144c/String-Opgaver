using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOpg3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime VilkårligDag;
            DateTime Date = DateTime.Now;
            int quit;
            //Console.WriteLine(Date);
            do
            {
                Console.Write("Indtast en dato : ");
                VilkårligDag = Convert.ToDateTime(Console.ReadLine());
                Console.Clear();
                Console.WriteLine(VilkårligDag);

                if (VilkårligDag > Date)
                {
                    Console.WriteLine("It will be a {0}", VilkårligDag.DayOfWeek);
                }
                else
                {
                    Console.WriteLine("It was a {0}", VilkårligDag.DayOfWeek);
                }
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Vil du taste ny dato tryk 1");
                Console.WriteLine("Vil du lukke programmet tryk 2");
                quit = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            } while (quit == 1);
            //Console.WriteLine("Datoen er : {0} {1}", VilkårligDag, VilkårligDag.DayOfWeek);
        }
    }
}
