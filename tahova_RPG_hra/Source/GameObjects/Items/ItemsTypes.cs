using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    class HealingItem : Consumable
    {
        public HealingItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    class ManaIncreaseItem : Consumable
    {
        public ManaIncreaseItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.IncreaseMana(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    class HybridHealingItem : Consumable
    {
        public HybridHealingItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.IncreaseMana(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    class DamageItem : Consumable
    {
        public DamageItem(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.Target.ReduceHealth(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    class ReduceMana : Consumable
    {
        public ReduceMana(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(owner, name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.Target.ReduceMana(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }
}
