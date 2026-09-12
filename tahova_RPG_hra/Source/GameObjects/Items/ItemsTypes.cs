using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;

namespace TurnBasedRPG.Source.GameObjects.Items
{
    public class HealingItem : Consumable
    {
        public HealingItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int quantity = 1) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    public class ManaIncreaseItem : Consumable
    {
        public ManaIncreaseItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int quantity = 1) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.IncreaseMana(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    public class HybridHealingItem : Consumable
    {
        private int manaIncrease;

        public HybridHealingItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int manaIncrease, int quantity = 1) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
        {
            this.ManaIncrease = manaIncrease;
        }

        public override bool Use()
        {
            Owner.IncreaseHealth(Power);
            Owner.IncreaseMana(ManaIncrease);
            Owner.RemoveItem(this);
            return true;
        }

        public int ManaIncrease { get => manaIncrease; set => manaIncrease = value; }
    }

    public class DamageItem : Consumable
    {
        public DamageItem(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int quantity = 1) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
        {
        }

        public override bool Use()
        {
            Owner.Target.ReduceHealth(Power);
            Owner.RemoveItem(this);
            return true;
        }
    }

    public class ReduceMana : Consumable
    {
        public ReduceMana(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power, int quantity = 1) : base(name, description, buyPrice, sellPrice, maxQuantity, power)
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
