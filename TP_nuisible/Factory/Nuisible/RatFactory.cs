using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class RatFactory : NuisibleFactory
    {
        public RatFactory()
        {

        }

        public override Nuisible Create()
        {
            Rat r = new Rat();
            return r;
        }
    }
}
