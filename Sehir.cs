using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehir_Ulke
{
    public class Sehir
    {

        public string sehirAdi { get; set; }
        public string nufusSehir { get; set; }

        public Sehir()
        {

        }

        public Sehir(string sehirAdi, string nufusSehir)
        {
            this.sehirAdi = sehirAdi;
            this.nufusSehir = nufusSehir;
        }



    }
}
