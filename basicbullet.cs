using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class basicbullet:Bullets
    {
        public basicbullet(PointF startlocation, float a, soldier o): base(startlocation, "images/Bullet1.png", 4, 0.025f, a, o, 800)
        {
            damage = 10;
           
            life = 1;
        }
    }
}
