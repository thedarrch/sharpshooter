using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class hominggun: weapon
    {
        public hominggun(soldier o): base("images/pistol.png", o)
        {
            firedelay = 0.5f;
            bulletstartdistance = 10;
        }
        public hominggun(PointF location)
            : base("images/TankGUn.png", location)
        {
            firedelay = 0.5f;
            bulletstartdistance = 10;
        }
        public override void fire()
        {
            
            PointF bulletstart = new PointF();
            bulletstart.X = location.X + bulletstartdistance * (float)Math.Cos(angle * Math.PI / 180);
            bulletstart.Y = location.Y - bulletstartdistance * (float)Math.Sin(angle * Math.PI / 180);
            Bullets b = new homingbullet(bulletstart, angle, owner);
           
            MainForm.bulletlist.Add(b);
            timesincelastshot = 0;
        }
        public override string getfile()
        {
            return "images/TankGun.png";
        }
    }
}
