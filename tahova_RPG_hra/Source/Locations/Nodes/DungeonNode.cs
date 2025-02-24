using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class DungeonNode : Node
    {
        private int locationId;

        public DungeonNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, int locationId) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.locationId = locationId;
        }

        public int LocationId
        {
            get { return LocationId; }
            set { LocationId = value; }
        }

        public override void Traverse(Game game)
        {
            game.changeLocation(LocationId);
        }
    }
}
