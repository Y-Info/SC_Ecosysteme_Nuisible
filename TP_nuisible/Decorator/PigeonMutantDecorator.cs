using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class PigeonMutantDecorator : Decorator
    {
        public int Force { get; set; }


        public PigeonMutantDecorator(Pigeon monNuisible) : base(monNuisible)
        {
            this.Force = 15;
            this.Etat = "MUTANT";
        }

    }
}