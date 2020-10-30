using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO_Game_Project
{
    public class Igrac
    {
        public int BrojPobjeda { get; set; }
        public string ImeIgraca { get; set; }


        public Igrac(string imeIgraca)
        {
            BrojPobjeda = 0;
            ImeIgraca = imeIgraca;
        }

        public override string ToString()
        {
            return $"Igrac -> {ImeIgraca}";
        }
    }
}
