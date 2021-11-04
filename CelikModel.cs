using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSecFRP
{
    class CelikModel
    {
        public double E { get; set; }

        public double Fy { get; set; }
        public double Esh { get; set; }
        public double Uy { get; set; }


        public double Fem { get; set; }

        
        public double Fult
        {
            get

            {
                return Uy * Fy;
            }
        }
        public double FYD
        {
            get
            {
                return Fy / Fem;
            }
        }
        public double Eult { get; set; }
        ///
        ///Bilineer
        ///
        public double Stress(double strain)
        {
            double st = strain;

            double str = 0;
            if (Math.Abs(st) < (Fy / Fem) / E)
            {
                return str = st * E;
            }
            else
            {
                if (st < 0)
                {
                    return str = (Fy) * -1d / Fem;
                }
                else
                {
                    return str = ((Fy) / Fem);
                }




            }


        }
        /// return st = Fy * Math.Sign(st) / Fem;
        /// Deprem Yönetmeliği Strain Hardening
        ///
        public double StressDy2018(double strain)
        {
            double st1 = strain;
            double st = st1;
            double str = 0;

            if (Math.Abs(st) < Fy  / E)
            {
                return str = st * E;
            }
            else if ((Fy  / E) < Math.Abs(st) && Math.Abs(st) < Esh)
            {
                return str = Fy  * Math.Sign(st);
            }
            else
            {
                st = Math.Abs(st);
                str = Fult - (Fult - Fy ) * Math.Pow(Eult - st, 2) / Math.Pow(Eult - Esh, 2);

                return str * Math.Sign(st1);
            }

        }
    }
}
