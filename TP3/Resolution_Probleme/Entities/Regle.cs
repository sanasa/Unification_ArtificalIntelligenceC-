using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolution_Probleme.Entities
{
   public class Regle
    {
        
        public int numero { get; set; }
        public List<Operateur> contraintes { get; set; }

        public List<Fait> premisses { get; set; }

        public Fait conclusions { get; set; }

        public StringBuilder modification { get; set; }

        

        public Regle()
        {

            premisses = new List<Fait>();
            contraintes = new List<Operateur>();
            modification = new StringBuilder("");
        }
    }
}
