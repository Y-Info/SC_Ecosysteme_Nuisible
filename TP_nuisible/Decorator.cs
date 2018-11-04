using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class Decorator : Nuisible
    {
        Nuisible modification = null;

        protected Decorator(Nuisible aMuter)
        {
            modification = aMuter;
        }
    }
}
