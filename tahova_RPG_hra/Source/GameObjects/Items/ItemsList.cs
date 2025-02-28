using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    class HealingItem : Consumable
    {
        public HealingItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override void Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.RemoveItem(this);
        }
    }

    class ManaIncreaseItem : Consumable
    {
        public ManaIncreaseItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override void Use()
        {
            Owner.IncreaseMana(Power);
            Owner.RemoveItem(this);
        }
    }

    class HybridHealingItem : Consumable
    {
        public HybridHealingItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override void Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.IncreaseMana(Power);
            Owner.RemoveItem(this);
        }
    }

    class DamagingItem : Consumable
    {
        public DamagingItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override void Use()
        {
            Owner.Target.ReduceHealth(Power);
            Owner.RemoveItem(this);
        }
    }
}
