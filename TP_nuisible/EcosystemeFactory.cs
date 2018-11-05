using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class EcosystemeFactory
    {
        public EcosystemeFactory()
        {
        }
        public abstract Ecosysteme Construction(int maxNuisible, List<Nuisible> nuisibles, int ecosytemeLimX, int ecosytemeLimY);

    
    }
}
