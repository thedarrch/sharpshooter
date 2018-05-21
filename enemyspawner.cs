using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public class enemyspawner : powerup
    {
        float spawncounter, spawninterval;

        public enemyspawner(PointF startlocation)
            : base("images/HealthPack.png", startlocation)
        {
            spawninterval = 10;
            spawncounter = spawninterval;
        }
        public override void onpickup()
        {
        }
        public override void draw(Graphics g)
        {
        }
        public override void update(float time)
        {
            base.update(time);
            spawncounter -= time;
            if (spawncounter < 0)
            {
                spawncounter = spawninterval;
                MainForm.enemylist.Add(new eliteenemy(new PointF(this.location.X, this.location.Y), new List<PointF>()));
            }
           
        }
    }
}
