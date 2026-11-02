using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.GameObjects.Items;

namespace TurnBasedRPG.Source.Entities.AllyRoles
{
    public class Merchant : Ally
    {
        private List<Item> wares;

        public Merchant(string name, string spritePath, int money, List<Item> wares) : base(name, spritePath, money)
        {
            this.Wares = wares;
        }

        public List<Item> Wares { get => wares; set => wares = value; }

        public override void Talk()
        {
            Game.Instance.openShop(Wares);
        }
    }
}
