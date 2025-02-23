using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class RewardNode : Node
    {
        private Item[] rewards;
        private bool visited;

        public RewardNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, Item[] rewards) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.rewards = rewards;
            this.visited = false;
        }

        //TODO
        public override void Traverse(Game game)
        {
            foreach (Item _item in rewards)
            {
                bool loot = game.Player.AddItem(_item);

                if (!loot)
                    Console.WriteLine($"inventory is full. {_item.Name} wasnt looted.");
            }
        }
    }
}
