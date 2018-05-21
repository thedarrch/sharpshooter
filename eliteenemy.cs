using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class eliteenemy:enemy
    
    {
        public eliteenemy(PointF startlocation, List<PointF> path): base(startlocation, "images/enemy2.png", path){
            movespeed = 300;
            maxhp = 60;
            currhp = maxhp;
            gun = new machinegun(this);
            gun.startfiring();
            turnspeed = 360; //(degs/se)

    }
        public override void getaction(float time)
        {
            lookforplayer(time);

        }
    }
}

    