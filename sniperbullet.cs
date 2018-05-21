using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class sniperbullet : Bullets
    {
        public sniperbullet(PointF startlocation, float a, soldier o)
            : base(startlocation, "images/Bullet3.png", 4, 0.025f, a, o, 1200)
        {
            damage = 70;
           
            life = 3;
        }
    }
}
