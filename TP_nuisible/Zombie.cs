using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Zombie : Nuisible
    {
        public Zombie( string nom, int posX, int posY)
        {
            this.Nom = nom;
            this.PositionX = posX;
            this.PositionY = posY;
            this.Etat = "MORT-VIVANT";
            this.VitesseDeplacement = 5;
        }
        public Zombie()
        {
            this.Etat = "MORT-VIVANT";
            this.VitesseDeplacement = 5;
        }
        public void Grogner()
        {
            Console.WriteLine("Arggrgrgr !");
        }
    }
}
