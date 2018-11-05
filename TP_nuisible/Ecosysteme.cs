using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class Ecosysteme
    {
        public int LimiteX { get; set; }
        public int LimiteY { get; set; }


        public Ecosysteme()
        {
        }

        public Ecosysteme(int maxX, int maxY, string monEco)
        {
            this.LimiteX = maxX;
            this.LimiteY = maxY;
        }




        /// <summary>
        /// Methode de creation de l'ecosysteme avec pour taille les variables ecosytemeLimX et ecosytemeLimY
        /// Cette methode va aussi appeller la methode construction afin de generer les nuisibles de l'ecosystemes
        /// </summary>
        /// <param name="nomEco"> Nom de l'ecosysteme souhaiter</param>
        /// <param name="maxNuisible">Nombre maximal de nuisible</param>
        /// <param name="nuisibles">Listes des nuisibles evoluant dans l'ecosysteme</param>
        /// <param name="ecosytemeLimX"> Limites de l'ecosysteme en X</param>
        /// <param name="ecosytemeLimY"> Limites de l'ecosysteme en Y</param>
        public static void InitEcoSysteme (string nomEco , int maxNuisible, List<Nuisible> nuisibles, int ecosytemeLimX, int ecosytemeLimY)
        {
            if (nomEco == "UmbrellaCorp")
            {
                EcosystemeFactory MonEcosyst = new EcosystemeUmbrellaCorpFactory();
                MonEcosyst.Construction(maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);
            }
            else
            {
                if (nomEco == "Aleatoire")
                {
                    EcosystemeFactory MonEcosyst = new EcosystemeAleatoireFactory();
                    MonEcosyst.Construction(maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);
                }
                else
                {
                    if(nomEco == "Citadin")
                    {
                        EcosystemeFactory MonEcosyst = new EcosystemeCitadinFactory();
                        MonEcosyst.Construction(maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);
                    }
                    else
                    {
                        Console.WriteLine("Erreur dans la methode InitEcosysteme ou precedent");
                    }
                    
                }
            }
        }

        /// <summary>
        /// Methode factory pour la creation des nuisibles suivant les parametre
        /// </summary>
        /// <param name="nbRat">Nombre de rat a cree dans l'ecosysteme</param>
        /// <param name="nbPigeon">Nombre de pigeon a cree dans l'ecosysteme</param>
        /// <param name="nbZombie">Nombre de zombie a cree dans l'ecosysteme</param>
        /// <param name="mesNuisibles">Listes des nuisibles qui vont evoluer dans l'ecosysteme</param>
        protected static void FactoryCreator (int nbRat, int nbPigeon, int nbZombie, List<Nuisible> mesNuisibles)
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
