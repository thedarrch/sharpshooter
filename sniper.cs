using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    class sniper:weapon
    {
        
            public sniper(soldier o)
                : base("images/SniperGun.png", o)
            {
                firedelay = 0.4f;
                bulletstartdistance = 10;
            }
            public sniper(PointF location)
                : base("images/SniperGun.png", location)
            {
                firedelay = 0.4f;
                bulletstartdistance = 10;
            }
            public override void fire()
            {
                if (owner == MainForm.player1){
                MainForm.gunshot1.Play();
                }
                PointF bulletstart = new PointF();
                bulletstart.X = location.X + bulletstartdistance * (float)Math.Cos(angle * Math.PI / 180);
                bulletstart.Y = location.Y - bulletstartdistance * (float)Math.Sin(angle * Math.PI / 180);
                Bullets b = new sniperbullet(bulletstart, angle, owner);
                b.damage = 100;
                b.movespeed = 10000;
                MainForm.bulletlist.Add(b);
                timesincelastshot = 0;
            }
            public override string getfile()
            {
                return "images/SniperGun.png";
            }
        }
    }

