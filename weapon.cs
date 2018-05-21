using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class weapon
    {
        protected float firedelay = 0.1f;
        protected soldier owner;
        protected Picture img;
        protected float angle, timesincelastshot, bulletstartdistance;
        protected PointF location;
        protected bool isfiring;
        readonly float WEAPONOFFSET = 32f;

        public weapon(string filename, soldier o)
        {
            owner = o;
            location = new PointF(owner.getx(), owner.gety());
            img = new Picture(filename, location, 1, 1);
            
        }
        public weapon(string filename, PointF startlocation)
        {
            owner = null;
            location = new PointF(startlocation.X, startlocation.Y);
            img = new Picture(filename, location, 1, 1);

        }
        public void draw(Graphics g)
        {
            img.location.X = location.X - MainForm.viewoffset.X;
            img.location.Y = location.Y - MainForm.viewoffset.Y; 
            img.angle = angle;
            img.draw(g);
        }
        public void update(float time, PointF location, float angle)
        {
           
            this.angle = angle;
            float xoffset = WEAPONOFFSET * (float)Math.Cos(angle*Math.PI/180);
            float yoffset = - WEAPONOFFSET * (float)Math.Sin(angle*Math.PI/180);
            this.location.X = location.X +xoffset;
            this.location.Y = location.Y +yoffset;
            timesincelastshot += time;
            if (isfiring == true && timesincelastshot > firedelay && owner.isdead() == false)
            {
                
                fire();
            }

        }
        public abstract void fire();

        public void startfiring()
        {
            isfiring = true;
        }
        public void stopfiring()
        {
            isfiring = false;
        }
        public abstract string getfile();

        public void setowner(soldier s)
        {
            owner = s;
        }
    }

}
