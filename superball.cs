using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public class superball : Bullets
    {
        public superball(PointF startlocation, float a, soldier o)
            : base(startlocation, "images/SuperBall.png", 4, 0.025f, a, o, 400)
        {
            damage = 25;
            
            life = 8;
        }
    }

}
