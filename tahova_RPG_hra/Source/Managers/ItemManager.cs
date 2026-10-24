using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;

namespace TurnBasedRPG.Source.Managers
{
    //Here you can add items. Try to keep the names and descriptions small.
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
        public static Equippable CopperRing = new(
            name: "Copper ring",
            description: "An old copper ring. Provide 3 mana.",
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
            description: "Homemade small grenade. Deals 7 damage to target.",
            buyPrice: 15,
            sellPrice: 6,
            maxQuantity: 50,
            power: 7
            );
        #endregion

        #region T2_items
        public static Equippable LeatherHelmet = new(
            name: "Leather helmet",
            description: "Leather helmet, used by hunters. Provide 2 defence.",
            buyPrice: 19,
            sellPrice: 8,
            slot: Equippable.EquippableSlot.Helm,
            strength: 2
            );
        public static Equippable LeatherBody = new(
            name: "Leather body armor",
            description: "Leather chest, used by hunters. Provide 3 defence.",
            buyPrice: 24,
            sellPrice: 12,
            slot: Equippable.EquippableSlot.Body,
            strength: 3
            );
        public static Equippable LeatherLegs = new(
            name: "Leather legs",
            description: "Leather legs, used by hunters. Provide 2 defence.",
            buyPrice: 19,
            sellPrice: 8,
            slot: Equippable.EquippableSlot.Legs,
            strength: 2
            );
        public static Equippable StoneSword = new(
            name: "Stone sword",
            description: "Stone sword often used for training. Provide 2 attack.",
            buyPrice: 20,
            sellPrice: 9,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 2
            );
        public static Equippable LeatherShield = new(
            name: "Leather shield",
            description: "Leather shield, used by hunters. Provide 2 defence.",
            buyPrice: 32,
            sellPrice: 14,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 2
            );
        public static Equippable IronRing = new(
            name: "Iron ring",
            description: "An old iron ring. Provide 7 mana.",
            buyPrice: 24,
            sellPrice: 10,
            slot: Equippable.EquippableSlot.Ring,
            strength: 7
            );
        //Consumables
        public static HealingItem HealthPotion = new(
            name: "Health potion",
            description: "Glass flask with a red liquid. Provides 7 health.",
            buyPrice: 12,
            sellPrice: 8,
            maxQuantity: 10,
            power: 12
            );
        public static ManaIncreaseItem ManaPotion = new(
            name: "Mana potion",
            description: "Glass flask with a blue liquid. Provides 9 mana.",
            buyPrice: 18,
            sellPrice: 8,
            maxQuantity: 10,
            power: 9
            );
        public static HybridHealingItem PinkPotion = new(
            name: "Pink potion",
            description: "Glass flask with a pink liquid. Provides 9 health & 6 mana.",
            buyPrice: 12,
            sellPrice: 7,
            maxQuantity: 10,
            power: 9,
            manaIncrease: 6
            );
        public static DamageItem Grenade = new(
            name: "Grenade",
            description: "Improved homemade grenade. Deals 11 damage to target.",
            buyPrice: 25,
            sellPrice: 15,
            maxQuantity: 50,
            power: 11
            );
        #endregion

        //T3 ring TODO - used for testing 6.4.2026
        public static Equippable DiamondRing = new(
            name: "Diamond ring",
            description: "A very expensive diamond ring. Provide 20 mana.",
            buyPrice: 600,
            sellPrice: 200,
            slot: Equippable.EquippableSlot.Ring,
            strength: 20
            );
    }
}
