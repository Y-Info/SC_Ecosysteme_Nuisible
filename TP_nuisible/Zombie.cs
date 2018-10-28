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
            Etat = "VIVANT";
            VitesseDeplacement = 5;
        }
        public void Grogner()
        {
            Console.WriteLine("Arggrgrgr !");
        }
    }
}
