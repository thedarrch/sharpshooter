using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public class homingbullet : Bullets
    {
       
        public homingbullet(PointF startlocation, float a, soldier o)
            : base(startlocation, "images/SuperBall.png", 4, 0.025f, a, o, 200)
        {
            damage = 25;
           
            life = 10;

        }
        public override void hitwall(wall w)
        {
            this.destroy();
        }
        public override void move(float time)
        {
            float xdifference = MainForm.player1.getx() - this.location.X;
            float ydifference = MainForm.player1.gety() - this.location.Y;
            float targetangle = (float)(180f / Math.PI * Math.Atan2((double)-ydifference, (double)xdifference));
            if (targetangle < 0)
            {
                targetangle += 360;
            }
            this.angle = targetangle;
            velocity.X = (float)(movespeed * Math.Cos(angle * Math.PI / 180));
            velocity.Y = -(float)(movespeed * Math.Sin(angle * Math.PI / 180));
            base.move(time);
            
        }
    }
}
