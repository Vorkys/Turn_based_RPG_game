using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;

namespace tahova_RPG_hra.Source.Managers
{
    class ItemManager
    {
        public static Equippable WoodenHelmet = new("Wooden helmet", "Wooden helmet from an old tree. Provide little defence.", 6, 4, Equippable.EquippableSlot.Helm, 1);
        public static Equippable WoodenBody = new("Wooden body armor", "Wooden chest piece of wood. Provide little defence.", 10, 6, Equippable.EquippableSlot.Body, 2);
        public static Equippable WoodenLegs = new("Wooden legs", "Wooden legs from an old tree. Provide little defence.", 6, 4, Equippable.EquippableSlot.Legs, 1);
        public static Equippable WoodenSword = new("Wooden sword", "Wooden sword often used for training. Provide little attack.", 13, 8, Equippable.EquippableSlot.Main_Hand, 1);
        public static Equippable IronRing = new("Iron Ring", "An old iron ring. Provide little mana.", 6, 2, Equippable.EquippableSlot.Ring, 3);
        public static HealingItem SmallHealthPotion = new(null, "Small health potion", "Small glass flask with a red liquid. Provides little health.", 5, 2, 10, 7);
        public static ManaIncreaseItem SmallManaPotion = new(null, "Small mana potion", "Small glass flask with a blue liquid. Provides little mana.", 5, 2, 10, 4);
        public static HybridHealingItem SmallPinkPotion = new(null, "Small pink potion", "Small glass flask with a pink liquid. Provides very little health & little mana.", 7, 3, 10, 4);
        public static DamageItem SmallGrenade = new(null, "Small grenade", "Homemade small grenade. Deals damage to enemy.", 15, 6, 10, 10);
    }
}
