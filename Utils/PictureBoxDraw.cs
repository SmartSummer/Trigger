using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TriggerBigImage.Utils
{
    public class PictureBoxDraw
    {

        public static void DrawCirle(ref PictureBox pb, double dim, Pen p)
        {

            Graphics g = pb.CreateGraphics();

            // g.Clear(Color.Black);
            pb.Refresh();
            g.DrawEllipse(p, 200, 200, 100, 100);

            g.Dispose();

        }

        public static void DrawRect(ref PictureBox pb, Point start, Point end, Pen p)
        {

            Graphics g = pb.CreateGraphics();
            pb.Refresh();
            // g.Clear(Color.Black);
            Rectangle rect = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            g.DrawRectangle(p, rect);

            g.Dispose();

        }

        public static void DrawRect( PictureBox pb, Point start, Point end, Pen p)
        {

            Graphics g = pb.CreateGraphics();
            pb.Refresh();
            // g.Clear(Color.Black);
            Rectangle rect = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            g.DrawRectangle(p, rect);

            g.Dispose();

        }
    }

}
