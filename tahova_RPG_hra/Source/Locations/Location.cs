using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Locations.Nodes;

namespace tahova_RPG_hra.Source.Locations
{
    internal class Location
    {
        private Node[,] map;
        private int entryX;
        private int entryY;
        private int playerX;
        private int playerY;

        internal Node[,] Map { get => map; set => map = value; }
        public int EntryX { get => entryX; set => entryX = value; }
        public int EntryY { get => entryY; set => entryY = value; }
        public int PlayerX { get => playerX; set => playerX = value; }
        public int PlayerY { get => playerY; set => playerY = value; }

        public Location(Node[,] location, int entryX, int entryY, int playerX, int playerY)
        {
            this.Map = location;
            this.EntryX = entryX;
            this.EntryY = entryY;
            this.PlayerX = playerX;
            this.PlayerY = playerY;
        }

        public Location(Node[,] location, int entryX, int entryY)
        {
            this.Map = location;
            this.EntryX = entryX;
            this.EntryY = entryY;
            this.PlayerX = -1;
            this.PlayerY = -1;
        }

        public void writeMap()
        {
            for (int x = 0; x < Map.GetLength(0); x++)
            {
                for (int y = 0; y < Map.GetLength(1); y++)
                    Map[x, y].Write();

                Console.WriteLine();
            }
        }
    }
}
