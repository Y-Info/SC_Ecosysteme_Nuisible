using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Pigeon : Nuisible
    {
        public Pigeon()
        {
            Etat = "VIVANT";
            VitesseDeplacement = 10;
        }
        public void Roucouler()
        {
            Console.WriteLine("RhouRhou !");
        }
    }
}
