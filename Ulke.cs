using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehir_Ulke
{
    public class Ulke
    {
        public string ulkeAdi { get; set; }
        public string nufusUlke { get; set; }

        public SinglyLinkedList<Sehir> sehirler { get; set; }

        public Ulke()
        {
            this.sehirler =new SinglyLinkedList<Sehir>();
        }

        public Ulke(string ulkeAdi, string nufusUlke)
        {
            this.ulkeAdi = ulkeAdi;
            this.nufusUlke = nufusUlke;

            this.sehirler = new SinglyLinkedList<Sehir>();
        }

       

    }
}
