using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class easyenemy : enemy
    {
        public easyenemy(PointF startlocation, List<PointF> path)
            : base(startlocation, "images/enemy1.png", path)
        {
            movespeed = 300;
            maxhp = 25;
            currhp = maxhp;
            gun = new pistol(this);
            gun.startfiring();
            turnspeed = 450;

        }
        public override void getaction(float time)
        {
            travelpath(time);

        }
    }
}
