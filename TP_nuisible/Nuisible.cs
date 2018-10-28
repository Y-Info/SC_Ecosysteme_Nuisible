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

        public void EtatDead()
        {
            Etat = "MORT";
        }

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


