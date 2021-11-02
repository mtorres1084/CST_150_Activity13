using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

// Author: Miguel Torres Perez
// CST-150
// Professor Smithers

namespace CST_150_Activity13
{
    public class Class1
    {
        public static Graphics graphics;
        public Class1(Graphics g)
        {
            graphics = g;
            setUpCanvas();
        }
        public static void setUpCanvas()
        {
            Brush background = new SolidBrush(Color.White);
            Pen lines = new Pen(Color.Black, 5);
            graphics.FillRectangle(background, new Rectangle(0, 0, 500, 600));
            graphics.DrawLine(lines, new Point(167, 0), new Point(167, 500));
            graphics.DrawLine(lines, new Point(334, 0), new Point(334, 500));
            graphics.DrawLine(lines, new Point(0, 167), new Point(500, 167));
            graphics.DrawLine(lines, new Point(0, 334), new Point(500, 334));

        }
        public static void DrawX(Point location)
        {
            Pen xPen = new Pen(Color.Blue, 5);
            int xAbs = location.X * 167;
            int yAbs = location.Y * 167;
            graphics.DrawLine(xPen, xAbs + 10, yAbs + 10, xAbs + 147, yAbs + 147);
            graphics.DrawLine(xPen, xAbs + 147, yAbs + 10, xAbs + 10, yAbs + 147);
        }
        public static void drawO(Point location)
        {
            Pen oPen = new Pen(Color.Red, 5);
            int xAbs = location.X * 167;
            int yAbs = location.Y * 167;
            graphics.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 147, 147);

        }
    }
}
