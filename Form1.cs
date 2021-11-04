using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iSecFRP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            analizgec.Enabled = false;
            clearButt.Enabled = false;
            meshButton.Enabled = false;
            hBox.Text = 500.ToString();
            bBox.Text = 300.ToString();
            PPbox.Text = 25.ToString();
            NUst.Text = 3.ToString();
            DUst.Text = 12.ToString();
            DAlt.Text = 12.ToString();
            NAlt.Text = 3.ToString();
            DAra.Text = 12.ToString();
            NAra.Text = 2.ToString();
            SBox.Text = 100.ToString();
            meshmin.Text = 10.ToString();
            Detr.Text = 8.ToString();
         
        }
        public static double H = 0;
        public static double B = 0;
        public static double PP = 0;
        public static double Nust = 0;
        public static double Dust = 0;
        public static double Nalt = 0;
        public static double Dalt = 0;
        public static double Nara = 0;
        public static double Dara = 0;
        public static double S = 0;
        public static double M = 0;
        public static double Denine = 0;
        public static double MeshX = 0;
        public static double MeshY = 0;

        public static List<double> ÇirozKoordX = new List<double>();
        public static List<double> ÇirozKoordY = new List<double>();

        public float sf;
        public float sf1;
        public float sf2;
        void Atama()
        {
            H = Convert.ToDouble(hBox.Text);
            B = Convert.ToDouble(bBox.Text);
            PP = Convert.ToDouble( PPbox.Text);
            Denine = Convert.ToDouble(Detr.Text);
            Nust = Convert.ToDouble( NUst.Text);
            Dust = Convert.ToDouble( DUst.Text);
            Nalt = Convert.ToDouble( NAlt.Text);
            Dalt = Convert.ToDouble( DAlt.Text);
            Nara = Convert.ToDouble( NAra.Text);
            Dara = Convert.ToDouble(DAra.Text);
            S = Convert.ToDouble(SBox.Text);
            M = Convert.ToDouble(meshmin.Text);
            MeshX = Math.Round( B / M);
            MeshY = Math.Round(H / M);
            sf1 = Convert.ToSingle(cizbox.Height * 0.85 / (H ));
            sf2 = Convert.ToSingle(cizbox.Width * 0.85 / (B));
            sf = Math.Min(sf1,sf2);
        }

        void Kesitciz()
        {
            Graphics gr = cizbox.CreateGraphics();
            Pen p = new Pen(Color.White, 1);
            Pen ax = new Pen(Color.Red, 0.5f);
            Pen inc = new Pen(Color.Yellow, 1);
            ax.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gr.TranslateTransform(cizbox.Width / 2, cizbox.Height / 2);
            gr.RotateTransform(-90);
            gr.ScaleTransform(sf, sf);


            gr.DrawRectangle(p, Convert.ToSingle(-H / 2), Convert.ToSingle(-B / 2), Convert.ToSingle(H), Convert.ToSingle(B));
            gr.DrawRectangle(p, Convert.ToSingle(-H / 2+Denine+PP), Convert.ToSingle(-B / 2 + Denine + PP), Convert.ToSingle(H -2* Denine -2* PP), Convert.ToSingle(B -2* Denine -2* PP));
            gr.DrawRectangle(p, Convert.ToSingle(-H / 2+PP), Convert.ToSingle(-B / 2+PP), Convert.ToSingle(H-2*PP), Convert.ToSingle(B-2*PP));
        }
        void Donaticiz()
        {
            Graphics gr = cizbox.CreateGraphics();

            gr.TranslateTransform(cizbox.Width / 2, cizbox.Height / 2);
            gr.RotateTransform(-90);
            gr.ScaleTransform(sf, sf);
            float basust, bitust, basalt, bitalt, basara, bitara;
            SolidBrush brush = new SolidBrush(Color.Navy);
            basust =Convert.ToSingle( -B / 2 + PP + Denine);
            bitust = Convert.ToSingle( B / 2 - PP  - Denine-Dust);
            double nu = (bitust - basust) / (Nust - 1);
            for (int i = 0; i < Nust; i++)
            {
                gr.FillEllipse(brush, Convert.ToSingle(H / 2 - PP - Denine), basust + Convert.ToSingle(i * nu), Convert.ToSingle(-Dust), Convert.ToSingle(Dust));
            }

            basalt = Convert.ToSingle(-B / 2 + PP + Denine);
            bitalt = Convert.ToSingle(  B / 2 - PP - Denine - Dalt);
            double nua = (bitalt - basalt) / (Nalt - 1);

            for (int i = 0; i < Nalt; i++)
            {
                gr.FillEllipse(brush, Convert.ToSingle(-H / 2 + PP + Denine), basalt + Convert.ToSingle(i * nua), Convert.ToSingle(Dalt), Convert.ToSingle(Dalt));
            }
            basara = Convert.ToSingle(-H / 2 + PP + Denine + Dalt / 2);
            bitara = Convert.ToSingle(  H / 2 - PP - Denine - Dust / 2);
            double nuara = (bitara - basara) / (Nara + 1);
            double bas = basara + nuara;
            for (int i = 0; i < Nara; i++)
            {

                gr.FillEllipse(brush, Convert.ToSingle(bas - Dara / 2) + Convert.ToSingle(nuara) * i, Convert.ToSingle(-B / 2 + PP + Denine), Convert.ToSingle(Dara), Convert.ToSingle(Dara));
                gr.FillEllipse(brush, Convert.ToSingle(bas - Dara / 2) + Convert.ToSingle(nuara) * i, Convert.ToSingle(B / 2 - PP - Denine), Convert.ToSingle(Dara), Convert.ToSingle(-Dara));
            }


        }
        void Meshciz()
        {
            Graphics gr = cizbox.CreateGraphics();
            Pen p = new Pen(Color.White, 1);
            Pen ax = new Pen(Color.Red, 0.5f);
            Pen inc = new Pen(Color.Yellow, 1);
            ax.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gr.TranslateTransform(cizbox.Width / 2, cizbox.Height / 2);
            gr.RotateTransform(-90);
            gr.ScaleTransform(sf, sf);
            float h1 = Convert.ToSingle((H) / MeshY);
            float b1 = Convert.ToSingle((B) / MeshX);

            for (int i = 0; i < MeshY; i++)
            {
                for (int j = 0; j < MeshX; j++)
                {
                    gr.DrawRectangle(inc, Convert.ToSingle( -H / 2)+i*h1, Convert.ToSingle(-B / 2)+j*b1,h1,b1);
                }
            }

        }




        void cizimcrzX(double X_crz)
        {


            Graphics grx = cizbox.CreateGraphics();
            Pen p = new Pen(Color.White, Convert.ToSingle(Denine));
      
            grx.TranslateTransform(cizbox.Width / 2, cizbox.Height / 2);
            grx.RotateTransform(-90);
            grx.ScaleTransform(sf, sf);
            grx.DrawLine(p,Convert.ToSingle( -H / 2 + PP + Denine), Convert.ToSingle(X_crz), Convert.ToSingle(H / 2 - PP - Denine), Convert.ToSingle(X_crz));
           
        }
        void Ciryciz(double ycir)
        {
            Graphics gry = cizbox.CreateGraphics();
            Pen p = new Pen(Color.White, Convert.ToSingle(Denine));

            gry.TranslateTransform(cizbox.Width / 2, cizbox.Height / 2);
            gry.RotateTransform(-90);
            gry.ScaleTransform(sf, sf);
            gry.DrawLine(p, Convert.ToSingle(ycir), Convert.ToSingle(-B / 2 + PP + Denine), Convert.ToSingle(ycir), Convert.ToSingle(B / 2 - PP - Denine));
        }

 

        private void clearButt_Click(object sender, EventArgs e)
        {

            ÇirozKoordX.Clear();
            ÇirozKoordY.Clear();
            crz_X.Items.Clear();
            cir_Y.Items.Clear();
            cizbox.Invalidate();
            button2.Enabled = true;
            analizgec.Enabled = false;
            clearButt.Enabled = false;
            meshButton.Enabled = false;
        }

        private void meshButton_Click(object sender, EventArgs e)
        {

            Meshciz();
        }
        private void button2_Click(object sender, EventArgs e)
        {


            Atama();
            Kesitciz();
            Donaticiz();
            analizgec.Enabled = true;
            clearButt.Enabled = true;
            meshButton.Enabled = true;
            for (int i = 1; i < Nust - 1; i++)
            {
                crz_X.Items.Add((-B / 2 + Denine + PP + Dust / 2 + i * (B - 2 * PP - 2 * Denine - Dust) / (Nust - 1)).ToString());
            }
            for (int i = 1; i <= Nara; i++)
            {
                cir_Y.Items.Add((-H / 2 + PP + Denine + Dalt / 2 + i * (H - 2 * PP - 2 * Denine - Dalt / 2 - Dust / 2) / (Nara + 1)).ToString());
            }
            button2.Enabled = false;
        }

        private void analizgec_Click(object sender, EventArgs e)
        {
            analiz frm2 = new analiz();
            frm2.Show();
        }

        private void cirXekle_Click(object sender, EventArgs e)
        { 
            double X_crz = Convert.ToDouble(crz_X.Text);
            ÇirozKoordX.Add(X_crz);
            cizimcrzX(X_crz);
        }

        private void cirYekle_Click(object sender, EventArgs e)
        {
            double Y_crz = Convert.ToDouble(cir_Y.Text);
            ÇirozKoordY.Add(Y_crz);
            Ciryciz(Y_crz);
        }
    }
}
