using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class superballgun : weapon
    {
        public superballgun(soldier o)
            : base("images/SuperBallLauncher.png", o)
        {
            firedelay = 0.3f;
            bulletstartdistance = 10;
        }
        public superballgun(PointF location)
            : base("images/SuperBallLauncher.png", location)
        {
            
            firedelay = 0.3f;
            bulletstartdistance = 10;
        }
        public override void fire()
        {
            if (owner == MainForm.player1)
            {
                MainForm.gunshot2.Play();
            }
            
            PointF bulletstart = new PointF();
            bulletstart.X = location.X + bulletstartdistance * (float)Math.Cos(angle * Math.PI / 180);
            bulletstart.Y = location.Y - bulletstartdistance * (float)Math.Sin(angle * Math.PI / 180);
            superball b = new superball(bulletstart, angle, owner);
            MainForm.superballlist.Add(b);
            MainForm.bulletlist.Add(b);
            timesincelastshot = 0;
        }
        public override string getfile()
        {
            return "images/SuperBallLauncher.png";
        }
    }
}
