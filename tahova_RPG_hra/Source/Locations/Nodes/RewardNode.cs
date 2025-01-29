using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.GameObjects;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class RewardNode : Node
    {
        private Item[] rewards;

        public RewardNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, Item[] rewards) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.rewards = rewards;
        }

        public override void Traverse() { }
    }
}
