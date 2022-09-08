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
        
        int Count_Points = 11;
        double h;
        double mistake = Math.Pow(10, -6);

        PointF Start,End_Y,End_X,Step_X,Step_Y;

        Pen GraphicPen = new Pen(Color.Blue,2);
        Pen CoordinatPen = new Pen(Color.Purple,2);
        Pen PointsPen = new Pen(Color.Gold, 2);

        public DrawMethodForm()
        {
            
            InitializeComponent();
         
        }

        private void AmountPoints_TrackBar_Scroll(object sender, EventArgs e)
        {
            Count_Points = AmountPoints_TrackBar.Value;
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
                Count_Points = result;
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
        double Find_q(double x,int n)
        {
            return -(x * x * (2 * n + 1)) / ((n + 1) * (2 * n + 3));
        } 
        void DoMath()
        {
            h = (b - a) / (Count_Points - 1);
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
            int i = 0;
            for (x = a; x <= b+mistake; x += h)
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
                    i++; 
                    graphics.DrawLine(GraphicPen, f1.Value, f2);
                    graphics.FillEllipse(PointsPen.Brush, f1.Value.X-1, f1.Value.Y-1, 3, 3);
                }
                f1 = f2;
                f2 = f2.Plus(step_xh);
            }
            f2=f2.Minus(step_xh);
            
            graphics.FillEllipse(PointsPen.Brush, f2.X - 1, f2.Y - 1, 3, 3);

            if (i == Count_Points)
            {
                MessageBox.Show(i.ToString());
            }
        }
    }
}
