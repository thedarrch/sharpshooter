using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class tripleshot : weapon
    {

        public tripleshot(soldier o)
            : base("images/RapidGun.png", o)
        {
            firedelay = 0.1f;
            bulletstartdistance = 10;
        }

        public tripleshot(PointF location)
            : base("images/StunGUn.png", location)
        {
            firedelay = 0.1f;
            bulletstartdistance = 10;
        }
        public override void fire()
        {
            PointF bulletstart = new PointF();
            bulletstart.X = location.X + bulletstartdistance * (float)Math.Cos(angle * Math.PI / 180);
            bulletstart.Y = location.Y - bulletstartdistance * (float)Math.Sin(angle * Math.PI / 180);
            Bullets b = new basicbullet(bulletstart, angle, owner);
            Bullets c = new basicbullet(bulletstart, angle + 5, owner);
            Bullets d = new basicbullet(bulletstart, angle - 5, owner);
            b.damage = 5;
            b.movespeed = 10;
            c.damage = 5;
            c.movespeed = 10;
            c.damage = 5;
            c.movespeed = 10;
            d.movespeed = 10;
            d.damage = 5;
            d.movespeed = 10;
            MainForm.bulletlist.Add(b);
            MainForm.bulletlist.Add(c);
            MainForm.bulletlist.Add(d);
            timesincelastshot = 0;
        }
        public override string getfile()
        {
            return "images/StunGun.png";
        }
    }
}
    

