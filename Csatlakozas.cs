using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU
{
    class Csatlakozas
    {
        public string Orszag { get; set; }

        public DateTime Datum { get; set; }

        public Csatlakozas(string sor)
        {
            string[] seged = sor.Split(';');
            Orszag = seged[0];
            Datum = DateTime.Parse(seged[1]);
        }
    }
}
