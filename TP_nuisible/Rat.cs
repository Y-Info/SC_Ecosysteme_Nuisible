using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Rat : Nuisible
    {
        public void Couiner()
        {
            Console.WriteLine("kuicuigni !");
        }

        public Rat()
        {
            Etat = "VIVANT";
            VitesseDeplacement = 7;
        }

        public Rat(int randX, int randY)
        {
            this.PositionX = randX;
            this.PositionY = randY;
        }
    }
}
