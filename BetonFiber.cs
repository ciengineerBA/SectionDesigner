using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSecFRP
{
    class BetonFiber
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Area { get; set; }
        public BetonModel Material { get; set; }

        public double FRP (double strain)
        {
            double force = Area * Material.FRP_CON(strain);
            return force;
        }

    }
}
