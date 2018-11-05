using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_nuisible
{
    public class ZombieFactory : NuisibleFactory
    {
        public ZombieFactory()
        {

        }

        public override Nuisible Create()
        {
            Zombie z = new Zombie();
            return z;
        }
    }
}
