using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class EcosystemeUmbrellaCorpFactory : EcosystemeFactory
    {
        public EcosystemeUmbrellaCorpFactory()
        {

        }

        public override Ecosysteme Construction(int maxNuisible, List<Nuisible> nuisibles, int ecosytemeLimX, int ecosytemeLimY)
        {
            Ecosysteme u = new EcosystemeUmbrellaCorp(maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);
            return u;
        }
    }
}
