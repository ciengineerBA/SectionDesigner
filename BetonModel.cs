using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSecFRP
{
    class BetonModel
    {
        ///
        /// TBDY FRP SARGILI
        ///
        public double Fckar { get; set; }
        public double B_net { get; set; } //v
        public double H_net { get; set; } //v
        public double yuvallama_R  { get; set; } //köşe yuvarlama çapı
        public double n_sargı      { get; set; }//sargı sayısı

        public double FRP_EPS       { get; set; } //FRP uzaması
        public double FRP_E       {   get; set; } //Frp Elastik Moülü
        public double t          { get; set; } //FRPkalınlığı

        public double roFRP  //FRP oranı
        {
            get
            {
                return n_sargı * 2 * (B_net + H_net) * t / (B_net * H_net);
            }
        }

        public double kapa//Kesit etkinlik
        {
            get
            {
                return 1 - (Math.Pow(B_net - 2 * yuvallama_R, 2) + Math.Pow(H_net - 2 * yuvallama_R, 2)) / (3 * B_net * H_net);
            }
        }

        public double Fl //sargı basıncı
        {
            get
            {
                return 0.5 * kapa * roFRP * FRP_EPS * FRP_E;
            }

        }
        public double epscc
        {
            get
            {
                return -0.002 * (1+15*Math.Pow(Fl/Fckar,0.75));
            }
            
        }
        public double fcc
        {
            get
            {
                return -Fckar*(1+2.4*(Fl/Fckar));
            }

        }
        public double FRP_CON(double strain)
        {
            if (strain <= 0.0 && strain >= -0.002)
            {
                return (-Fckar) * strain / (-0.002);
            }
            else if (strain < -0.002 && strain >= epscc)
            {
                return (-Fckar+(fcc+Fckar)*(strain+0.002)/(epscc+0.002));
            }
            else return 0;
            //
        }
    }
}
