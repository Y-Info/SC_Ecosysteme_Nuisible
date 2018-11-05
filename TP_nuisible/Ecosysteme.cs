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

        // Methode de creation des Nuisibles de l'ecosysteme
        public static void FactoryCreator (int nbRat, int nbPigeon, int nbZombie, List<Nuisible> mesNuisibles)
        {
            int nbTotalNuisible = nbRat + nbPigeon + nbZombie;

            // Tableau de creation
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

            // Ajout de chaque nuisible cree dans la liste : nuisible
            foreach (NuisibleFactory creator in creators)
            {
                Nuisible leNouveau = creator.Create();
                mesNuisibles.Add(leNouveau);
            }
        }
    }
}
