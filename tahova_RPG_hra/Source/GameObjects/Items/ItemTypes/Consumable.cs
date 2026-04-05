using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items.ItemTypes
{
    public class Consumable : Item
    {
        private int power;

        public Consumable(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int power) : base(name, description, buyPrice, sellPrice, maxQuantity)
        {
            this.Power = power;
        }

        public int Power { get => power; set => power = value; }
    }
}
