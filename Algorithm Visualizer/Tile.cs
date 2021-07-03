using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    class Tile : Label
    {
        public int x, y;
        public bool active, wall;
        public Color activeColor, deactiveColor, wallColor;

        public Tile(int x, int y, int tileSize)
        {
            this.x = x;
            this.y = y;
            this.active = false;
            this.wall = false;
            this.Size= new Size(x * tileSize, y * tileSize);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(0, 0, 0, 0);
            this.activeColor = Color.Blue;
            this.deactiveColor = Color.White;
            this.wallColor = Color.DarkGray;
            this.BackColor = deactiveColor;
            
        }

        public void onClick()
        {   if (wall)   //deactivating
            {
                wall = false;
                this.BackColor = deactiveColor;
            }
            else         //activating
            {
                wall = true;
                this.BackColor = wallColor;
            }
        }

        public void Activate()
        {
            if (active)   //deactivating
            {
                active = false;
                this.BackColor = deactiveColor;
            }
            else         //activating
            {
                active = true;
                this.BackColor = activeColor;
            }

        }

        public void path()
        {
            this.BackColor = Color.Yellow;
        }

    }

    class StartTile : Tile
    {
        public StartTile(int x, int y, int tileSize) : base(x, y, tileSize)
        {
            this.Text = "S";
            this.active = true;
            this.deactiveColor = Color.Green;
            this.activeColor = Color.Green;
            this.BackColor = Color.Green;
        }
    }

    class GoalTile : Tile
    {
        public GoalTile(int x, int y, int tileSize) : base(x, y, tileSize)
        {
            this.Text = "G";
            this.active = false;
            this.deactiveColor = Color.Red;
            this.activeColor = Color.Green;
            this.BackColor = deactiveColor;
        }
    }

}
