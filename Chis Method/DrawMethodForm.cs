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
        const int move_X = 50;
        const int move_Y = 50;
        Dictionary<int, double> mapint = new Dictionary<int, double>() { {1, 0.4 },
            {2,0.1 },
            {3,0.2 },
            {5,0.2 },
            {6,0.1 }
        };

        int Count_Points = 11;
        double h;
        double mistake = Math.Pow(10, -6);
        static double argument = 2 / Math.Sqrt(Math.PI);

        PointF Start,End_Y,End_X,Step_X,Step_Y;

        Pen GraphicPen = new Pen(Color.Blue,2);
        Pen CoordinatPen = new Pen(Color.Green,2);
        Pen PointsPen = new Pen(Color.Yellow, 2);
        Color back = Color.Black;
        public DrawMethodForm()
        {
            InitializeComponent();
        }
        private void DrawMethodForm_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        #region Math

        void DoMath()
        {
            h = (b - a) / (Count_Points - 1);
            Start = new PointF(move_X, Height - move_Y- move_Down_Window);
            End_X = Start.Plus(new PointF(Width - move_X * 2, 0));
            End_Y = Start.Minus(new PointF(0, Height - move_Y * 2));
       
            Step_X = End_X.Minus(Start).Divide((float)(mapint.Keys.Max()+0.2));
            Step_Y = End_Y.Minus(Start).Divide((float)1.2);
        }
        #endregion
        private void MethodDraw_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DoMath();
            graphics.Clear(back);

            graphics.DrawLine(CoordinatPen, Start, End_X);
            graphics.DrawLine(CoordinatPen, Start, End_Y);

            for (int j = 0; j <= mapint.Keys.Last(); j++)
            {
                graphics.DrawString(j.ToString(), Font, CoordinatPen.Brush, Start.Plus(Step_X.Multiply(j)));
            }

          
            
            graphics.DrawString("1", Font, CoordinatPen.Brush, Start.Plus(Step_Y));

            //graphics.DrawLine(GraphicPen,new PointF(0,Start.Y),Start.Plus(Step_X.Multiply(mapint.Keys.First())));
            graphics.DrawLine(GraphicPen, Start.Plus(Step_X.Multiply(mapint.Keys.Last())).Plus(Step_Y), new PointF(Width,Start.Y+Step_Y.Y));

            double kefir=0;
            PointF LastF = new PointF(0, Start.Y);
            PointF p1;
            foreach(int number in mapint.Keys)
            {
                p1 = Start.Plus(Step_X.Multiply(number)).Plus(Step_Y.Multiply((float)kefir));

                graphics.DrawLine(GraphicPen,LastF, p1);

                LastF = Start.Plus(Step_X.Multiply(number)).Plus(Step_Y.Multiply((float)(kefir + mapint[number])));

                graphics.DrawLine(GraphicPen,p1,LastF);
                kefir += mapint[number];
            }
        }
    }
}
