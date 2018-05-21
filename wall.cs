using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DarrenSHARPSHOOTER
{
    public class wall
    {
        public int left, top, width, height;
        Bitmap img;

        public wall(int l, int t, int w, int h)
        {
            left = l;
            top = t;
            width = w;
            height = h;
            img = new Bitmap("Images/bluebox.png");
        }

        public void draw(Graphics g)
        {
            g.Transform = new Matrix();
            g.DrawImage(img, new Rectangle(left - MainForm.viewoffset.X, top - MainForm.viewoffset.Y, width, height));


        }
        public PointF pointnearestto(game_object dobject)
        {
            PointF nearestpoint = new PointF();
            //gives closest x to guy on wall
            if (dobject.getx() < this.left)
            {
                nearestpoint.X = this.left;
            }
            else if (dobject.getx() > this.left + this.width)
            {
                nearestpoint.X = this.left + this.width;
            }
            else
            {
                nearestpoint.X = dobject.getx();
            }

            //gives closest y point to guy on wall
            if (dobject.gety() < this.top)
            {
                nearestpoint.Y = this.top;
            }
            else if (dobject.gety() > this.top + this.height)
            {
                nearestpoint.Y = this.top + this.height;
            }
            else
            {
                nearestpoint.Y = dobject.gety();
            }

            return nearestpoint;
        }
    }
}
