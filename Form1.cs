using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DarrenSHARPSHOOTER
{
    public partial class MainForm : Form
    {
        public static Player player1;
        public static List<Bullets> bulletlist;
        public static List<enemy> enemylist;
        public static List<wall> walllist;
        public static List<powerup> poweruplist;
        public static List<level> levellist;
        public static List<superball> superballlist;
        Graphics windowsGraphics;
        Graphics offg;
        Bitmap offscreen;
        Picture gameoverscreen;
        Picture victoryscreen;
        bool victory;
        bool gameover;
        bool titlescreen;
        readonly int levelwidth = 1200, levelheight = 1200;
        public static Point viewoffset;
        int lvlnum;
        public static level currentlvl;
        bool friendlyfireon = false;
        readonly float pausedelay = 1.5f;
        float pausecounter;
        Boolean pause;
        Boolean levelintro;
        public static SoundPlayer gunshot1, gunshot2, gunshot3;

        public MainForm()
        {

            InitializeComponent(); //1st
            LEVEL1.BackColor = Color.Transparent;
            windowsGraphics = this.CreateGraphics();
            //set drawgame to be called whenever the window resets
            this.Paint += new PaintEventHandler(drawGame);
            offscreen = new Bitmap(this.Width, this.Height);
            offg = Graphics.FromImage(offscreen);

            titlescreen = true;

            gunshot1 = new SoundPlayer("sounds/GunShot1.wav");
            gunshot2 = new SoundPlayer("sounds/GunShot2.wav");
          
 
           //HEALTH.Parent = heart;
           HEALTH.BackColor = Color.Transparent;
           HEALTH.ForeColor = Color.Green;

        }
        void init()
        {
            gameoverscreen = new Picture("images/GameOver.png", new PointF(this.Width / 2, this.Height / 2), 1, 1);
            victoryscreen = new Picture("images/Victory.png", new PointF(this.Width / 2, this.Height / 2), 1, 1);

            player1 = new Player();

            viewoffset = new Point();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(player1.keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(player1.keyup);
            bulletlist = new List<Bullets>();
            enemylist = new List<enemy>();
            walllist = new List<wall>();
            poweruplist = new List<powerup>();
            levellist = new List<level>();
            superballlist = new List<superball>();


            victory = false;
            gameover = false;



            setuplvl1();
            setuplvl2();
            setuplvl3();
            lvlnum = -1;
            nextlevel();
        }
        private void setuplvl1()
        {
            level lvl1 = new level(1200, 1200, 1, 45, 300, new pistol(new PointF(0, 0)));
            lvl1.addenemy("easyenemy", 275, 105, 275, 105, 350, 105, 350, 660, 275, 660, 350, 660, 350, 105);
            lvl1.addenemy("easyenemy", 950, 105, 950, 105, 1000, 105, 1000, 660, 950, 660, 1000, 660, 1000, 105);
            lvl1.addenemy("easyenemy", 700, 375, 700, 375, 550, 375, 550, 600, 400, 600, 550, 600, 550, 375);
            lvl1.addenemy("easyenemy", 700, 325, 700, 325, 550, 325, 550, 100, 400, 100, 550, 100, 550, 325);
            lvl1.addenemy("easyenemy", 100, 950, 100, 950, 500, 950);
            lvl1.addenemy("easyenemy", 500, 950, 500, 950, 100, 950);


            lvl1.addwall(225, 150, 50, 450);
            lvl1.addwall(600, 125, 250, 50);
            lvl1.addwall(600, 575, 250, 50);
            lvl1.addwall(800, 150, 50, 450);
            lvl1.addwall(0, 750, 800, 50);

            lvl1.addpowerup(700, 380, "firstaidpowerup");
            lvl1.addpowerup(400, 380, "tripleshot");








            levellist.Add(lvl1);
        }
        private void setuplvl2()
        {
            level lvl2 = new level(1400, 1600, 1, 400, 700, new superballgun(new PointF(0, 0)));
            lvl2.addenemy("eliteenemy", 75, 600, 75, 1175, 175, 1175, 75, 1175, 75, 175, 175, 175, 75, 175);
            lvl2.addenemy("easyenemy", 175, 600, 175, 175, 275, 175, 175, 175, 175, 1175, 275, 1175, 175, 1175);
            lvl2.addenemy("easyenemy", 325, 1050, 325, 1050, 275, 1050, 275, 325, 500, 325, 275, 325, 275, 1050);
            lvl2.addenemy("eliteenemy", 1400, 750, 1400, 750, 1200, 750);
            lvl2.addenemy("easyenemy", 1400, 500, 1400, 500, 1200, 500);
            lvl2.addenemy("easyenemy", 1400, 1000, 1400, 1000, 1200, 1000);

            lvl2.addwall(100, 200, 25, 950);
            lvl2.addwall(200, 200, 25, 950);
            lvl2.addwall(100, 100, 1100, 25);
            lvl2.addwall(300, 1225, 150, 150);
            lvl2.addwall(300, 200, 200, 50);
            lvl2.addwall(300, 400, 50, 600);
            lvl2.addwall(550, 350, 100, 800);
            lvl2.addwall(350, 550, 100, 50);
            lvl2.addwall(1200, 250, 200, 200);
            lvl2.addwall(1200, 550, 200, 100);
            lvl2.addwall(1200, 850, 200, 100);
            lvl2.addwall(1200, 1050, 200, 200);



            lvl2.addpowerup(125, 1175, "firstaidpowerup");
            lvl2.addpowerup(400, 175, "machinegun");

            levellist.Add(lvl2);
        }
        private void setuplvl3()
        {

            level lvl3 = new level(1800, 2400, 1, 400, 400, new pistol(new PointF(0, 0)));
            lvl3.addpowerup(400, 175, "superballgun");
           

            
            lvl3.addwall(800, 0, 50, 250);
            lvl3.addwall(800, 350, 50, 250);
            lvl3.addwall(800, 700, 50, 250);
            lvl3.addwall(800, 1050, 50, 250);
            lvl3.addwall(800, 1400, 50, 250);
            
            lvl3.addwall(1600, 0, 50, 250);
            lvl3.addwall(1600, 350, 50, 250);
            lvl3.addwall(1600, 700, 50, 250);
            lvl3.addwall(1600, 1050, 50, 250);
            lvl3.addwall(1600, 1400, 50, 250);

            lvl3.addwall(0, 600, 300, 50);
            lvl3.addwall(400, 600, 300, 50);
            lvl3.addwall(800, 600, 300, 50);
            lvl3.addwall(1200, 600, 300, 50);
            lvl3.addwall(1600, 600, 300, 50);

            lvl3.addwall(0, 1200, 300, 50);
            lvl3.addwall(400, 1200, 300, 50);
            lvl3.addwall(800, 1200, 300, 50);
            lvl3.addwall(1200, 1200, 300, 50);
            lvl3.addwall(1600, 1200, 300, 50);

            lvl3.addenemy("boss", 1200, 1000);
            lvl3.addpowerup(900, 1000, "enemyspawner");
            lvl3.addpowerup(1300, 1000, "enemyspawner");

            levellist.Add(lvl3);
        }
        public void drawGame(object sender, PaintEventArgs e)
        {

            if (titlescreen == true)
            {
                return;
            }
            offg.Clear(Color.Black);


            if (player1.isdead() == false)
            {
                player1.draw(offg);
            }
            foreach (Bullets b in bulletlist)
            {
                b.draw(offg);

            }
            foreach (enemy b in enemylist)
            {
                b.draw(offg);
            }
            foreach (wall b in walllist)
            {
                b.draw(offg);
            }
            foreach (powerup b in poweruplist)
            {
                b.draw(offg);
            }
            if (victory == true)
            {
                victoryscreen.draw(offg);
            }
            else if (gameover == true)
            {
                gameoverscreen.draw(offg);
            }
            windowsGraphics.DrawImage(offscreen, 0, 0);
            //last//draws buffer


        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            HEALTH.Text = player1.currhp.ToString(); 
            //repaint(1st)
            OnPaint(new PaintEventArgs(windowsGraphics, new Rectangle(0, 0, this.Width, this.Height))); ;
         
                
            if (pause == true)
            {
                pausecounter -= Clock.Interval / 1000f;
                if (pausecounter < 0)
                {
                    pause = false;
                    levelintro = false;
                    LEVEL1.Hide();
                }
                else
                {
                    return;
                }
            }

            player1.update(Clock.Interval / 1000f);
            //update & delete enemies
            viewoffset.X = (int)player1.getx() - this.Width / 2;
            viewoffset.Y = (int)player1.gety() - this.Height / 2;
            List<enemy> tempenemies = new List<enemy>();
            foreach (enemy b in enemylist)
            {
                b.update(Clock.Interval / 1000f);
                if (b.isdead() == false)
                {
                    tempenemies.Add(b);
                }
            }
            enemylist = tempenemies;
            // update and delete bullets
            List<Bullets> tempbullets = new List<Bullets>();
            foreach (Bullets b in bulletlist)
            {
                b.update(Clock.Interval / 1000f);
                if (b.isdead() == false)
                {
                    tempbullets.Add(b);
                }
            }
            bulletlist = tempbullets;
            List<superball> superball = new List<superball>();
            foreach (superball b in superballlist)
            {
                if (b.isdead() == false)
                {
                    superball.Add(b);
                }
            }
            superballlist = superball;
            //update powerups
            List<powerup> temppowerups = new List<powerup>();
            foreach (powerup b in poweruplist)
            {
                b.update(Clock.Interval / 1000f);
                if (b.isdead() == false)
                {
                    temppowerups.Add(b);
                }
            }
            poweruplist = temppowerups;

            if (enemylist.Count == 0 && gameover == false)
            {
                nextlevel();

            }
            checkcollision(Clock.Interval / 1000f);

        }
        public void checkcollision(float time)
        {
            foreach (Bullets b in bulletlist)
            {
                if (friendlyfireon == false && b.istouching(player1) && b.getowner() != player1
                || friendlyfireon == true && b.istouching(player1))
                {

                    b.hittarget(player1);
                }
                if (player1.isdead())
                {
                    gameover = true;
                }


                foreach (enemy e in enemylist)
                {
                    if (friendlyfireon == false && b.istouching(e) && b.getowner() == player1
                    || friendlyfireon == true && b.istouching(e))
                    {
                        b.hittarget(e);
                    }
                }
            }



            foreach (wall w in walllist)
            {
                if (player1.istouchingwall(w))
                {
                    player1.pushfrom(w.pointnearestto(player1));
                }
                foreach (enemy e in enemylist)
                {
                    if (e.istouchingwall(w))
                    {
                        e.pushfrom(w.pointnearestto(e));
                    }
                }
                foreach (Bullets b in bulletlist)
                {
                    if (b.istouchingwall(w))
                    {
                        //while loop
                        while (b.istouchingwall(w))
                        {
                            b.backupposition(time);
                        }

                        b.hitwall(w);

                    }
                }
            }
            foreach (powerup p in poweruplist)
            {
                if (p.istouching(player1))
                {
                    p.onpickup();
                }
            }
            foreach (superball p in superballlist)
            {
                foreach (Bullets b in bulletlist)
                {
                    if (p.istouching(b) && p != b)
                    {
                        b.destroy();

                    }
                }
            }


        }

        private void start_Click(object sender, EventArgs e)
        {

            init();
            title.Hide();
            start.Hide();
            titlescreen = false;
            Clock.Enabled = true;
            heart.Visible = true;
            HEALTH.Visible = true;

        }
        public void nextlevel()
        {
            lvlnum++;
            if (lvlnum >= levellist.Count())
            {
                victory = true;
            }
            else
            {
                currentlvl = levellist[lvlnum];
                enemylist = currentlvl.getenemies();
                poweruplist = currentlvl.getpowerups();
                walllist = currentlvl.getwalls();
                bulletlist.Clear();
                player1.reset(currentlvl.getstart(), currentlvl.getweapon());

                player1.update(0);
                //update & delete enemies
                viewoffset.X = (int)player1.getx() - this.Width / 2;
                viewoffset.Y = (int)player1.gety() - this.Height / 2;
                List<enemy> tempenemies = new List<enemy>();
                foreach (enemy b in enemylist)
                {
                    b.update(0);
                    if (b.isdead() == false)
                    {
                        tempenemies.Add(b);
                    }
                }
                enemylist = tempenemies;
                // update and delete bullets
                List<Bullets> tempbullets = new List<Bullets>();
                foreach (Bullets b in bulletlist)
                {
                    b.update(0);
                    if (b.isdead() == false)
                    {
                        tempbullets.Add(b);
                    }
                }
                bulletlist = tempbullets;
                //update powerups
                List<powerup> temppowerups = new List<powerup>();
                foreach (powerup b in poweruplist)
                {
                    b.update(0);
                    if (b.isdead() == false)
                    {
                        temppowerups.Add(b);
                    }
                }
                poweruplist = temppowerups;

                pause = true;
                pausecounter = pausedelay;
                levelintro = true;
                LEVEL1.Visible = true;
                LEVEL1.Text = "Level: " + (lvlnum+1);
                if (lvlnum == 2){
                    player1.sethp(250);
                }
            }
        }
    }
}