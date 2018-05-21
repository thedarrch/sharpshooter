using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DarrenSHARPSHOOTER
{
    public class level
    {
        int levelnumber;
        List<enemy> enemylist;
        List<wall> walllist;
        List<powerup> poweruplist;
        int levelheight, levelwidth;
        PointF p1loc;
        weapon startweapon;

        public level(int h, int w, int lvlnum, float x, float y, weapon startweapon)
        {
            levelheight = h;
            levelwidth = w;
            levelnumber = lvlnum;
            enemylist = new List<enemy>();
            walllist = new List<wall>();
            poweruplist = new List<powerup>();
            createborders();
            p1loc = new PointF(x, y);
            this.startweapon = startweapon;

        }
        public void createborders()
        {
            wall wall1 = new wall(0, 0, 30, levelheight);
            walllist.Add(wall1);

            wall wall2 = new wall(0, 0, levelwidth, 30);
            walllist.Add(wall2);

            wall wall3 = new wall(0, levelheight - 30, levelwidth - 30, 30);
            walllist.Add(wall3);

            wall wall4 = new wall(levelwidth, 0, 30, levelheight - 30);
            walllist.Add(wall4);



        }
        public void addenemy(string name, float x, float y, params float[] args)
        {
            if (args.Count() % 2 == 1)
            {
                return;
            }
            List<PointF> path = new List<PointF>();
            for (int i = 0; i < args.Count() / 2; i++)
            {
                PointF p = new PointF();
                p.X = args[2 * i];
                p.Y = args[2 * i + 1];
                path.Add(p);

            }
            PointF startlocation = new PointF(x, y);

            if (name == "easyenemy")
            {
                enemy e = new easyenemy(startlocation, path);

                enemylist.Add(e);
            }
            if (name == "eliteenemy")
            {
                enemy e = new eliteenemy(startlocation, path);

                enemylist.Add(e);
            }
            if (name == "uberenemy")
            {
                enemy e = new uberenemy(startlocation, path);

                enemylist.Add(e);
            }
            if (name == "boss")
            {
                enemy e = new boss(startlocation, path);

                enemylist.Add(e);
            }
        }

        public void addpowerup(float x, float y, string weaponname)
        {
            PointF startlocation = new PointF(x, y);
            if (weaponname == "machinegun")
            {
                weapon w = new machinegun(startlocation);
                powerup p = new weaponpowerup(startlocation, w);
                poweruplist.Add(p);
            }
            else if (weaponname == "tripleshot")
            {
                weapon w = new tripleshot(startlocation);
                powerup p = new weaponpowerup(startlocation, w);
                poweruplist.Add(p);
            }
            else if (weaponname == "sniper")
            {
                weapon w = new sniper(startlocation);
                powerup p = new weaponpowerup(startlocation, w);
                poweruplist.Add(p);
            }
            else if (weaponname == "pistol")
            {
                weapon w = new pistol(startlocation);
                powerup p = new weaponpowerup(startlocation, w);
                poweruplist.Add(p);
            }
            else if (weaponname == "firstaidpowerup")
            {
                powerup p = new firstaidpowerup(startlocation);
                poweruplist.Add(p);
            }
            else if (weaponname == "superballgun")
            {
                weapon w = new superballgun(startlocation);
                powerup p = new weaponpowerup(startlocation, w);
                poweruplist.Add(p);
            }
            else if (weaponname == "enemyspawner")
            {
                powerup p = new enemyspawner(startlocation);
                poweruplist.Add(p);
            }


        }
        public void addwall(int top, int left, int width, int height)
        {
            wall wall1 = new wall(top, left, width, height);
            walllist.Add(wall1);
        }
        public List<enemy> getenemies()
        {
            return enemylist;
        }
        public List<wall> getwalls()
        {
            return walllist;
        }
        public List<powerup> getpowerups()
        {
            return poweruplist;
        }
        public PointF getstart()
        {
            return p1loc;
        }
        public weapon getweapon()
        {
            return startweapon;
        }
    }
}
