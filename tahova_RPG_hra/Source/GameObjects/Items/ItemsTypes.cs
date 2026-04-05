using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    class HealingItem : Consumable
    {
        public HealingItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
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
        public ManaIncreaseItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
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
        private int manaIncrease;

        public HybridHealingItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int manaIncrease) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
        {
            this.manaIncrease = manaIncrease;
        }

        public override bool Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.IncreaseMana(manaIncrease);
            Owner.RemoveItem(this);
            return true;
        }
    }

    class DamageItem : Consumable
    {
        public DamageItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
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
        public ReduceMana(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
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
