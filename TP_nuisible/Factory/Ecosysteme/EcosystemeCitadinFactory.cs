using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class EcosystemeCitadinFactory : EcosystemeFactory
    {
        public EcosystemeCitadinFactory()
        {

        }

        public override Ecosysteme Construction(int maxNuisible, List<Nuisible> nuisibles, int ecosytemeLimX, int ecosytemeLimY)
        {
            EcosystemeCitadin c = new EcosystemeCitadin(maxNuisible, nuisibles, ecosytemeLimX, ecosytemeLimY);
            return c;
        }
    }
}
