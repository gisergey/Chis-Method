using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chis_Method
{
    internal static class PointOperations
    {
        public static double length(this PointF p1)
        {
            return Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
        }
        public static PointF Plus(this PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static PointF Minus(this PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static PointF Multiply(this PointF p1, float mult)
        {
            return new PointF(p1.X * mult, p1.Y * mult);
        }
        public static PointF Multiply(this PointF p1, double mult)
        {
            return new PointF((float)(p1.X * mult), (float)(p1.Y * mult));
        }
        public static PointF Divide(this PointF p1, float divid)
        {
            return new PointF(p1.X / divid, p1.Y / divid);
        }
        public static bool More_Than(this PointF p1, PointF p2)
        {
            if (p1.length() > p1.length())
                return true;
            return false;
        }
    }
}
