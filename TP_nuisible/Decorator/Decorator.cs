using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public abstract class Decorator : Nuisible
    {
        protected Nuisible monNuisible { get; set; }

        public Decorator(Nuisible monNuisible)
        {
            this.monNuisible = monNuisible;
        }

    }
}