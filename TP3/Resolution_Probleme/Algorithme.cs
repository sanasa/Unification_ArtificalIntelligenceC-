using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution_Probleme
{
    class Algorithme
    {
        public int CalculHeuristique(String but)
        {
           

            string[] i = but.Split(',');
            string x = i[0]; string y = i[1];
            int ValueX = Int32.Parse(x);
            int ValueY = Int32.Parse(y);
            if (ValueX == 2)
            {
                return 0;
            }
            if (ValueX + ValueY < 2)
            {
                return 7;
            }
            if (ValueY > 2)
            {
                return 3;
            }
            return 1;
        }
    }
}
