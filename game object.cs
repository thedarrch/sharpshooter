using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class game_object
    {
        protected Picture img;
        protected PointF location;
        protected bool delete;
        protected float radius;

        public game_object(PointF startlocation, string filename, int totalframe, float fliptime)
        {
            location = startlocation;
            img = new Picture(filename, startlocation, totalframe, fliptime);
            radius = img.bmp.Width / 2f;
        }

        public virtual void draw(Graphics g)
        {
            img.location.X = location.X - MainForm.viewoffset.X;
            img.location.Y = location.Y - MainForm.viewoffset.Y;
            img.draw(g);
        }
        public virtual void update(float time)
        {
            img.update(time);
        }
        public bool istouching(game_object otherobject)
        {
            float distance = (float)Math.Sqrt((otherobject.getx() - this.location.X) * (otherobject.getx() - this.location.X)
                + (otherobject.gety() - this.location.Y) * (otherobject.gety() - this.location.Y));
            return distance <= this.radius + otherobject.getradius();


        }
        public float getx()
        {
            return location.X;
        }
        public float gety()
        {
            return location.Y;
        }
        public float getradius()
        {
            return radius;
        }
        public bool isdead()
        {
            return delete;
        }
        public void destroy()
        {
            delete = true;
        }
        public bool istouchingwall(wall w)
        {
            PointF nearest = w.pointnearestto(this);
            float distance = (float)Math.Sqrt((nearest.X - this.location.X) * (nearest.X - this.location.X)
               + (nearest.Y - this.location.Y) * (nearest.Y - this.location.Y));
            return (this.radius > distance);

        }
        public static bool checklineintersection(float x1, float y1, float x2, float y2, float X1, float Y1, float X2, float Y2)
        {
            //cant use formula if parallel lines
            //if not parallel - find intersection
            //make sure it is on line segment (not infinite line)
            float m, M, b, B;
            float xintersection, yintersection;
            if ((x2 != x1) && (X2 != X1))
            {
                m = (y2 - y1) / (x2 - x1);
                M = (Y2 - Y1) / (X2 - X1);
                b = y1 - m * x1;
                B = Y1 - M * X1;

                if (m == M)
                {
                    return false;
                }
                
                xintersection = -(B - b) / (M - m);
                yintersection = m * xintersection + b;
                
            }
            else
            {
                if (x1 == x2 && X1 == X2)
                {
                    return false;
                }
                else  if (x1 == x2)
                {
                    M = (Y2 - Y1) / (X2 - X1);
                    B = Y1 - M * X1;
                    xintersection = x1;
                    yintersection = M * x1 + B;
                }
                else 
                {
                    m = (y2 - y1) / (x2 - x1);
                    b = y1 - m * x1;
                    xintersection = X1;
                    yintersection = m * X1 + b;
                }
            }

            if (!(x1 <= xintersection && xintersection <= x2) && !(x2 <= xintersection && xintersection <= x1))
            {
                return false;
            }
            if (!(y1 <= yintersection && yintersection <= y2) && !(y2 <= yintersection && yintersection <= y1))
            {
                return false;
            }

            if (!(X1 <= xintersection && xintersection <= X2) && !(X2 <= xintersection && xintersection <= X1))
            {
                return false;
            }

            if (!(Y1 <= yintersection && yintersection <= Y2) && !(Y2 <= yintersection && yintersection <= Y1))
            {
                return false;
            }
            return true;

        }
    }
}
