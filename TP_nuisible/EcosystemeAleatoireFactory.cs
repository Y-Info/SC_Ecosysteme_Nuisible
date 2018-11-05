using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class EcosystemeAleatoireFactory : EcosystemeFactory
    {
        public EcosystemeAleatoireFactory()
        {

        }

        public override Ecosysteme Construction(int maxNuisible, List<Nuisible> nuisibles, int largeur, int longueur)
        {
            Ecosysteme a = new EcosystemeAleatoire(maxNuisible, nuisibles, largeur, longueur);
            return a;
        }
    }
}
