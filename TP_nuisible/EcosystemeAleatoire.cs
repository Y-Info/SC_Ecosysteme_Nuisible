using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class EcosystemeAleatoire : Ecosysteme
    {
        public EcosystemeAleatoire(int maxNuisible, List<Nuisible> nuisibles, int largeur, int longueur)
        {
            Random aleatoire = new Random();
            int tempMaxNuisible = maxNuisible / 3;
            int tempRat = aleatoire.Next(0, tempMaxNuisible);
            int tempPigeon = aleatoire.Next(0, tempMaxNuisible);
            int tempZombie = aleatoire.Next(0, tempMaxNuisible);
            Ecosysteme.FactoryCreator(tempRat, tempPigeon, tempZombie, nuisibles);
            this.LimiteX = largeur;
            this.LimiteY = longueur;
        }
    }
}
