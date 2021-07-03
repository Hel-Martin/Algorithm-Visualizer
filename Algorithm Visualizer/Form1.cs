using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    public partial class AlgoVis : Form
    {
        public static int tileSize = 40;
        static int tilesX, tilesY;
        static Tile[,] tiles;
        static StartTile start = null;
        static GoalTile goal = null;
        static bool xDown = false;

        public AlgoVis()
        {
            InitializeComponent();
            KeyPreview = true;            
        }

        private void AlgoVis_Load(object sender, EventArgs e)
        {
            

            var mainWidth = 1400;
            var mainHeight = 900;
            
            
            this.Size = new Size(mainWidth+16, mainHeight);
            var bottomHeight = 800;
            var menuHeight = ClientRectangle.Height - bottomHeight;

            menuPanel.Size = new Size(mainWidth, menuHeight);
            mainPanel.Size = new Size(mainWidth, bottomHeight);

            chStart.Size = new Size(chStart.Width, menuHeight);
            chGoal.Size = new Size(chGoal.Width, menuHeight);

            tilesX = 1+mainWidth / tileSize;
            tilesY = 1+bottomHeight / tileSize;
            


            mainPanel.ColumnCount = tilesX;
            mainPanel.RowCount = tilesY;
            tileInit();
        }

        private delegate void MyDelegate();
        public void tileInit()
        {

            tiles = new Tile[tilesX, tilesY];
            start = null;
            goal = null;

            mainPanel.Controls.Clear();
            mainPanel.ColumnStyles.Clear();
            mainPanel.RowStyles.Clear();
            
            for (int y = 0; y < tilesY; y++)
            {
                for (int x = 0; x < tilesX; x++)
                {
                    Tile t = new Tile(x, y, tileSize);
                    tiles[x, y] = t;
                    t.Click += new EventHandler(onClick);
                    t.MouseEnter += new EventHandler(onMouseHover);
                    mainPanel.Controls.Add(t, x - 1, y - 1);
                    mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
                }
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            }  
        }
        public void tileReset()
        {
            foreach(Tile t in tiles){
                if (t.active) t.Activate();
                if (t.wall) t.onClick();
                if (t.Equals(start))
                {
                    Tile temp = new Tile(t.x, t.y, tileSize);
                    temp.Click += new EventHandler(onClick);
                    tiles[t.x, t.y] = temp;
                    mainPanel.Controls.Remove(start);
                    mainPanel.Controls.Add(temp, t.x-1, t.y-1);
                    start = null;
                }
                if (t.Equals(goal))
                {
                    Tile temp = new Tile(t.x, t.y, tileSize);
                    temp.Click += new EventHandler(onClick);
                    tiles[t.x, t.y] = temp;
                    mainPanel.Controls.Remove(goal);
                    mainPanel.Controls.Add(temp, t.x-1, t.y-1);
                    goal = null;

                }
            }
        }

        public void onClick(object sender, EventArgs e)
        {

            Tile t = sender as Tile;
            if (!chStart.Checked && !chGoal.Checked)
            {
                if (t.Equals(start) || t.Equals(goal))
                {
                    if(t.Equals(start)) start = null;
                    if (t.Equals(goal)) goal = null;

                    Tile fill = new Tile(t.x, t.y, tileSize);
                    tiles[t.x, t.y] = fill;
                    fill.Click += new EventHandler(onClick);
                    mainPanel.Controls.Remove(t);
                    mainPanel.Controls.Add(fill, fill.x - 1, fill.y - 1);
                }
                t.onClick();
            }
            else
            {
                if (chStart.Checked)
                {
                    chStart.Checked = false;
                    if (t.Equals(goal)) goal = null;


                    StartTile newTile = new StartTile(t.x, t.y, tileSize);
                    tiles[t.x, t.y] = newTile;
                    newTile.Click += new EventHandler(onClick);
                    mainPanel.Controls.Remove(t);
                    if (start != null)
                    {
                        Tile fill = new Tile(start.x, start.y, tileSize);
                        tiles[start.x, start.y] = fill;
                        fill.Click += new EventHandler(onClick);
                        mainPanel.Controls.Remove(start);
                        mainPanel.Controls.Add(fill, fill.x - 1, fill.y - 1);

                    }
                    start = newTile;

                    mainPanel.Controls.Add(newTile, newTile.x - 1, newTile.y - 1);

                }
                else if (chGoal.Checked)
                {
                    chGoal.Checked = false;
                    if (t.Equals(start)) start = null;
                    GoalTile newTile = new GoalTile(t.x, t.y, tileSize);
                    tiles[t.x, t.y] = newTile;
                    newTile.Click += new EventHandler(onClick);
                    mainPanel.Controls.Remove(t);
                    if (goal != null)
                    {
                        Tile fill = new Tile(goal.x, goal.y, tileSize);
                        tiles[goal.x, goal.y] = fill;
                        fill.Click += new EventHandler(onClick);
                        mainPanel.Controls.Remove(goal);
                        mainPanel.Controls.Add(fill, fill.x - 1, fill.y - 1);

                    }
                    goal = newTile;

                    mainPanel.Controls.Add(newTile, newTile.x - 1, newTile.y - 1);
                }
            }
        }

        public void onMouseHover(object sender, EventArgs e)
        {
            if (xDown)
            {
                Tile t = sender as Tile;
                if(!t.wall) t.onClick();
            }
        }

        private void AlgoVis_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                xDown = false;
            }
        }

        private void AlgoVis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X)
            {
                xDown = true;
            }
        }

        private void chStart_CheckedChanged(object sender, EventArgs e)
        {
            if(chStart.Checked) chGoal.Checked = false;
        }

        private void chGoal_CheckedChanged(object sender, EventArgs e)
        {
            if (chGoal.Checked) chStart.Checked = false;
        }

        private void bLaunch_Click(object sender, EventArgs e)
        {
            chGoal.Checked = false;
            chStart.Checked = false;
            if (start!=null && goal != null)
            {
                Thread calcThread = null;
                if (cbAlgo.Text=="Dijkstra") calcThread = new Thread(new ParameterizedThreadStart(Algorithms.Dijkstra));
                if(cbAlgo.Text=="A*")   calcThread = new Thread(new ParameterizedThreadStart(Algorithms.A_Star));

                List<object> parameters = new List<object>();
                parameters.Add(tiles);
                parameters.Add(start);
                parameters.Add(goal);
                calcThread.Start(parameters);
                               
            }
        }
        private void bReset_Click(object sender, EventArgs e)
        {
            tileReset();
            chGoal.Checked = false;
            chStart.Checked = false;
        }

        public static void Run()
        {
            Tile temp = new Tile(start.x, start.y, 40);
            while (goal !=null && !goal.active)
            {
                if (temp.x != goal.x)
                {
                    if (goal.x - temp.x > 0) temp.x++;
                    else temp.x--;

                    tiles[temp.x, temp.y].Activate();
                }
                else if (temp.y != goal.y)
                {
                    if (goal.y - temp.y > 0) temp.y++;
                    else temp.y--;
                    tiles[temp.x, temp.y].Activate();
                }

                Thread.Sleep(100);
            }
        }
    }
}
