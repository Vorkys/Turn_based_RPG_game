using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Locations.Nodes;

namespace TurnBasedRPG.Source.Locations
{
    public class Location
    {
        private string name;
        private List<List<Node>> map;
        private int entryX;
        private int entryY;
        private int playerX;
        private int playerY;

        public Location(string name, List<List<Node>> location, int entryX, int entryY)
        {
            this.Name = name;
            this.Map = location;
            this.EntryX = entryX;
            this.EntryY = entryY;
            this.PlayerX = entryX;
            this.PlayerY = entryY;
        }

        //used for deserialization
        public Location() { }

        public string Name { get => name; set => name = value; }
        public List<List<Node>> Map { get => map; set => map = value; }
        public int EntryX { get => entryX; set => entryX = value; }
        public int EntryY { get => entryY; set => entryY = value; }
        public int PlayerX { get => playerX; set => playerX = value; }
        public int PlayerY { get => playerY; set => playerY = value; }

        public void writeMap()
        {
            for (int x = 0; x < Map.Count; x++)
            {
                for (int y = 0; y < Map[x].Count; y++)
                    Map[x][y].Write();

                Console.WriteLine();
            }
        }
    }
}
