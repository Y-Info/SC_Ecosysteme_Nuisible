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

        ///  Methode de suppression d'instance
        private void SupprInstance()
        {
            this = null;
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


