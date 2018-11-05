using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class EcosystemeUmbrellaCorp : Ecosysteme
    {
        public EcosystemeUmbrellaCorp(int maxNuisible, List<Nuisible> nuisibles, int ecosytemeLimX, int ecosytemeLimY)
        {
            Random aleatoire = new Random();
            int tempMaxNuisible = maxNuisible / 4;
            int tempRat = aleatoire.Next(0, tempMaxNuisible);
            int tempPigeon = aleatoire.Next(0, tempMaxNuisible);

            int fiftyZombie = tempRat + tempPigeon;

            int tempRest = maxNuisible - fiftyZombie - tempRat - tempPigeon;
            int alealRest = aleatoire.Next(0, tempRest);
            int tempZombie = (tempRat + tempPigeon + alealRest);
            Ecosysteme.FactoryCreator(tempRat, tempPigeon, tempZombie, nuisibles);
            this.LimiteX = ecosytemeLimX;
            this.LimiteY = ecosytemeLimY;
        }
    }
}
