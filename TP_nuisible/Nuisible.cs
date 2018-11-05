using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class Nuisible
    {
        public int ID { get; set; }
        public int VitesseDeplacement { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Etat { get; set; }



        /// Methodes Public avec Return :
        //  Methode permettant de connaitre la classe d'un enfant de la classe nuisible
        public string GetChildClass()
        {

            string origin;
            if (this is Zombie)
            {
                origin = "zombie";
                return origin;
            }
            else
            {
                if (this is Rat)
                {
                    origin = "rat";
                    return origin;
                }
                else
                {
                    if (this is Pigeon)
                    {
                        origin = "pigeon";
                        return origin;
                    }
                    else
                    {
                        origin = "inconnu";
                        return origin;
                    }

                }
            }
        }


        /// Methodes Public Void :
        //  Methode de deplacement des nuisibles
        //  orientations : Nord : 0
        //                 Nord-Est : 1
        //                 Est : 2
        //                 Sud-Est : 3
        //                 Sud : 4
        //                 Sud-Ouest : 5
        //                 Ouet : 6
        //                 Nord-Ouest : 7
        public static void Deplacement(int maxX, int maxY, List<Nuisible> nuisibles)
        {
            int orientation;
            Random aleatoire = new Random();
            // Deplacement aleatoire de chaque nuisibles
            foreach (Nuisible nuisible in nuisibles)
            {
                orientation = aleatoire.Next(0, 8);
                int demiVitese;
                demiVitese = (nuisible.VitesseDeplacement - (nuisible.VitesseDeplacement % 2)) / 2;
                int tempNeg;
                switch (orientation)
                {
                    case 0:
                        nuisible.ModifPositionX(maxX, nuisible.VitesseDeplacement);
                        break;
                    case 1:
                        nuisible.ModifPositionX(maxX, demiVitese);
                        nuisible.ModifPositionY(maxY, demiVitese);
                        break;
                    case 2:
                        nuisible.ModifPositionY(maxY, nuisible.VitesseDeplacement);
                        break;
                    case 3:
                        tempNeg = -demiVitese;
                        nuisible.ModifPositionX(maxX, tempNeg);
                        nuisible.ModifPositionY(maxY, demiVitese);
                        break;
                    case 4:
                        tempNeg = -nuisible.VitesseDeplacement;
                        nuisible.ModifPositionX(maxY, tempNeg);
                        break;
                    case 5:
                        tempNeg = -demiVitese;
                        nuisible.ModifPositionX(maxX, tempNeg);
                        nuisible.ModifPositionY(maxY, tempNeg);
                        break;
                    case 6:
                        tempNeg = -nuisible.VitesseDeplacement;
                        nuisible.ModifPositionY(maxY, tempNeg);
                        break;
                    case 7:
                        tempNeg = -demiVitese;
                        nuisible.ModifPositionX(maxX, demiVitese);
                        nuisible.ModifPositionY(maxY, tempNeg);
                        break;
                }
                Console.WriteLine("--------------------------------- ");
                Console.WriteLine("La position final du nuisible ID : " + nuisible.ID + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y");
                //Console.WriteLine("La position final de " + nuisible.ID + " est : " + nuisible.PositionX + "X" + nuisible.PositionY + "Y  ayant pour orientation " + orientation + " et se deplace a une vitesse de " + nuisible.VitesseDeplacement);
            }  
            
        }



        /// Methode Private Void :
        //  Methode de mofication de la position en Y
        private void ModifPositionY(int maxY, int mouvement)
        {
            PositionY = PositionY + mouvement;

            if (PositionY > maxY)
            {
                PositionY = maxY;
            }
            else
            {
                if (PositionY < 0)
                {
                    PositionY = 0;
                }
            }
        }
        //  Methode de mofication de la position en X
        private void ModifPositionX(int maxX, int mouvement)
        {
            PositionX = PositionX + mouvement;

            if (PositionX > maxX)
            {
                PositionX = maxX;
            }
            else
            {
                if(PositionX < 0)
                {
                    PositionX = 0;
                }
            }
        }

        /// Methodes Static Public :
        // Methode de test collision
        public static void TestCollision(List<Nuisible> nuisibles)
        {
            Random aleatoire = new Random();
            foreach (Nuisible nuisible in nuisibles.ToList())
            {
                IEnumerable<Nuisible> memePos = nuisibles.Where((x) => x != nuisible && x.PositionX == nuisible.PositionX && x.PositionY == nuisible.PositionY);

                var memePasArray = memePos.ToArray();

                //Console.WriteLine("L'objet numero : " + nuisible.ID + " est en collision avec : " + test1.Length + " Objet(s) ");
                for (int y = 0; y < memePasArray.Length; y++)
                {
                    if (memePasArray[y].ID > nuisible.ID)
                    {
                        Console.WriteLine("Le nuisible ID : " + nuisible.ID + " est en collision avec le nuisible ID : " + memePasArray[y].ID);
                        int temprandom = aleatoire.Next(0, 2);
                        Nuisible.CollisionSplit(memePasArray[y], nuisible, temprandom, nuisibles);
                    }
                }
            }
        }



        /// Methodes Static Private :
        //  Methode de suppression d'instance et suppression dans la liste des vivants
        private static void MortNuisible(Nuisible obj, List<Nuisible> vivant)
        {
            vivant.Remove(obj);
            obj = null;
        }

        // Methode de test suite a une collision
        private static void CollisionSplit(Nuisible firstChallenger, Nuisible secondChallenger, int random, List<Nuisible> vivant)
        {
            if (firstChallenger.Etat == "MORT-VIVANT" || secondChallenger.Etat == "MORT-VIVANT")
            {
                if (firstChallenger.Etat != "MORT-VIVANT" && secondChallenger.Etat == "MORT-VIVANT")
                {
                    Nuisible.Zombification(firstChallenger);
                    Console.WriteLine("Il c'est fait transformer par le nuisible ID : " + secondChallenger.ID);
                    Console.WriteLine("\n");
                }
                else
                {
                    if (secondChallenger.Etat != "MORT-VIVANT" && firstChallenger.Etat == "MORT-VIVANT")
                    {
                        Nuisible.Zombification(secondChallenger);
                        Console.WriteLine("Il c'est fait transforme par le nuisible ID : " + firstChallenger.ID);
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        if (firstChallenger.Etat == "MORT-VIVANT" && secondChallenger.Etat == "MORT-VIVANT")
                        {

                            Console.WriteLine("Les nuisibles : " + firstChallenger.ID + " et " + secondChallenger.ID + " sont tout deux des Zombies");
                        }
                        else
                        {
                            Console.WriteLine("L'etat de first challenger est : " + firstChallenger.Etat);
                            Console.WriteLine("L'etat du second challenger est :" + secondChallenger.Etat);
                            Console.WriteLine("Il y a clairement un bug dans la matrice !");
                        }
                    }
                }

            }
            else
            {
                Nuisible.Combat(firstChallenger, secondChallenger, random, vivant);
            }
        }


        // Methode de zombification
        private static void Zombification(Nuisible newZombie)
        {
            if (newZombie.Etat != "MORT-VIVANT")
            {
                Console.WriteLine("-------- Zombification --------");
                Console.WriteLine("Le nuisible ID : " + newZombie.ID + " est devenu un zombie");
                newZombie.Etat = "MORT-VIVANT";
            }
            // newZombie.VitesseDeplacement = 5;
        }

        // Methode de combat entre rats et pigeons
        private static void Combat(Nuisible firstChallenger, Nuisible secondChallenger, int random, List<Nuisible> vivant)
        {
            Console.WriteLine("-------- Regular Fight --------");
            string firstOrigin = firstChallenger.GetChildClass();
            string secondOrigin = secondChallenger.GetChildClass();

            if (firstOrigin == "rat" && random == 0 && secondOrigin == "pigeon" || firstOrigin == "pigeon" && random == 1 && secondOrigin == "rat")
            {
                Console.WriteLine("Le nuisible ID : " + secondChallenger.ID + " " + secondOrigin + " a tuer le nuisible ID : " + firstChallenger.ID + " " + firstOrigin);
                Nuisible.MortNuisible(firstChallenger, vivant);
                firstChallenger.Etat = "MORT";
            }
            else
            {
                if (firstOrigin == "rat" && random == 1 && secondOrigin == "pigeon" || firstOrigin == "pigeon" && random == 0 && secondOrigin == "rat")
                {
                    Console.WriteLine("Le nuisible ID : " + firstChallenger.ID + " " + firstOrigin + " a tuer le nuisible ID : " + secondChallenger.ID + " " + secondOrigin);
                    Nuisible.MortNuisible(secondChallenger, vivant);
                    secondChallenger.Etat = "MORT";
                }
                else
                {
                    Console.WriteLine("impossible de faire combattre un " + firstOrigin + " et un " + secondOrigin);
                }
            }
            Console.WriteLine("\n");
        }
    }

}


