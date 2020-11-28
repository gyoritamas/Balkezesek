using Balkezesek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static void Main(string[] args)
        {
            string forras = @"..\..\src\balkezesek.csv";

            #region 2. feladat
            List<Jatekos> jatekosLista = BeolvasJatekos(forras);
            #endregion

            #region 3. feladat
            Console.Write("3. feladat: ");
            Console.WriteLine(jatekosLista.Count());
            #endregion

            #region 4. feladat
            Console.WriteLine("4. feladat:");
            var oktober99 = jatekosLista
                .Where(x => x.Utolso >= new DateTime(1999, 10, 1) && x.Utolso <= new DateTime(1999, 10, 31))
                .Select(x => x)
                .ToList();
            oktober99.ForEach(x => Console.WriteLine($"\t{x.Nev}, {Math.Round((x.Magassag * 2.54), 1)} cm"));
            #endregion

            #region 5. feladat
            Console.WriteLine("5. feladat:");
            int ev = EvszamBeker();
            #endregion

            #region 6. feladat
            Console.Write("6. feladat: ");
            var atlagSuly = jatekosLista
                .Where(x => x.Elso.Year <= ev && x.Utolso.Year >= ev)
                .Select(x => x.Suly)
                .Average(x => x);
            double kerekitettAtlagSuly = Math.Round(atlagSuly, 2);
            Console.WriteLine($"{kerekitettAtlagSuly} font");
            #endregion

            Console.ReadKey();
        }

        private static List<Jatekos> BeolvasJatekos(string forras)
        {
            List<Jatekos> jatekosLista = new List<Jatekos>();
            using (StreamReader sr = new StreamReader(forras, Encoding.UTF8))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    jatekosLista.Add(new Jatekos(
                        sor[0],
                        Convert.ToDateTime(sor[1]),
                        Convert.ToDateTime(sor[2]),
                        Convert.ToInt32(sor[3]),
                        Convert.ToInt32(sor[4])
                        ));
                }
            }

            return jatekosLista;
        }

        private static int EvszamBeker()
        {
            while (true)
            {
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
                int ev = Convert.ToInt32(Console.ReadLine());
                if (ev < 1990 || ev > 1999)
                {
                    Console.Write("Hibás adat!");
                }
                else
                {
                    return ev;
                }
            }
        }

    }
}
