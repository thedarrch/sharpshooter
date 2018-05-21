using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class Bullets : dynamic_object
    {

       protected float life;
         float MAXLIFE = 1;
        soldier owner;
        public int damage;
        

        public Bullets(PointF startlocation, string filename, int totalframe, float fliptime, float a, soldier o, float movespeed)
            : base(startlocation, filename, totalframe, fliptime)
        {
            angle = a;
            owner = o;
            
            delete = false;
            this.movespeed = movespeed;
            velocity.X = (float)(movespeed * Math.Cos(angle * Math.PI / 180));
            velocity.Y = -(float)(movespeed * Math.Sin(angle * Math.PI / 180));
            
        }

        public override void update(float time)
        {
            img.update(time);
            move(time);
            life -= time;
            if (life <= 0)
            {
                delete = true;
            }

        }
        public soldier getowner()
        {
            return owner;
        }
        public void bouncefrom(PointF nearest)
        {
            PointF normal = new PointF();
            normal.X = -location.X + nearest.X;
            normal.Y = -location.Y +nearest.Y;
            //defines normal
            float length = (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y);
            //defines length of normal
            if (length !=0)
            {
            normal.X /= length;
            normal.Y /= length;
            //normal becomes unit vector
            float dotproduct = (normal.X * this.velocity.X) + (normal.Y * this.velocity.Y);
            //dotprod of norm and velo is taken 
            normal.X *= dotproduct;
            normal.Y *= dotproduct;
            //now have velocity component in normal direction
            this.velocity.X -= 2 * normal.X;
            this.velocity.Y -= 2 * normal.Y;
            //bullets now bounce at the correct angle
            }
        }
        public void backupposition(float time)
        {
            //makes bullet revert to prev position
            this.location.X -= this.velocity.X*time;
            this.location.Y -= this.velocity.Y*time;
        }
        public int getdamage()
        {
            return damage;
        }
        public virtual void hittarget(soldier s)
        {
            s.takedamage(this.damage);
            this.destroy();
        }
        public virtual void hitwall(wall w)
    {
        bouncefrom(w.pointnearestto(this));
    }
        
    }
}
