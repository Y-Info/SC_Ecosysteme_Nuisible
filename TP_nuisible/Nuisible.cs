using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class Nuisible
    {
        public string Nom { get; set; }
        public int VitesseDeplacement { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Etat { get; set; }

        ///  Methode de mofication de l'etat pour mort
        public void EtatDead()
        {
            Etat = "MORT";
        }

        ///  Methode de suppression d'instance et suppression dans la liste des vivants
        private static void selectionNaturel (Nuisible obj, List<Nuisible> vivant)
        {
            vivant.Remove(obj);
            obj = null;
        }

        /// Methode de test suite a collision
        public static void preFight(Nuisible firstChallenger, Nuisible secondChallenger, int random, List<Nuisible> vivant)
        {
            if ( firstChallenger.Etat == "MORT-VIVANT" || secondChallenger.Etat == "MORT-VIVANT")
            {
                Console.WriteLine("Il y en a un qui va se faire bouffer");
                if (firstChallenger.Etat != "MORT-VIVANT" && secondChallenger.Etat == "MORT-VIVANT")
                {
                    Nuisible.zombification(firstChallenger);
                }
                else
                {
                    if(secondChallenger.Etat != "MORT-VIVANT" && firstChallenger.Etat == "MORT-VIVANT")
                    {
                        Nuisible.zombification(secondChallenger);
                    }
                    else
                    {
                        if (firstChallenger.Etat == "MORT-VIVANT" && secondChallenger.Etat == "MORT-VIVANT")
                        {
                            Console.WriteLine("Ca sert a rien de vous battre vous etes frere de sang");
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
                Nuisible.regularFight(firstChallenger, secondChallenger, random, vivant);
            }
        }


        /// Methode de zombification
        private static void zombification(Nuisible newZombie)
        {
            newZombie.Etat = "MORT-VIVANT";
            // newZombie.VitesseDeplacement = 5;
        }

         

 


        /// Methode de combat entre rats et pigeons
        private static void regularFight(Nuisible firstChallenger, Nuisible secondChallenger, int random, List<Nuisible> vivant)
        {
            string firstOrigin = firstChallenger.getChildClass();
            string secondOrigin = secondChallenger.getChildClass();

            if (firstOrigin == "rat" && random == 0 && secondOrigin == "pigeon" || firstOrigin == "pigeon" && random == 1 && secondOrigin == "rat")
            {
                Nuisible.selectionNaturel(firstChallenger, vivant);
                firstChallenger.Etat = "MORT";
            }
            else
            {
                if(firstOrigin == "rat" && random == 1 && secondOrigin == "pigeon" || firstOrigin == "pigeon" && random == 0 && secondOrigin == "rat")
                {
                    Nuisible.selectionNaturel(secondChallenger, vivant);
                    secondChallenger.Etat = "MORT";
                }
                else
                {
                    Console.WriteLine("impossible de faire combattre un " + firstOrigin + " et un " + secondOrigin);
                }
            }
        }



        ///  Methode de mofication de la position en Y
        private void ModifPositionY (int maxY, int mouvement)
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

        ///  Methode de mofication de la position en X
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

        ///  Methode permettant de connaitre la classe d'un enfant de la classe nuisible
        public string getChildClass()
        {

            string origin;
            if(this is Zombie) 
            {
                origin = "zombie";
                return origin;
            }
            else
            {
                if(this is Rat)
                {
                    origin = "rat";
                    return origin;
                }
                else
                {
                    if(this is Pigeon)
                    {
                        origin = "pigeons";
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

        ///  Methode pour la contamination d'un nuisible en zombie
        public void ContaminationEnZombie()
        {
            this.VitesseDeplacement = 5;
            this.Etat = "MORT-VIVANT";

        }

        ///  Methode de deplacement des nuisibles
        ///  orientations : Nord : 0
        ///                 Nord-Est : 1
        ///                 Est : 2
        ///                 Sud-Est : 3
        ///                 Sud : 4
        ///                 Sud-Ouest : 5
        ///                 Ouet : 6
        ///                 Nord-Ouest : 7
        public void Deplacement(int maxX, int maxY, int orientation)
        {
            int demiVitese;
            demiVitese = (this.VitesseDeplacement - (this.VitesseDeplacement % 2)) / 2;
            int tempNeg;
            switch (orientation)
            {
                case 0:
                    ModifPositionX(maxX, this.VitesseDeplacement);
                    break;
                case 1:
                    ModifPositionX(maxX, demiVitese);
                    ModifPositionY(maxY, demiVitese);
                    break;
                case 2:
                    ModifPositionY(maxY, this.VitesseDeplacement);
                    break;
                case 3:
                    tempNeg = -demiVitese;
                    ModifPositionX(maxX, tempNeg);
                    ModifPositionY(maxY, demiVitese);
                    break;
                case 4:
                    tempNeg = -VitesseDeplacement;
                    ModifPositionX(maxY, tempNeg);
                    break;
                case 5:
                    tempNeg = -demiVitese;
                    ModifPositionX(maxX, tempNeg);
                    ModifPositionY(maxY, tempNeg);
                    break;
                case 6:
                    tempNeg = -VitesseDeplacement;
                    ModifPositionY(maxY, tempNeg);
                    break;
                case 7:
                    tempNeg = -demiVitese;
                    ModifPositionX(maxX, demiVitese);
                    ModifPositionY(maxY, tempNeg);
                    break;
            }
        }

    }

}


