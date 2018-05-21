using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class soldier : dynamic_object
    {
        protected bool isfiring;
        public int currhp, maxhp;
        protected weapon gun;
        protected float turnspeed; 

        public soldier(PointF startlocation, string filename)
            : base(startlocation, filename, 4, 0.060f)
        {

            isfiring = false;

        }

        public override void update(float time)
        {
            base.update(time);
            gun.update(time, location, angle);

        }
        public void pushfrom(PointF nearestpoint)
        {
            PointF direction = new PointF();
            direction.X = this.location.X - nearestpoint.X;
            direction.Y = this.location.Y - nearestpoint.Y;

            float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            if (length != 0)
            {
                direction.X /= length;
                direction.Y /= length;
                direction.X *= (this.radius + 1);
                direction.Y *= (this.radius + 1);
                this.location.X = nearestpoint.X + direction.X;
                this.location.Y = nearestpoint.Y + direction.Y;
            }


        }
        public void takedamage(int damage)
        {
            currhp -= damage;
            if (currhp <= 0)
            {
                this.destroy();
            }
        }
        public override void draw(Graphics g)
        {
            base.draw(g);
            gun.draw(g);

        }
    }
}

