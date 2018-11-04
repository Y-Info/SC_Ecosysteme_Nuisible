using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class NuisibleFactory
    {
        public NuisibleFactory()
        {
        }
        public abstract Nuisible Create() ;
    }
}
