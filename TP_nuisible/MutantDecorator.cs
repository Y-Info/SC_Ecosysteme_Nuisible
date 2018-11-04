using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    class MutantDecorator : Decorator
    {
        public int Force { get; set; }


        public MutantDecorator(Nuisible monMutant) : base (monMutant)
        {
            this.Force = 15;
            this.Etat = "MUTANT";
        }

    }
}
