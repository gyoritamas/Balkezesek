using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek.Model
{
    public class Jatekos
    {
        public string Nev { get; }
        public DateTime Elso { get; }
        public DateTime Utolso { get; }
        public int Suly { get; }
        public int Magassag { get; }

        public Jatekos(string nev, DateTime elso, DateTime utolso, int suly, int magassag)
        {
            Nev = nev;
            Elso = elso;
            Utolso = utolso;
            Suly = suly;
            Magassag = magassag;
        }

        public override string ToString()
        {
            return Nev;
        }
    }
}
