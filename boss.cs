using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class boss : enemy
    {
        public boss(PointF startlocation, List<PointF> path)
            : base(startlocation, "images/RedBossTank.png", path)
        {
            movespeed = 0;
            maxhp = 300;
            currhp = maxhp;
            gun = new hominggun(this);
            gun.startfiring();
            turnspeed = 300;

        }
        public override void getaction(float time)
        {
            lookforplayer(time);

        }
        public override void draw(Graphics g)
        {
            img.angle = angle;
            img.location.X = location.X - MainForm.viewoffset.X;
            img.location.Y = location.Y - MainForm.viewoffset.Y;
            img.draw(g);

        }
    }
}
