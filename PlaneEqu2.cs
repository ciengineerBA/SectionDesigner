using System;

namespace iSecFRP
{
    class PlaneEqu2
    {
        public double Teta { get; set; }
        public double Eps1 { get; set; }
        public double Eps2 { get; set; }
        public double Height { get; set; }
        public double Breadth { get; set; }

        public double Fi
        {

            get
            {

                double a = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Breadth, 2));
                double b = Math.Cos(Teta - Math.Atan(Breadth / Height));
                double d = a * b;

                return Math.Atan((Eps2 - Eps1) / d);
            }

        }

        public double MemberStrain(double X, double Y)
        {
            double i = Math.Sin(Teta) * Math.Sin(Fi);
            double j = Math.Cos(Teta) * Math.Sin(Fi);
            double k = Math.Cos(Fi);

            double strain = ((Breadth / 2 - X) * i + (Height / 2 + Y) * j) / k + Eps1;

            return strain;
        }
    }
}
