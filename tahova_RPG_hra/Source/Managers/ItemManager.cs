using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;

namespace TurnBasedRPG.Source.Managers
{
    //Here you can add items. Try to keep the names and descriptions small.
    class ItemManager
    {
        #region T1_items
        public static Equippable WoodenHelmet = new(
            name: "Wooden helmet",
            description: "Wooden helmet from an old tree. Increase Max Health by 2.",
            buyPrice: 16,
            sellPrice: 7,
            slot: Equippable.EquippableSlot.Helm,
            strength: 2
            );
        public static Equippable WoodenBody = new(
            name: "Wooden body armor",
            description: "Wooden chest piece of wood. Increase Max Health by 3.",
            buyPrice: 20,
            sellPrice: 10,
            slot: Equippable.EquippableSlot.Body,
            strength: 3
            );
        public static Equippable WoodenLegs = new(
            name: "Wooden legs",
            description: "Wooden legs from an old tree. Increase Max Health by 2.",
            buyPrice: 18,
            sellPrice: 7,
            slot: Equippable.EquippableSlot.Legs,
            strength: 2
            );
        public static Equippable WoodenSword = new(
            name: "Wooden sword",
            description: "Wooden sword often used for training. Increase Damage by 1.",
            buyPrice: 17,
            sellPrice: 7,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 1
            );
        public static Equippable WoodenShield = new(
            name: "Wooden shield",
            description: "Wooden shield often used for training. Increase Defence by 1.",
            buyPrice: 16,
            sellPrice: 7,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 1
            );
        public static Equippable CopperRing = new(
            name: "Copper ring",
            description: "An old copper ring. Increase Max Mana by 5.",
            buyPrice: 22,
            sellPrice: 16,
            slot: Equippable.EquippableSlot.Ring,
            strength: 5
            );
        //Consumables
        public static HealingItem SmallHealthPotion = new(
            name: "Small health potion",
            description: "Small glass flask with a red liquid. Provides 10 health.",
            buyPrice: 10,
            sellPrice: 4,
            maxQuantity: 10,
            power: 10
            );
        public static ManaIncreaseItem SmallManaPotion = new(
            name: "Small mana potion",
            description: "Small glass flask with a blue liquid. Provides 10 mana.",
            buyPrice: 10,
            sellPrice: 4,
            maxQuantity: 10,
            power: 10
            );
        public static HybridHealingItem SmallPinkPotion = new(
            name: "Small pink potion",
            description: "Small glass flask with a pink liquid. Provides 7 health & 4 mana.",
            buyPrice: 10,
            sellPrice: 4,
            maxQuantity: 10,
            power: 7,
            manaIncrease: 4
            );
        public static DamageItem SmallGrenade = new(
            name: "Small grenade",
            description: "Homemade small grenade. Deals 10 damage to target.",
            buyPrice: 16,
            sellPrice: 6,
            maxQuantity: 2,
            power: 10
            );
        #endregion

        #region T2_items
        public static Equippable LeatherHelmet = new(
            name: "Leather helmet",
            description: "Leather helmet, used by hunters. Increase Max Health by 3.",
            buyPrice: 67,
            sellPrice: 33,
            slot: Equippable.EquippableSlot.Helm,
            strength: 3
            );
        public static Equippable LeatherBody = new(
            name: "Leather body armor",
            description: "Leather chest, used by hunters. Increase Max Health by 5.",
            buyPrice: 92,
            sellPrice: 41,
            slot: Equippable.EquippableSlot.Body,
            strength: 5
            );
        public static Equippable LeatherLegs = new(
            name: "Leather legs",
            description: "Leather legs, used by hunters. Increase Max Health by 3.",
            buyPrice: 78,
            sellPrice: 37,
            slot: Equippable.EquippableSlot.Legs,
            strength: 3
            );
        public static Equippable StoneSword = new(
            name: "Stone sword",
            description: "Stone sword often used for training. Increase Damage by 3.",
            buyPrice: 85,
            sellPrice: 40,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 3
            );
        public static Equippable LeatherShield = new(
            name: "Leather shield",
            description: "Leather shield, used by hunters. Increase Defence by 3.",
            buyPrice: 80,
            sellPrice: 38,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 3
            );
        public static Equippable IronRing = new(
            name: "Iron ring",
            description: "An old iron ring. Increase Max Mana by 10.",
            buyPrice: 75,
            sellPrice: 30,
            slot: Equippable.EquippableSlot.Ring,
            strength: 10
            );
        public static HealingItem HealthPotion = new(
            name: "Health potion",
            description: "Glass flask with a red liquid. Provides 16 health.",
            buyPrice: 25,
            sellPrice: 12,
            maxQuantity: 10,
            power: 16
            );
        public static ManaIncreaseItem ManaPotion = new(
            name: "Mana potion",
            description: "Glass flask with a blue liquid. Provides 16 mana.",
            buyPrice: 25,
            sellPrice: 12,
            maxQuantity: 10,
            power: 16
            );
        public static HybridHealingItem PinkPotion = new(
            name: "Pink potion",
            description: "Glass flask with a pink liquid. Provides 12 health & 8 mana.",
            buyPrice: 25,
            sellPrice: 12,
            maxQuantity: 10,
            power: 12,
            manaIncrease: 8
            );
        public static DamageItem Grenade = new(
            name: "Grenade",
            description: "Improved homemade grenade. Deals 18 damage to target.",
            buyPrice: 55,
            sellPrice: 26,
            maxQuantity: 2,
            power: 18
            );
        #endregion

        #region T3_items
        public static Equippable IronHelmet = new(
            name: "Iron helmet",
            description: "Iron helmet. Increase Max Health by 6.",
            buyPrice: 206,
            sellPrice: 99,
            slot: Equippable.EquippableSlot.Helm,
            strength: 6
            );
        public static Equippable IronBody = new(
            name: "Iron body armor",
            description: "Iron chest, used by hunters. Increase Max Health by 8.",
            buyPrice: 305,
            sellPrice: 120,
            slot: Equippable.EquippableSlot.Body,
            strength: 8
            );
        public static Equippable IronLegs = new(
            name: "Iron legs",
            description: "Iron legs, used by hunters. Increase Max Health by 6.",
            buyPrice: 225,
            sellPrice: 115,
            slot: Equippable.EquippableSlot.Legs,
            strength: 6
            );
        public static Equippable IronSword = new(
            name: "Iron sword",
            description: "Iron sword often used for training. Increase Damage by 5.",
            buyPrice: 295,
            sellPrice: 120,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 5
            );
        public static Equippable IronShield = new(
            name: "Iron shield",
            description: "Iron shield, used by hunters. Increase Defence by 5.",
            buyPrice: 276,
            sellPrice: 110,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 5
            );
        public static Equippable GoldRing = new(
            name: "Gold ring",
            description: "A Gold iron ring. Increase Max Mana by 18.",
            buyPrice: 215,
            sellPrice: 140,
            slot: Equippable.EquippableSlot.Ring,
            strength: 18
            );
        public static HealingItem BigHealthPotion = new(
            name: "Health potion",
            description: "Glass flask with a red liquid. Provides 24 health.",
            buyPrice: 75,
            sellPrice: 25,
            maxQuantity: 10,
            power: 24
            );
        public static ManaIncreaseItem BigManaPotion = new(
            name: "Mana potion",
            description: "Glass flask with a blue liquid. Provides 24 mana.",
            buyPrice: 75,
            sellPrice: 25,
            maxQuantity: 10,
            power: 24
            );
        public static HybridHealingItem BigPinkPotion = new(
            name: "Pink potion",
            description: "Glass flask with a pink liquid. Provides 18 health & 13 mana.",
            buyPrice: 75,
            sellPrice: 25,
            maxQuantity: 10,
            power: 18,
            manaIncrease: 13
            );
        public static DamageItem BigGrenade = new(
            name: "Big Grenade",
            description: "Improved homemade grenade. Deals 25 damage to target.",
            buyPrice: 120,
            sellPrice: 50,
            maxQuantity: 2,
            power: 25
            );
        #endregion

        #region T4_items
        public static Equippable HellishHelmet = new(
            name: "Hellish helmet",
            description: "Hellish helmet directly from hell. Increase Max Health by 10.",
            buyPrice: 386,
            sellPrice: 179,
            slot: Equippable.EquippableSlot.Helm,
            strength: 10
            );
        public static Equippable HellishBody = new(
            name: "Hellish body armor",
            description: "Hellish chest directly from hell. Increase Max Health by 14.",
            buyPrice: 532,
            sellPrice: 210,
            slot: Equippable.EquippableSlot.Body,
            strength: 14
            );
        public static Equippable HellishLegs = new(
            name: "Hellish legs",
            description: "Hellish legs, used by hunters. Increase Max Health by 10.",
            buyPrice: 467,
            sellPrice: 198,
            slot: Equippable.EquippableSlot.Legs,
            strength: 10
            );
        public static Equippable HellishSword = new(
            name: "Hellish sword",
            description: "Hellish sword often used for training. Increase Damage by 8.",
            buyPrice: 548,
            sellPrice: 265,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 8
            );
        public static Equippable HellishShield = new(
            name: "Hellish shield",
            description: "Hellish shield, used by hunters. Increase Defence by 8.",
            buyPrice: 522,
            sellPrice: 250,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 8
            );
        public static Equippable GoldRingWithSaphire = new(
            name: "Gold ring with Saphire",
            description: "A Gold iron ring with a nice Saphire. Increase Max Mana by 25.",
            buyPrice: 370,
            sellPrice: 200,
            slot: Equippable.EquippableSlot.Ring,
            strength: 25
            );
        public static HealingItem EnormousHealthPotion = new(
            name: "Enormous Health potion",
            description: "Glass flask with a red liquid. Provides 35 health.",
            buyPrice: 150,
            sellPrice: 50,
            maxQuantity: 10,
            power: 35
            );
        public static ManaIncreaseItem EnormousManaPotion = new(
            name: "Enormous Mana potion",
            description: "Glass flask with a blue liquid. Provides 35 mana.",
            buyPrice: 150,
            sellPrice: 50,
            maxQuantity: 10,
            power: 35
            );
        public static HybridHealingItem EnormousPinkPotion = new(
            name: "Enormous Pink potion",
            description: "Glass flask with a pink liquid. Provides 24 health & 18 mana.",
            buyPrice: 150,
            sellPrice: 50,
            maxQuantity: 10,
            power: 24,
            manaIncrease: 18
            );
        public static DamageItem Dynamite = new(
            name: "Dynamite",
            description: "Dynamite, very dangerous. Handle with care. Deals 33 damage to target.",
            buyPrice: 250,
            sellPrice: 120,
            maxQuantity: 2,
            power: 33
            );
        #endregion

        #region T5_items
        public static Equippable HeavenlyHelmet = new(
            name: "Heavenly helmet",
            description: "Heavenly helmet. Increase Max Health by 16.",
            buyPrice: 768,
            sellPrice: 386,
            slot: Equippable.EquippableSlot.Helm,
            strength: 16
            );
        public static Equippable HeavenlyBody = new(
            name: "Heavenly body armor",
            description: "Heavenly chest, used by hunters. Increase Max Health by 24.",
            buyPrice: 1058,
            sellPrice: 604,
            slot: Equippable.EquippableSlot.Body,
            strength: 24
            );
        public static Equippable HeavenlyLegs = new(
            name: "Heavenly legs",
            description: "Heavenly legs, used by hunters. Increase Max Health by 16.",
            buyPrice: 815,
            sellPrice: 396,
            slot: Equippable.EquippableSlot.Legs,
            strength: 16
            );
        public static Equippable HeavenlySword = new(
            name: "Heavenly sword",
            description: "Heavenly sword often used for training. Increase Damage by 10.",
            buyPrice: 930,
            sellPrice: 470,
            slot: Equippable.EquippableSlot.Main_Hand,
            strength: 10
            );
        public static Equippable HeavenlyShield = new(
            name: "Heavenly shield",
            description: "Heavenly shield, used by hunters. Increase Defence by 10.",
            buyPrice: 900,
            sellPrice: 450,
            slot: Equippable.EquippableSlot.Off_Hand,
            strength: 10
            );
        public static Equippable GoldRingWithDiamond = new(
            name: "Gold ring with Diamond",
            description: "A Gold iron ring with a magnificent Diamond. Increase Max Mana by 40.",
            buyPrice: 752,
            sellPrice: 468,
            slot: Equippable.EquippableSlot.Ring,
            strength: 40
            );
        public static BottomlessHealingItem BottomlessHealthPotion = new(
            name: "Bottomless Health potion",
            description: "Glass flask with a red liquid. Provides 30 health.",
            buyPrice: 400,
            sellPrice: 300,
            maxQuantity: 1,
            power: 30
            );
        public static BottomlessManaIncreaseItem BottomlessManaPotion = new(
            name: "Bottomless Mana potion",
            description: "Glass flask with a blue liquid. Provides 30 mana.",
            buyPrice: 400,
            sellPrice: 300,
            maxQuantity: 1,
            power: 30
            );
        public static BottomlessHybridHealingItem BottomlessPinkPotion = new(
            name: "Bottomless Pink potion",
            description: "Glass flask with a pink liquid. Provides 22 health & 18 mana.",
            buyPrice: 400,
            sellPrice: 300,
            maxQuantity: 1,
            power: 22,
            manaIncrease: 18
            );
        public static DamageItem TNT = new(
            name: "TNT",
            description: "Very dangerous. Handle with a LOT of care. Deals 40 damage to target.",
            buyPrice: 450,
            sellPrice: 225,
            maxQuantity: 2,
            power: 40
            );
        #endregion

        #region Quest_Items
        //T1
        public static Item WolfTusk = new(
            name: "Wolf tusk",
            description: "Wolf tusk. Can be looted from Wolves in the Plains.",
            buyPrice: 0,
            sellPrice: 0,
            maxQuantity: 99
        );

        //T2
        public static Item MagicDust = new(
            name: "Magic Dust",
            description: "This dust is only found in the Forest. Drops from magical beings.",
            buyPrice: 0,
            sellPrice: 0,
            maxQuantity: 99
        );

        //T4
        public static Item CorruptedHeart = new(
            name: "Corrupted Hearth",
            description: "This Heart could help scientists to find a cure for me.",
            buyPrice: 0,
            sellPrice: 0,
            maxQuantity: 99
        );

        //T5
        public static Item HolyHeart = new(
            name: "Holy Heart",
            description: "I need to add this to a holy mixture in combination with Corrupted Heart.",
            buyPrice: 0,
            sellPrice: 0,
            maxQuantity: 99
        );
        #endregion
    }
}
