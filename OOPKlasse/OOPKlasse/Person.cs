using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class person
    {
        private static int Tæller = 0;
        public string Navn { get; set; }
        public int ID { get; set; }
        private int alder;

        #region Alder metode
        public int Alder
        {
            get { return alder; }
            set
            {
                if (value > 0)
                {
                    alder = value;
                }
                else
                {
                    alder = -4;
                }
            }
        }
        #endregion

        #region Constructor
        public person()
        {
            Tæller++;
            ID = Tæller;
        }
        #endregion
    }
}
