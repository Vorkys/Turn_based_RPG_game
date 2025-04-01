using System.Collections.Generic;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Entities.AllyRoles
{
    class Merchant : Ally
    {
        private List<Item> wares;

        public Merchant(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money, List<Item> wares) : base(name, spritePath, inventory, equipment, level, xPtoLevelUp, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.Wares = wares;
        }

        public List<Item> Wares { get => wares; set => wares = value; }

        public override void Talk()
        {
            Game.Instance.openShop(Wares);
        }
    }
}
