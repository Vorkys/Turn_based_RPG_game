using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Source.Locations
{
    internal class Location
    {
        private Node[,] location;
        private int entryX;
        private int entryY;
        private int playerX;
        private int playerY;

        public Location(Node[,] location, int entryX, int entryY, int playerX, int playerY)
        {
            this.location = location;
            this.entryX = entryX;
            this.entryY = entryY;
            this.playerX = playerX;
            this.playerY = playerY;
        }

        public Location(Node[,] location, int entryX, int entryY)
        {
            this.location = location;
            this.entryX = entryX;
            this.entryY = entryY;
            this.playerX = -1;
            this.playerY = -1;
        }

        public void writeMap()
        {
            foreach (Node mapRow in location)
            {
                foreach (Nodes mapNode in mapRow)
                    mapNode.write();

                Console.WriteLine();
            }
        }
    }
}
