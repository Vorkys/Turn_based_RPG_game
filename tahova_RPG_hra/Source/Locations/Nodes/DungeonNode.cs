﻿using tahova_RPG_hra.Source.Core;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    public class DungeonNode : Node
    {
        private int locationId;

        public DungeonNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, int locationId) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.LocationId = locationId;
        }

        public int LocationId { get => locationId; set => locationId = value; }

        public override void Traverse()
        {
            base.Traverse();

            Game.Instance.changeLocation(LocationId);
        }
    }
}
