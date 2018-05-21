using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace DarrenSHARPSHOOTER
{
    public abstract class dynamic_object : game_object //parent
    {
        protected PointF velocity;
        public float movespeed;
        public float angle;

        public dynamic_object(PointF startlocation, string filename, int totalframe, float fliptime)
            : base(startlocation, filename, totalframe, fliptime) //use parent constructor
        {
            velocity = new PointF();
            angle = 0;
        }
        public virtual void move(float time)
        {
            location.X += velocity.X*time;
            location.Y += velocity.Y*time;

        }
        public override void draw(Graphics g)
        {
            img.angle = angle;
            base.draw(g);
           
        }
        public override void update(float time)
        {
            if (velocity.X != 0 || velocity.Y != 0) //velocity x is not 0 OR velocity y is not 0
            {
                img.update(time);
            }

            if (delete == false)
            {
                velocity.X = (float)(movespeed * Math.Cos(angle * Math.PI / 180));
                velocity.Y = -(float)(movespeed * Math.Sin(angle * Math.PI / 180));
                move(time);
            }
            angle = angle % 360;
        }
    }
}
