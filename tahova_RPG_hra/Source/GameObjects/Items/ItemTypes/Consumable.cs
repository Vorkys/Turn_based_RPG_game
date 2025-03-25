using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items.ItemTypes
{
    public class Consumable : Item
    {
        private int power;

        public Consumable(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity)
        {
            this.Power = power;
        }

        public Consumable(Entity owner, string name, string description, int buyPrice, int sellPrice, int quantity, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, quantity, maxQuantity)
        {
            this.Power = power;
        }

        public int Power { get => power; set => power = value; }
    }
}
