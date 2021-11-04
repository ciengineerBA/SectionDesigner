using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arayuz
{
    class HasarLimiti
    {
        public double AlfaSe(double h0, double b0, double s, double[] bi)
        {
            double Toplam = 0;
            for (int B = 0; B < bi.Length; B++)
            {
                Toplam = Math.Pow(bi[B], 2) + Toplam;
            }
            double AlfaSe = 0;

            double q = (1 - Toplam / (6 * h0 * b0));

            double w = (1 - s / (2 * b0));
            double e = (1 - s / (2 * h0));
            AlfaSe = q * w * e;
            return AlfaSe;
        }

        public double omega(double h0, double b0, double s, double Dtr, int bn, int hn, double FYWe, double Fc, double AlfaSe)
        {
            double omega = 0;
            double p1 = bn * Math.Pow(Dtr, 2) * Math.PI / (4 * (b0) * s);
            double p2 = hn * Math.Pow(Dtr, 2) * Math.PI / (4 * (h0) * s);
            double pmin = Math.Min(p1, p2);
            omega = AlfaSe * pmin * FYWe / Fc;
            return omega;
        }

        public double Colppre(double omega)
        {
            double Colppre = 0;

            Colppre = 0.0035 + 0.04 * Math.Sqrt(omega);

            if (Colppre >= 0.018)
            {
                Colppre = 0.018;
            }

            return Colppre;
        }
        public double[] goon_sig = new double[2];
        public double[] koha_sig = new double[2];
        public double[] keku_sig = new double[2];


        public double[] goon_eps = new double[2];
        public double[] koha_eps = new double[2];
        public double[] keku_eps = new double[2];
        //goon_eps[0]= GO;
        //    keku_eps[0]=0.75*GO;
        //    koha_eps[0]= 0.0025;

        //    goon_eps[1] = GO;
        //    keku_eps[1] = 0.75 * GO;
        //    koha_eps[1] = 0.0025;

    }
}
