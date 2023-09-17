using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bussen
{
    class Passagerare
    {
        private string namn;
        private int ålder;
        private string kön;
        public Passagerare(string aNamn, int aÅlder, string aKön)
        {
            namn = aNamn;
            ålder = aÅlder;
            kön = aKön;
        }
        string Namn
        {
            get { return namn; }
            set { namn = value; }
        }

        int Ålder
        {
            get { return ålder; }
            set { ålder = value; }
        }

        string Kön
        {
            get { return kön; }
            set { kön = value; }
        }
    }
}