using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Chis_Method
{

    public partial class DrawMethodForm : Form
    {

        const double a = 0;
        const double b = 2;

        int StartReal = 6;
        int RealPoints = 6;
        int maxRealPoints = 42;
        const int move_Down_Window = 25;
        const int move_X = 50;
        const int move_Y = 50;



        const int Count_Points = 21;
        int maxX = 5;
        double maxY = 0.005;
        int howmuchcancount = 20;

        double h;
        double mistake = Math.Pow(10, -6);
        double argument = 2 / Math.Sqrt(Math.PI);

        
        
       
        double[,] points;
        double[,] ar;

        PointF Start,End_Y,End_X,Step_X,Step_Y;

        Pen GraphicPen = new Pen(Color.Blue,2);
        Pen CoordinatPen = new Pen(Color.White,2);
        Pen PointsPen = new Pen(Color.Gold, 2);
        Pen CoorDinatsPointPen = new Pen(Color.Red, 2);

        public DrawMethodForm()
        {
            InitializeComponent();
        }

        private void AmountPoints_TrackBar_Scroll(object sender, EventArgs e)
        {
            //Count_Points = AmountPoints_TrackBar.Value;
            PointAmount_TextBox.Text = AmountPoints_TrackBar.Value.ToString();
            Refresh();
        }

        private void PointAmount_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(PointAmount_TextBox.Text, out int result)
                && result >= AmountPoints_TrackBar.Minimum
                && result <= AmountPoints_TrackBar.Maximum)
            {
                AmountPoints_TrackBar.Value = result;
                //Count_Points = result;
                Refresh();
            }
            else
                PointAmount_TextBox.Text = Count_Points.ToString();
        }

        private void DrawMethodForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        #region Math
        double Fx(double x)
        {
            double y,k;
            int n = 0;
            y = 0;
            k = x;
            while (Math.Abs(k) > mistake)
            {
                y += k;
                k *= Find_q(x, n);
                n++;
            }
            y *= argument;

            return y;
        }
        double Find_q(double x,int n)
        {
            return -(x * x * (2 * n + 1)) / ((n + 1) * (2 * n + 3));
        }
        void FillKefPolinomMass(double[,] Fx)
        {
            double delitel;
            for (int j = 1; j < Fx.GetLength(0); j++)
            {
                for (int i = Fx.GetLength(0) - 1; i >= j; i--)
                {
                    delitel = (Fx[i, 0] - Fx[i - j, 0]);
                    Fx[i, 1] = (Fx[i, 1] - Fx[i - 1, 1]) / delitel;
                }
            }
            ar = Fx;
            return;
        }
        double GetPolinom(double x)
        {
            double y = ar[ar.GetLength(0) - 1, 1];
            for (int i = ar.GetLength(0) - 2; i >= 0; i--)
                y = ar[i, 1] + (x - ar[i, 0]) * y;
            return y;
        }
        void DoMath()
        {
            points = new double[maxRealPoints-RealPoints+1, 2];

            //h = (b - a) / (RealPoints - 1);

            //ar = new double[RealPoints, 2];
            //for(int i = 0; i < RealPoints; i++)
            //{
            //    ar[i, 0] = a + i * h;
            //    ar[i, 1] = Fx(a + i * h);
            //}
            //FillKefPolinomMass(ar);
            double maxer,maxmaxer,m;
            int t = 0;
            maxmaxer = 0;
            for (int RealPoints = StartReal; RealPoints <= maxRealPoints; RealPoints++)
            {
                h = (double)(b - a) / (RealPoints - 1);

                ar = new double[RealPoints, 2];
                for (int i = 0; i < RealPoints; i++)
                {
                    ar[i, 0] = a + i * h;
                    ar[i, 1] = Fx(a + i * h);
                }
                FillKefPolinomMass(ar);
                h = (double)(b - a) / (Count_Points - 1);
                maxer = 0;

                for (double x = a; x < b + mistake; x += h)
                {
                    if (Math.Abs(GetPolinom(x) - Fx(x)) > maxer)
                    {
                        maxer = Math.Abs(GetPolinom(x) - Fx(x));
                    }
                }
                points[t, 0] = RealPoints;
                points[t, 1] = maxer;
                t++;
                if (maxer > maxmaxer)
                {
                    maxmaxer = maxer;
                }

            }


            //for (int i = 2; i < Count_Points; i++)
            //{
            //    maxer = 0;
            //    h = (b - a) / (i - 1);
            //    for(double j = a; j <= b + mistake; j += h)
            //        if (maxer < Math.Abs(Fx(j) - GetPolinom(j)))
            //            maxer= Math.Abs(Fx(j) - GetPolinom(j)); 

            //    points[i, 0] = i;
            //    points[i, 1] = maxer;
            //    if (maxer>maxmaxer)
            //        maxmaxer = maxer;

            //}
            m = 1;
            while (maxmaxer < 1)
            {
                m--;
                maxmaxer *= 10;
            }

            maxY = Math.Pow(10, m);

            // Для рисования штуки
            maxX = maxRealPoints;
            Start = new PointF(move_X, Height - move_Y- move_Down_Window);
            End_X = Start.Plus(new PointF(Width - move_X * 2, 0));
            End_Y = Start.Minus(new PointF(0, Height - move_Y * 2));
            Step_X = End_X.Minus(Start).Divide((float)(maxX*(1+1*0.2/howmuchcancount)));
            Step_Y = End_Y.Minus(Start).Divide((float)(maxY*(1+0.2)));
            
        }
        #endregion
        private void MethodDraw_Paint(object sender, PaintEventArgs e)
        {
            int i;
            PointF f2,f1;

            Graphics graphics = e.Graphics;
            DoMath();
            graphics.Clear(Color.Black);

            graphics.DrawLine(CoordinatPen, Start, End_X);
            graphics.DrawLine(CoordinatPen, Start, End_Y);
            
            int kefir = maxX / howmuchcancount > 0 ? maxX / howmuchcancount : 1;
            for(i = kefir; i <= maxX; i+=kefir)
            {
                graphics.DrawString(i.ToString(), Font, CoordinatPen.Brush, Start.Plus(Step_X.Multiply(i)));
                graphics.FillEllipse(CoorDinatsPointPen.Brush, Start.Plus(Step_X.Multiply(i)).X - 1, Start.Plus(Step_X.Multiply(i)).Y - 2, 3, 3);
            }
            
            for(double a = maxY / 10; a <= maxY + mistake; a += maxY / 10)
            {
                graphics.DrawString(a.ToString(), Font, CoordinatPen.Brush, Start.Plus(Step_Y.Multiply(a)).Minus(new Point(7 * a.ToString().Length, 0)));
                graphics.FillEllipse(CoorDinatsPointPen.Brush, Start.Plus(Step_Y.Multiply(a)).X - 2, Start.Plus(Step_Y.Multiply(a)).Y - 1, 3, 3);
            }
           
            f1 = Start.Plus(Step_Y.Multiply((float)points[0, 1])).Plus(Step_X.Multiply((float)points[0, 0]));

            for (i = 1; i <= maxRealPoints - StartReal; i++)
            {
                f2 = Start.Plus(Step_Y.Multiply((float)points[i, 1])).Plus(Step_X.Multiply((float)points[i, 0]));
                graphics.DrawLine(GraphicPen, f1, f2);
                f1 = f2;
            }
            for (i = 0; i <= maxRealPoints - StartReal; i++)
            {
                f1 = Start.Plus(Step_Y.Multiply((float)points[i, 1])).Plus(Step_X.Multiply((float)points[i, 0]));
                graphics.FillEllipse(PointsPen.Brush, f1.X - 1, f1.Y - 1, 3, 3);
            }
        }
    }
}
