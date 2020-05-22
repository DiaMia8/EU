using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU
{
    class Program
    {
        public static List<Csatlakozas> csatlakozas;

        static void Main(string[] args)
        {
            //2. feladat
            csatlakozas = new List<Csatlakozas>();
            string file = "EUcsatlakozas.txt";

            foreach (var item in File.ReadAllLines(file, Encoding.UTF8))
            {
                csatlakozas.Add(new Csatlakozas(item));
            }

            //3. feladat

            Console.Write("3. feladat: ");
            Console.WriteLine($"EU tagállamainak száma: {csatlakozas.Count} db");

            //4. feladat

            int keresett = csatlakozas.Count(x => x.Datum.Year == 2007);
            Console.Write("4. feladat: ");
            Console.WriteLine($"2007-ben {keresett} ország csatlakozott.");

            //5. feladat

            Csatlakozas magyar = csatlakozas.First(x=>x.Orszag.Contains("Magyar"));
            Console.Write("5. feladat: ");
            Console.WriteLine($"Magyarország csatlakozásának dátuma: {magyar.Datum.ToShortDateString()}");

            //6.feladat

            bool majus = csatlakozas.Exists(x => x.Datum.Month == 5);
            Console.Write("6. feladat: ");
            if (majus)
            {
                Console.WriteLine("Májusban volt csatlakozás!");
            }
            else
            {
                Console.WriteLine("Májusban nem volt csatlakozás!");
            }

            //7. feladat

            DateTime legutolso = csatlakozas.Max(x=>x.Datum);
            Console.Write("6. feladat: ");
            Console.WriteLine($"Legutoljára csatlakozott ország: {csatlakozas.First(x=>x.Datum == legutolso).Orszag}");

            //8. feladat

            Dictionary<DateTime, int> orszagok = new Dictionary<DateTime, int>();

            foreach (var item in csatlakozas)
            {
                if (!orszagok.ContainsKey(item.Datum))
                {
                    orszagok.Add(item.Datum, 1);
                }
                else
                {
                    orszagok[item.Datum]++;
                }
            }
            Console.WriteLine("8. feladat: Statisztika");

            foreach (var item in orszagok)
            {
                Console.WriteLine($"\t{item.Key.Year} - {item.Value} ország");
            }

            Console.ReadKey();
        }
    }
}
