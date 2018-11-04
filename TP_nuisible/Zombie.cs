using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Zombie : Nuisible
    {
        public Zombie()
        {
            this.Etat = "MORT-VIVANT";
            this.VitesseDeplacement = 5;
        }
    }
}
