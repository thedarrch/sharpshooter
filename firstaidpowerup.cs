using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public class firstaidpowerup:powerup
    {
        public firstaidpowerup(PointF startlocation)
            : base("images/HealthPack.png", startlocation)
        {

        }
        public override void onpickup()
        {
            MainForm.player1.takedamage(-30);
            this.destroy();
        }
    }
}
