using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;

namespace tahova_RPG_hra.Source.Managers
{
    class ItemManager
    {
        #region T1_items
        //Equipment
        public static Equippable WoodenHelmet = new(
            name: "Wooden helmet",
            description: "Wooden helmet from an old tree. Provide 1 defence.",
            buyPrice: 6,
            sellPrice: 4,
            slot: Equippable.EquippableSlot.Helm,
            strength: 1
            );
        public static Equippable WoodenBody = new(
            name: "Wooden body armor",
            description: "Wooden chest piece of wood. Provide 2 defence.",
            buyPrice: 10,
            sellPrice: 5,
            slot: Equippable.EquippableSlot.Body,
            strength: 2
            );
        public static Equippable WoodenLegs = new(
            name: "Wooden legs",
            description: "Wooden legs from an old tree. Provide 1 defence.",
            buyPrice: 8,
            sellPrice: 4,
            slot: Equippable.EquippableSlot.Legs,
            strength: 1
            );
        public static Equippable WoodenSword = new(
            name: "Wooden sword",
            description: "Wooden sword often used for training. Provide 1 attack.",
            buyPrice: 13,
            sellPrice: 6,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 1
            );
        public static Equippable WoodenShield = new(
            name: "Wooden shield",
            description: "Wooden shield often used for training. Provide 1 defence.",
            buyPrice: 18,
            sellPrice: 7,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 1
            );
        public static Equippable IronRing = new(
            name: "Iron ring",
            description: "An old iron ring. Provide 3 mana.",
            buyPrice: 6,
            sellPrice: 2,
            slot: Equippable.EquippableSlot.Ring,
            strength: 3
            );
        //Consumables
        public static HealingItem SmallHealthPotion = new(
            name: "Small health potion",
            description: "Small glass flask with a red liquid. Provides 7 health.",
            buyPrice: 5,
            sellPrice: 2,
            maxQuantity: 10,
            power: 7
            );
        public static ManaIncreaseItem SmallManaPotion = new(
            name: "Small mana potion",
            description: "Small glass flask with a blue liquid. Provides 4 mana.",
            buyPrice: 5,
            sellPrice: 2,
            maxQuantity: 10,
            power: 4
            );
        public static HybridHealingItem SmallPinkPotion = new(
            name: "Small pink potion",
            description: "Small glass flask with a pink liquid. Provides 4 health & 2 mana.",
            buyPrice: 7,
            sellPrice: 3,
            maxQuantity: 10,
            power: 4,
            manaIncrease: 2
            );
        public static DamageItem SmallGrenade = new(
            name: "Small grenade",
            description: "Homemade small grenade. Deals 5 damage to target.",
            buyPrice: 15,
            sellPrice: 6,
            maxQuantity: 50,
            power: 5
            );
        #endregion
    }
}
