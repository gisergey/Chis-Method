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
        

        /*
        хуйня какая-то, почемуто у формы как будто снизу еще невидимые 25 пикселей лежат,
        которые в высоту учитываются,
        но не показываются, поэтому есть move_Down_Window константа*/
        const int move_Down_Window = 25;
        const int Count_Points = 250;
        const int move_X = 50;
        const int move_Y = 50;

        double h;
        double mistake = Math.Pow(10, -6);

        PointF Start,End_Y,End_X,Step_X,Step_Y;

        Pen GraphicPen = new Pen(Color.Blue,2);
        Pen CoordinatPen = new Pen(Color.Purple,2);

        public DrawMethodForm()
        {
            h = (b - a) / (Count_Points - 1);
            InitializeComponent();
         
        }

        private void DrawMethodForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        #region Math
        double Find_q(double x,int n)
        {
            return -(x * x * (2 * n + 1)) / ((n + 1) * (2 * n + 3));
        } 
        void DoMath()
        {
            Start = new PointF(move_X, Height - move_Y- move_Down_Window);
            End_X = Start.Plus(new PointF(Width - move_X * 2, 0));
            End_Y = Start.Minus(new PointF(0, Height - move_Y * 2));
            Step_X = End_X.Minus(Start).Divide((float)2.2);
            Step_Y = End_Y.Minus(Start).Divide((float)1.2);
        }
        #endregion
        private void MethodDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DoMath();
            graphics.Clear(Color.Black);

            graphics.DrawLine(CoordinatPen, Start, End_X);
            graphics.DrawLine(CoordinatPen, Start, End_Y);
            
            graphics.DrawString("1", Font, CoordinatPen.Brush, Start.Plus(Step_X));
            graphics.DrawString("2", Font, CoordinatPen.Brush, Start.Plus(Step_X).Plus(Step_X));
            graphics.DrawString("1", Font, CoordinatPen.Brush, Start.Plus(Step_Y));

            double y, k, x;
            int n;
        
            
            PointF  f2,step_xh;
            PointF? f1 = null;
            step_xh = Step_X.Multiply((float)(h / (b - a)*2));
            f2 = Start;
            for (x = a; x <= b; x += h)
            {
                y = 0;
                n = 0;
                k = x;
                while (Math.Abs(k) > mistake)
                {
                    y += k;
                    k *= Find_q(x,n);
                    n++;
                }
                y *= 2;
                y /= Math.PI;
                f2.Y=Start.Y+Step_Y.Multiply((float)y).Y;
                if(f1 != null)
                {

                    graphics.DrawLine(GraphicPen, f1.Value, f2);
                }
                f1 = f2;
                f2 = f2.Plus(step_xh);
            
            }

        }
    }
}
