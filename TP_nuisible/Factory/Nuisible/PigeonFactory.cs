using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class PigeonFactory : NuisibleFactory
    {
        public PigeonFactory()
        {

        }

        public override Nuisible Create()
        {
            Pigeon p = new Pigeon();
            return p;
        }
    }
}
