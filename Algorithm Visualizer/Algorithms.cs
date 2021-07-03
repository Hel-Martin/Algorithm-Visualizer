using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Visualizer
{
    class Algorithms
    {
        static public int sleeptime = 10;

        ////////////////////
        /// Dijkstra
        ////////////////////
  
  

        static public void Dijkstra(object parameters)       //Tile[,] tiles, Tile start, Tile goal
        {
            List<object>convParameters = (List<object>)parameters;
            Tile[,] tiles = (Tile[,])convParameters[0];
            Tile start = (Tile)convParameters[1];
            Tile goal = (Tile)convParameters[2];
            

            Tile temp = new Tile(start.x, start.y, AlgoVis.tileSize);
            Tile chosen=null;
            List<Tile> tList = new List<Tile>();
            List<int> dist = new List<int>();
            int step = 0;
            tList.Add(start);
            dist.Add(0);
            while (!goal.active && step<tiles.Length)       //search order is up, right, down, left
            {
                if (step == 0)
                {
                    chosen = start;
                    if (chosen.y > 1 && !tiles[chosen.x, chosen.y - 1].active && !goal.active && !tiles[chosen.x, chosen.y - 1].wall)
                    {
                        temp = tiles[chosen.x, chosen.y - 1];
                        temp.Activate();
                        tList.Add(temp);
                        dist.Add(step + 1);
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    if (chosen.x < tiles.GetLength(0)-1 && !tiles[chosen.x + 1, chosen.y].active && !goal.active && !tiles[chosen.x + 1, chosen.y].wall)
                    {
                        temp = tiles[chosen.x + 1, chosen.y];
                        temp.Activate();
                        tList.Add(temp);
                        dist.Add(step + 1);
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    if (chosen.y < tiles.GetLength(1)-1 && !tiles[chosen.x, chosen.y + 1].active && !goal.active && !tiles[chosen.x, chosen.y + 1].wall)
                    {
                        temp = tiles[chosen.x, chosen.y + 1];
                        temp.Activate();
                        tList.Add(temp);
                        dist.Add(step + 1);
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    if (chosen.x > 1 && !tiles[chosen.x - 1, chosen.y].active && !goal.active && !tiles[chosen.x-1, chosen.y].wall)
                    {
                        temp = tiles[chosen.x - 1, chosen.y];
                        temp.Activate();
                        tList.Add(temp);
                        dist.Add(step + 1);
                        System.Threading.Thread.Sleep(sleeptime);
                    }
                    
                }

                else
                {
                    
                    for(int i=0; i< dist.Count; i++)
                    {
                        if (dist[i] == step)
                        {
                            chosen = tList[i];
                            if (chosen.y > 1 && !tiles[chosen.x, chosen.y - 1].active && !goal.active && !tiles[chosen.x, chosen.y - 1].wall)
                            {
                                temp = tiles[chosen.x, chosen.y - 1];
                                temp.Activate();
                                tList.Add(temp);
                                dist.Add(step + 1);
                                System.Threading.Thread.Sleep(sleeptime);
                            }

                            if (chosen.x < tiles.GetLength(0)-1 && !tiles[chosen.x + 1, chosen.y].active && !goal.active && !tiles[chosen.x + 1, chosen.y].wall)
                            {
                                temp = tiles[chosen.x + 1, chosen.y];
                                temp.Activate();
                                tList.Add(temp);
                                dist.Add(step + 1);
                                System.Threading.Thread.Sleep(sleeptime);
                            }

                            if (chosen.y < tiles.GetLength(1)-1 && !tiles[chosen.x, chosen.y + 1].active && !goal.active && !tiles[chosen.x, chosen.y + 1].wall)
                            {
                                temp = tiles[chosen.x, chosen.y + 1];
                                temp.Activate();
                                tList.Add(temp);
                                dist.Add(step + 1);
                                System.Threading.Thread.Sleep(sleeptime);
                            }

                            if (chosen.x > 1 && !tiles[chosen.x - 1, chosen.y].active && !goal.active && !tiles[chosen.x - 1, chosen.y].wall)
                            {
                                temp = tiles[chosen.x - 1, chosen.y];
                                temp.Activate();
                                tList.Add(temp);
                                dist.Add(step + 1);
                                System.Threading.Thread.Sleep(sleeptime);
                            }
                        }
                    }
                }
                step++;
            
            }

            if (goal.active)
            {
                goal.path();
                chosen = goal;
                while (!chosen.Equals(start))
                {
                    if (chosen.x > 1 && tiles[chosen.x - 1, chosen.y].active && dist[tList.IndexOf(tiles[chosen.x - 1, chosen.y])] < step && !tiles[chosen.x - 1, chosen.y].wall)
                    {
                        step = dist[tList.IndexOf(tiles[chosen.x - 1, chosen.y])];
                        chosen = tiles[chosen.x - 1, chosen.y];
                        chosen.path();
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    else if (chosen.y < tiles.GetLength(1) - 1 && tiles[chosen.x, chosen.y + 1].active && dist[tList.IndexOf(tiles[chosen.x, chosen.y + 1])] < step && !tiles[chosen.x, chosen.y + 1].wall)
                    {
                        step = dist[tList.IndexOf(tiles[chosen.x, chosen.y + 1])];
                        chosen = tiles[chosen.x, chosen.y + 1];
                        chosen.path();
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    else if (chosen.x < tiles.GetLength(0) - 1 && tiles[chosen.x + 1, chosen.y].active && dist[tList.IndexOf(tiles[chosen.x + 1, chosen.y])] < step && !tiles[chosen.x + 1, chosen.y].wall)
                    {
                        step = dist[tList.IndexOf(tiles[chosen.x + 1, chosen.y])];
                        chosen = tiles[chosen.x + 1, chosen.y];
                        chosen.path();
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                    else if (chosen.y > 1 && tiles[chosen.x, chosen.y - 1].active && dist[tList.IndexOf(tiles[chosen.x, chosen.y-1])]<step && !tiles[chosen.x, chosen.y - 1].wall)
                    {
                        step = dist[tList.IndexOf(tiles[chosen.x, chosen.y - 1])];
                        chosen = tiles[chosen.x, chosen.y - 1];
                        chosen.path();
                        System.Threading.Thread.Sleep(sleeptime);
                    }

                }

            }
            AlgoVis.algoOver = true;
            
                       
        }

        ////////////////////
        /// A*
        ////////////////////

        static public void A_Star(object parameters)
        {
            List<object> convParameters = (List<object>)parameters;
            Tile[,] tiles = (Tile[,])convParameters[0];
            Tile start = (Tile)convParameters[1];
            Tile goal = (Tile)convParameters[2];
            int sleeptime = 10;

            List<A_StarData> openTiles = new List<A_StarData>();
            A_StarData[,] A_Tiles = new A_StarData[tiles.GetLength(0), tiles.GetLength(1)];
            A_StarData A_start=null;
            foreach (Tile t in tiles)
            {
                A_StarData A_Tile = new A_StarData(t);
                A_Tiles[t.x, t.y] = A_Tile;
                if (t.Equals(start)) A_start = A_Tile;
            }

            openTiles.Add(A_start);
            A_start.G = 0;
            A_start.F = A_StarDistance(A_start.t, goal);
            A_StarData current=null;
            List<double> Fs = new List<double>();

            while (!goal.active && openTiles.Count!=0)
            {
                Fs.Clear();
                foreach(A_StarData d in openTiles)
                {
                    Fs.Add(d.F);
                }
                current = openTiles[Fs.IndexOf(Fs.Min())];
                if (!current.t.Equals(start)) current.t.Activate();
                openTiles.Remove(current);

                for (int i=0; i<8; i++) A_Star_Calc(A_Tiles, openTiles, current, goal, i);
                System.Threading.Thread.Sleep(sleeptime);
            }

            if (goal.active)
            {               
                while (!current.t.Equals(start))
                {
                    current.t.path();
                    current = current.Parent;
                    System.Threading.Thread.Sleep(sleeptime);
                }
                current.t.path();
            }

            AlgoVis.algoOver = true;
        }
        
        public class A_StarData
        {
            public Tile t;
            public double G, F;
            public A_StarData Parent;

            public A_StarData(Tile t)
            {
                this.t = t;
                G = 10000;
            }
        }

        static public double A_StarDistance(Tile a, Tile b)
        {
            return Math.Abs(Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y)));
        }

        static public void A_Star_Calc(A_StarData[,] A_Tiles, List<A_StarData> openTiles, A_StarData A_current, Tile goal, int code)     //Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft  
        {

            Tile current = A_current.t;
            int j = 0, k = 0;
            bool flag = false;

            switch(code){
                case 0: { j = 0; k = -1; flag = current.y > 1; } break;                                                                     //Up => 0
                case 1: { j = 1; k = -1; flag = current.y > 1 && current.x < A_Tiles.GetLength(0) - 1; } break;                             //UpRight => 1
                case 2: { j = 1; k = 0;  flag = current.x < A_Tiles.GetLength(0) - 1; } break;                                              //Right => 2
                case 3: { j = 1; k = 1;  flag = current.x < A_Tiles.GetLength(0) - 1 && current.y < A_Tiles.GetLength(1) - 1;} break;       //DownRight => 3
                case 4: { j = 0; k = 1;  flag = current.y < A_Tiles.GetLength(1) - 1; } break;                                              //Down => 4
                case 5: { j = -1; k = 1; flag = current.y < A_Tiles.GetLength(1) - 1 && current.x > 1; } break;                             //DownLeft => 5
                case 6: { j = -1; k = 0; flag = current.x > 1; } break;                                                                     //Left => 6
                case 7: { j = -1; k = -1;flag = current.x > 1 && current.y > 1;} break;                                                     //UpLeft => 7
                default: break;
            }


            
            if (flag && !A_Tiles[current.x + j, current.y + k].t.active && !A_Tiles[current.x + j, current.y + k].t.wall)      //Up
            {
                A_StarData neighbor = A_Tiles[current.x + j, current.y + k];
                double tempG= A_current.G + A_StarDistance(current, neighbor.t);
                if ( tempG< neighbor.G)    //if current.G + dist(current,neighbor)<neighbor.G
                {
                    neighbor.Parent = A_current;
                    neighbor.G = tempG;
                    neighbor.F = neighbor.G + A_StarDistance(neighbor.t, goal);
                    if (!openTiles.Contains(neighbor)) openTiles.Add(neighbor);
                }
            }   
        }

        ////////////////////
        /// 
        ////////////////////




    }
}
