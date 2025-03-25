using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    public class RewardNode : Node
    {
        private Item[] rewards;
        private bool visited;

        public RewardNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, Item[] rewards) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.Rewards = rewards;
            this.Visited = false;
        }

        public bool Visited { get => visited; set => visited = value; }
        public Item[] Rewards { get => rewards; set => rewards = value; }

        //TODO
        public override void Traverse()
        {
            base.Traverse();

            foreach (Item _item in Rewards)
            {
                bool loot = Game.Instance.Player.AddItem(_item);

                if (!loot)
                    Console.WriteLine($"inventory is full. {_item.Name} wasnt looted.");
            }
        }
    }
}
