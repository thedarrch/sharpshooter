using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class powerup:game_object

    {
        public powerup(string filename, PointF startlocation): base( startlocation,filename, 1, 1f)
        {
        }
            public abstract void onpickup();

    }
}
