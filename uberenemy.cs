using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace DarrenSHARPSHOOTER
{
       class uberenemy:enemy
    
    {
        public uberenemy(PointF startlocation, List<PointF> path): base(startlocation, "images/enemy3.png", path){
            movespeed = 300;
            maxhp = 60;
            currhp = maxhp;
            gun = new sniper(this);
            gun.startfiring();
            turnspeed = 360;
          

    }
        public override void getaction(float time)
        {
            lookforplayer(time);
            
            

        }
    }
}


