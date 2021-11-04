using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSecFRP
{
    class CelikFiber
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double D { get; set; }
        public CelikModel Material { get; set; }

        public double Area
        {
            get { return (Math.PI * Math.Pow(D, 2) / 4); }

        }

        public double SteelFiberForce(double strain)
        {

            double FF = Area * Material.Stress(strain);

            return FF;

        }
        public double DY2018(double strain)
        {

            double FF = Area * Material.StressDy2018(strain);

            return FF;

        }
    }
}
