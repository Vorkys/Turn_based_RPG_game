using System.Collections.Generic;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Entities
{
    public class Ally : Entity
    {
        private List<string> entryDialog;

        public Ally(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money) : base(name, spritePath, inventory, equipment, level, xPtoLevelUp, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            entryDialog = null;
        }

        public List<string> EntryDialog { get => entryDialog; set => entryDialog = value; }

        public virtual void Talk() { }
    }
}
