using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class weaponpowerup: powerup
    {
        weapon weaponcontained;

        public weaponpowerup(PointF startlocation, weapon w): base(w.getfile(), startlocation)
        {
            weaponcontained = w;
        }
        public override void onpickup()
        {
            MainForm.player1.pickupweapon(weaponcontained);
            this.destroy();
           
        }
    }
}
