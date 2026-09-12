using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;

namespace TurnBasedRPG.Source.GameObjects.Items
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Consumable), nameof(Consumable))]
    [JsonDerivedType(typeof(Equippable), nameof(Equippable))]
    [JsonDerivedType(typeof(HealingItem), nameof(HealingItem))]
    [JsonDerivedType(typeof(ManaIncreaseItem), nameof(ManaIncreaseItem))]
    [JsonDerivedType(typeof(HybridHealingItem), nameof(HybridHealingItem))]
    [JsonDerivedType(typeof(DamageItem), nameof(DamageItem))]
    [JsonDerivedType(typeof(ReduceMana), nameof(ReduceMana))]

    public class Item : GameObject
    {
        private Entity owner;
        private string name;
        private string description;
        private int buyPrice;
        private int sellPrice;
        private int quantity;
        private int maxQuantity;

        public Item(string name, string description, int buyPrice, int sellPrice, int quantity, int maxQuantity)
        {
            this.Owner = null;
            this.Name = name;
            this.Description = description;
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPrice;
            this.Quantity = quantity;
            this.MaxQuantity = maxQuantity;
        }

        public Item(string name, string description, int buyPrice, int sellPrice, int maxQuantity)
        {
            this.Owner = null;
            this.Name = name;
            this.Description = description;
            this.BuyPrice = buyPrice;
            this.SellPrice = sellPrice;
            this.Quantity = 1;
            this.MaxQuantity = maxQuantity;
        }

        internal Entity Owner { get => owner; set => owner = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int BuyPrice { get => buyPrice; set => buyPrice = value; }
        public int SellPrice { get => sellPrice; set => sellPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int MaxQuantity { get => maxQuantity; set => maxQuantity = value; }

        //TODO
        public virtual bool Use() { return false; }
    }
}
