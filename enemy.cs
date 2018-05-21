using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public abstract class enemy : soldier
    {
        List<PointF> path;
        int nextindex;
        int pathlength;
        float visionangle = 45;
        public enemy(PointF startlocation, string filename, List<PointF> path)
            : base(startlocation, filename)
        {
            isfiring = true;
            this.path = path;
            pathlength = path.Count;
            nextindex = 1;
        }

        public override void move(float time)
        {

        }
        public override void update(float time)
        { 
            getaction(time);
            base.update(time);
           

            //   if (seeobject(MainForm.player1)){


        }
        public void travelpath(float time)
        {


            if (pathlength < 2)
            {
                return;

            }
            //get next point
            PointF next = path[nextindex];
            //check if we've arrived 
            float distance = (float)Math.Sqrt((next.X - this.location.X) * (next.X - this.location.X)
          + (next.Y - this.location.Y) * (next.Y - this.location.Y));
            if (distance < movespeed * time / 2 + 1) //max overshoot is half movespeed, 1 is for tolerance
            {
                nextindex += 1;
                if (nextindex >= pathlength)
                {
                    nextindex = 0;
                }
                next = path[nextindex];
            }
            //find angle to next point
            float ydifference = next.Y - this.location.Y;
            float xdifference = next.X - this.location.X;
            this.angle = (float)(180f / Math.PI * Math.Atan2((double)-ydifference, (double)xdifference));
            if (this.angle < 0)
            {
                this.angle += 360;
            }
            location.X += velocity.X * time;
            location.Y += velocity.Y * time;



        }
        public void lookforplayer(float time)
        {
            if (seeobject(MainForm.player1))
            {
                float xdifference = MainForm.player1.getx() - this.location.X;
                float ydifference = MainForm.player1.gety() - this.location.Y;
                float targetangle = (float)(180f / Math.PI * Math.Atan2((double)-ydifference, (double)xdifference));
                if (targetangle < 0)
                {
                    targetangle += 360;
                }
                location.X += velocity.X * time;
                location.Y += velocity.Y * time;
                if (targetangle > this.angle)
                {
                    this.angle += turnspeed * time;
                }
                else
                {
                    this.angle -= turnspeed * time;
                }
            }
            else
            {
                travelpath(time);
            }
        }
        public bool seeobject(game_object g)
        {
            PointF objloc = new PointF();
            objloc.X = g.getx();
            objloc.Y = g.gety();
            float xdifference = objloc.X - this.location.X;
            float ydifference = objloc.Y - this.location.Y;
            float targetangle = (float)(180f / Math.PI * Math.Atan2((double)-ydifference, (double)xdifference));
            if (targetangle < 0)
            {
                targetangle += 360;
            }
            float maxangle = (this.angle + visionangle);
            float minangle = (this.angle - visionangle);
            if (minangle < 0 && targetangle > 270)
            {
                minangle += 360;
                maxangle += 360;
            }
            else if (maxangle > 360 && targetangle < 90)
            {
                minangle -= 360;
                maxangle -= 360;
            }
            if (targetangle < minangle || targetangle > maxangle)
            {
                return false;
            }
            foreach (wall w in MainForm.walllist)
            {

                if (game_object.checklineintersection(this.location.X, this.location.Y, objloc.X, objloc.Y, w.left, w.top, w.left + w.width, w.top))
                {
                    return false;
                }
                if (game_object.checklineintersection(this.location.X, this.location.Y, objloc.X, objloc.Y, w.left, w.top, w.left, w.top + w.height))
                {
                    return false;
                }
                if (game_object.checklineintersection(this.location.X, this.location.Y, objloc.X, objloc.Y, w.left + w.width, w.top + w.height, w.left, w.top + w.height))
                {
                    return false;
                }
                if (game_object.checklineintersection(this.location.X, this.location.Y, objloc.X, objloc.Y, w.left + w.width, w.top, w.left + w.width, w.top + w.height))
                {
                    return false;
                }

            }
            return true;
        }
        public abstract void getaction(float time);
    }

}
