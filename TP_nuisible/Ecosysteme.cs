using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Ecosysteme
    {
        public int LimiteX { get; set; }
        public int LimiteY { get; set; }


        public Ecosysteme()
        {
        }

        public Ecosysteme(int maxX, int maxY)
        {
            this.LimiteX = maxX;
            this.LimiteY = maxY;
        }

        public static void FactoryCreator (int nbRat, int nbPigeon, int nbZombie, List<Nuisible> mesNuisibles)
        {
            int nbTotalNuisible = nbRat + nbPigeon + nbZombie;

            // An array of creators
            NuisibleFactory[] creators = new NuisibleFactory[nbTotalNuisible];

            int globalCount = 0;
            for (int y = 0; y < nbRat; y++)
            {
                creators[globalCount] = new RatFactory();
                globalCount++;
            }
            for (int y = 0; y < nbPigeon; y++)
            {
                creators[globalCount] = new PigeonFactory();
                globalCount++;
            }
            for (int y = 0; y < nbZombie; y++)
            {
                creators[globalCount] = new ZombieFactory();
                globalCount++;
            }

            // Iterate over creators and create products
            foreach (NuisibleFactory creator in creators)
            {

                Nuisible leNouveau = creator.Create();
                mesNuisibles.Add(leNouveau);
            }
        }
    }
}
