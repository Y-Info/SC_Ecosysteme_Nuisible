using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation des variables de parametrages
            List<Nuisible> nuisibles = new List<Nuisible>();
            int ecosytemeLimX = 100;
            int ecosytemeLimY = 100;
            int maxNuisible = 200;
            int nbTics = 1000;

            // Initialisation de la variable random
            Random aleatoire = new Random();


            //Nuisible zombieLabo = new Zombie();
            //PigeonMutantDecorator monMutant = new PigeonMutantDecorator(zombieLabo);
            //var testMutant = monMutant.Force;
            //var ttestZombeLabo = zombieLabo;
            //Console.WriteLine(testMutant);


            // Choix du Type d'ecosysteme et generation des nuisibles
            Console.WriteLine("Pour initialiser la simulation veuillez choisir un type d'ecosysteme : Aleatoire, UmbrellaCorp ou Citadin");
            string chooseEcoType = Console.ReadLine();
            while (chooseEcoType != "Aleatoire" && chooseEcoType != "UmbrellaCorp" && chooseEcoType != "Citadin")
            {
                Console.WriteLine("Desoler type d'ecosysteme : " + chooseEcoType + " n'existe pas :/ ");
                Console.WriteLine("Veuillez choisir le type d'ecosysteme parmi ceux proposer ci-dessus!");
                Console.WriteLine();
                chooseEcoType = Console.ReadLine();
                Console.WriteLine("\n");
            }

            // Initialisation de l'ecosysteme en fonction du choix
            Ecosysteme.InitEcoSysteme(chooseEcoType, maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);


            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Debut de l'initialisation des positions -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("\n");


            // initialisation des positions et des ID pour chaque nuisible present dans la liste 
            int i = 0;
            foreach (Nuisible nuisible in nuisibles)
            {
                i = i + 1;
                int minPos = 0;
                int maxPosX = ecosytemeLimX + 1;
                int maxPosY = ecosytemeLimY + 1;
                int tempx = aleatoire.Next(minPos, maxPosX);
                int tempy = aleatoire.Next(minPos, maxPosY);
                nuisible.PositionX = tempx;
                nuisible.PositionY = tempy;
                nuisible.ID = i;
                string tempChildClass = nuisible.GetChildClass();
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("La position initial du " + tempChildClass + " ayant pour ID : " + nuisible.ID + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y");
            }

            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Fin de l'initialisation des positions -- ");
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine ("\n");

            Console.ReadLine();
            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Debut de la simulation -- ");
            Console.WriteLine("--------------------------------- ");

            /// BOUCLE D'EVOLUTION DE L'ECOSYSTEME
            for(int z = 0; z < nbTics; z++)
            {


                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Debut des deplacement des nuisibles pour ce tour -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");

                // Deplacement aleatoire des nuisibles
                Nuisible.Deplacement(ecosytemeLimX, ecosytemeLimY, nuisibles);
            

                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Fin des deplacement des nuisibles pour ce tour -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");


                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Debut des evenements -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");


                // Collisions entre les nuisibles application de la methode adapte a chaque situation
                Nuisible.TestCollision(nuisibles);        

                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Fin des evenements -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");



                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("-- Etat de l'ecosysteme a la fin de ce tour -- ");
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("\n");

                // Lecture du tableau nuisble
                foreach (Nuisible nuisible in nuisibles)
                {
                    string tempClass = nuisible.GetChildClass();
                    Console.WriteLine("--------------------------------- ");
                    Console.WriteLine("Le Nuisible d'ID : " + nuisible.ID + " est un " + tempClass + " son etat actuel est : " + nuisible.Etat);

                    //Console.WriteLine("La position final de " + nuisible.ID + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y  ayant pour orientation " + orientation + " et se deplace a une vitesse de " + nuisible.VitesseDeplacement);
                }

                Console.WriteLine("\n");
                int affichTour = z + 1;
                Console.WriteLine("Vous venez de terminer le tour numero : " + affichTour);
                //Console.ReadLine();
            }

            Console.WriteLine("--------------------------------- ");
            Console.WriteLine("-- Fin de la simulation -- ");
            Console.WriteLine("--------------------------------- ");

            Console.ReadLine();

        }
    }
}
