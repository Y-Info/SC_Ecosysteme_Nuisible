using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Rat : Nuisible
    {
        public Rat()
        {
            Etat = "VIVANT";
            VitesseDeplacement = 7;
        }
    }
}
