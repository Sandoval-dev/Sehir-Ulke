using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehir_Ulke
{
    class Program
    {
        public static SinglyLinkedList<Ulke> ulkeler;
        public static SinglyLinkedList<Sehir> sehirler;
        static void Main(string[] args)
        {
            ulkeler = new SinglyLinkedList<Ulke>();
            sehirler = new SinglyLinkedList<Sehir>();

            Console.WriteLine("Lütfen verileri girerken Türkçe karakter kullanmayınız.. \n");
            Console.ReadLine();
            OtomatikEkle();
            SehirleriListele();
            SehirEkle();
            SehirSil();
            SehirleriListele();
            Console.WriteLine("\n");
            UlkeleriListele();
            UlkeEkle();           
            UlkeSil();
            UlkeGoster();
            UlkeyeSehirEkle();
            UlkeleriListele();

            DosyayaKaydet();
            Console.WriteLine("Veriler Sehir-Ulke\\Sehir-Ulke\bin\\Debug adresine kaydedilmiştir. Herhangi bir tuşa basınca uygulama kapanacaktır.");
            Console.ReadKey();

                //Osman Erdem Kılıç - 201913709005
        }

        public static void OtomatikEkle()
        {
            Sehir sehir1 = new Sehir("Bursa", "3.101.880");
            Sehir sehir2 = new Sehir("Balıkesir", "1.229.000");
            Sehir sehir3 = new Sehir("New York", "12.000.000");
            Sehir sehir4 = new Sehir ( "Berlin", "3.645.000" );
            Sehir sehir5 = new Sehir("Kuala Lumpur", "1.808.000");


            sehirler.Add(sehir1);
            sehirler.Add(sehir2);
            sehirler.Add(sehir3);
            sehirler.Add(sehir4);

            Ulke ulke1 = new Ulke("Turkiye", "80.000.000");
            Ulke ulke2 = new Ulke("Yunanistan", "10.423.05");
            Ulke ulke3 = new Ulke("Brezilya", "213.913.675");
            Ulke ulke4 = new Ulke("Malezya", "45.225.000");
            Ulke ulke5 = new Ulke("Hindistan", "1.376.238.018");

            ulke1.sehirler.Add(sehir1);
            ulke1.sehirler.Add(sehir2);
            ulke4.sehirler.Add(sehir5);


            ulkeler.Add(ulke1);
            ulkeler.Add(ulke2);
            ulkeler.Add(ulke3);
            ulkeler.Add(ulke4);
            ulkeler.Add(ulke5);

        

        }


        public static void SehirEkle()
        {
            string sehirAdi;
            string sehirNufus;
            Sehir sehir;
            Console.WriteLine("Eklemek istediğiniz şehrin bilgileri:");
            Console.Write("Şehir adı: ");
            sehirAdi = Console.ReadLine();

            Console.WriteLine("Nüfus: ");
            sehirNufus = Console.ReadLine();

            sehir = new Sehir(sehirAdi, sehirNufus);


            if (!SehirVar(sehir))
            {
                sehirler.Add(sehir);
                Console.WriteLine("Şehir eklendi.");
            }
            else
            {
                Console.WriteLine("Şehir mevcut. ");
            }

            


           
        }

        public static bool SehirVar(Sehir  sehir)
        {
            IEnumerable<Sehir> es = sehirler.GetEnumerator();

            foreach (Sehir s in es)
            {
                if (s.sehirAdi.ToLower() == sehir.sehirAdi.ToLower())
                {
                    return true;

                }
            }
            return false;

        }

        public static Sehir SehirBul(string sehirAdi)
        {
            IEnumerable<Sehir> eSehir = sehirler.GetEnumerator();
            foreach (Sehir sehir in eSehir)
            {
                if (sehir.sehirAdi.ToLower()==sehirAdi.ToLower())
                {
                    return sehir;
                }
            }

            return null;
        }

        public static void SehirSil()
        {
            string sehirAdi;
            Console.WriteLine("Silinecek şehrin adını giriniz: (Silmeyecekseniz Enter'a basınız.)");
            sehirAdi = Console.ReadLine();

            Sehir sehir = SehirBul(sehirAdi);

            if (sehir!=null)
            {
                int position = sehirler.Find(sehir);
                sehirler.Remove(position);
                Console.WriteLine("Şehir listeden silindi... ");
            }          
            else
            {
                Console.WriteLine("Öyle bir şehir mevcut değil veya şehir girişi yapılmadı.");
            }

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static void SehirleriListele()
        {
            Console.WriteLine("----Şehirlerin listesi----");
            IEnumerable<Sehir> eSehir = sehirler.GetEnumerator();
            foreach (Sehir sehir in eSehir)
            {
                Console.WriteLine("Şehrin adı: " + sehir.sehirAdi + " Şehrin nüfusu: " + sehir.nufusSehir);
            }
            Console.WriteLine();

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void UlkeEkle()
        {
            string ulkeAdi;
            string ulkeNufus;
            Ulke ulke;

            Console.WriteLine("Eklemek istediğiniz ülkenin bilgilerini girin: ");
            Console.WriteLine("Ülke adı: ");
            ulkeAdi = Console.ReadLine();

            Console.WriteLine("Ülke nüfusu: ");
            ulkeNufus = Console.ReadLine();

            ulke = new Ulke(ulkeAdi, ulkeNufus);

            if (!UlkeVar(ulke))
            {
                ulkeler.Add(ulke);
                Console.WriteLine("Ülke Eklendi...");
            }
            else
            {
                Console.WriteLine("Ülke mevcut");
            }

            Console.WriteLine("Devam etmek için bir tusa basın...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static bool UlkeVar(Ulke ulke)
        {
            IEnumerable<Ulke> eUlkeler = ulkeler.GetEnumerator();

            foreach (Ulke u in eUlkeler)
            {
                if (u.ulkeAdi.ToLower()==ulke.ulkeAdi.ToLower())
                {
                    return true;

                }
            }

            return false;
        }


        public static Ulke UlkeBul(string ulkeAdi)
        {
            IEnumerable<Ulke> eUlkeler = ulkeler.GetEnumerator();

            foreach (Ulke u in eUlkeler)
            {
                if (u.ulkeAdi.ToLower()==ulkeAdi.ToLower())
                {
                    return u;

                }
            }

            return null;
        }

        public static void UlkeSil()
        {
            string ulkeAdi;
            Console.Write("Silinecek ülkenin adını giriniz: (Silmeyecekseniz Enter'a basınız.) ");
            ulkeAdi = Console.ReadLine();          
            Ulke ulke = UlkeBul(ulkeAdi);

            if (ulke != null)
            {
                int position = ulkeler.Find(ulke);
                ulkeler.Remove(position);

                Console.WriteLine("Ülke Silindi...");

            }
            
            else
            {
                Console.WriteLine("Öyle bir ülke mevcut değil veya ülke girişi yapılmadı.");
            }


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static void UlkeGoster()
        {
            string ulkeAdi;
            Console.WriteLine("Göstermek istediğiniz ülkenin adını giriniz: ");
            ulkeAdi = Console.ReadLine();
            Ulke ulke = UlkeBul(ulkeAdi);

            if (ulke != null)
            {

                Console.WriteLine("Ülke Adı : " + ulke.ulkeAdi);
                Console.WriteLine("Ülke Nüfusu : " + ulke.nufusUlke);

                IEnumerable<Sehir> eS = ulke.sehirler.GetEnumerator();
                Console.WriteLine("Ülkenin Şehirleri");
                foreach (Sehir s in eS)
                {
                    Console.WriteLine("    " + s.sehirAdi + " " + s.nufusSehir);
                }

                Console.WriteLine("-------------------------------");

            }
            else
            {
                Console.WriteLine("Ülke mevcut değil ");
            }


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static void UlkeleriListele()
        {

            Console.WriteLine("--- Ülkelerin Listesi ---");
            IEnumerable<Ulke> uS = ulkeler.GetEnumerator();
            foreach (Ulke u in uS)
            {
                Console.WriteLine(u.ulkeAdi + " " + "Nüfusu: " + u.nufusUlke);

                IEnumerable<Sehir> eS = u.sehirler.GetEnumerator();
                Console.WriteLine("Ülkenin Şehirleri");
                foreach (Sehir s in eS)
                {
                    Console.WriteLine("Şehir adı: " + s.sehirAdi + " " + "Nüfusu: " + s.nufusSehir);
                }
                Console.WriteLine("-------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static void UlkeyeSehirEkle()
        {

            string ulkeAdi;

            Console.Write("Şehir Eklemek İstediğiniz Ülkenin adını giriniz: (Ekleme yapılmayacaksa Enter'a basınız)");
            ulkeAdi = Console.ReadLine();

            Ulke ulke = UlkeBul(ulkeAdi);
            string sehirAdi;
            Sehir sehir;           
            int sayac = 0;
            if (ulke != null)
            {
                while (sayac<1)
                {
                    Console.Write("Eklemek İstediğiniz Şehrin Adını Giriniz: ");
                    sehirAdi = Console.ReadLine();
                    sehir = SehirBul(sehirAdi);
                    if (sehir != null)
                    {
                        ulke.sehirler.Add(sehir);
                        Console.WriteLine("Ülkeye Şehir Eklendi...");

                    }
                    else
                    {
                        Console.WriteLine("Şehir bulunamadı");
                    }

                    sayac++;
                }

            }
            else
            {
                Console.WriteLine("Ülke bulunamadı!");
            }

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        

       public static void DosyayaKaydet()
        {
            string json = "{\n";
            string jsonSehir;
            string jsonUlke;
            using (StreamWriter wr = new StreamWriter("UlkelerSehirler.txt"))
            {
                IEnumerable<Sehir> eS = sehirler.GetEnumerator();
                json = json + "\"Şehirler\":[\n";
                foreach (Sehir s in eS)
                {
                    jsonSehir = "  {\n";
                    jsonSehir = jsonSehir + "   \"ŞehirAdı\":" + "\"" + s.sehirAdi + "\",\n";
                    jsonSehir = jsonSehir + "   \"ŞehirNüfus\":" + "\"" + s.nufusSehir + "\",\n";

                    jsonSehir = jsonSehir + "  },\n";
                    json = json + jsonSehir;
                }

                json = json.Remove(json.LastIndexOf(","), 1);
                json = json + "],\n";



                IEnumerable<Ulke> uS = ulkeler.GetEnumerator();
                json = json + "\"Ülkeler\":[\n";
                foreach (Ulke u in uS)
                {
                    jsonUlke = "  {\n";
                    jsonUlke = jsonUlke + "   \"ÜlkeAdı\":" + "\"" + u.ulkeAdi + "\",\n";
                    jsonUlke = jsonUlke + "   \"ÜlkeNüfus\":" + "\"" + u.nufusUlke + "\",\n";

                    jsonUlke = jsonUlke + "   \"Şehirler\":[\n";

                    IEnumerable<Sehir> eS2 = u.sehirler.GetEnumerator();
                    foreach (Sehir s in eS2)
                    {
                        jsonSehir = "      {\n";
                        jsonSehir = jsonSehir + "       \"ŞehirAdı\":" + "\"" + s.sehirAdi + "\",\n";
                        jsonSehir = jsonSehir + "       \"ŞehrinNüfusu\":" + "\"" + s.nufusSehir + "\",\n";

                        jsonSehir = jsonSehir + "      },\n";
                        jsonUlke = jsonUlke + jsonSehir;
                    }
                    if (u.sehirler.Count > 0)
                    {
                        jsonUlke = jsonUlke.Remove(jsonUlke.LastIndexOf(","), 1);
                    }


                    jsonUlke = jsonUlke + "    ]\n";

                    jsonUlke = jsonUlke + "  },\n";

                    json = json + jsonUlke;


                }
                json = json.Remove(json.LastIndexOf(","), 1);
                json = json + "\n]\n";

                json = json + "}";

               
                wr.WriteLine(json);

                Console.WriteLine("Json Export İşlemi tamamlandı");
           
                Console.WriteLine("\n");
            }

          


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }
       

      
    }
}
