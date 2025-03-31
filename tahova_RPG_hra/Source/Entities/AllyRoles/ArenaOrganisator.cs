using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Entities.AllyRoles
{
    class ArenaOrganisator : Ally
    {
        private List<Enemy> enemies;

        public ArenaOrganisator(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money, Quest[] quests, List<Enemy> enemies) : base(name, spritePath, inventory, equipment, level, xPtoLevelUp, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.Enemies = enemies;
        }

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public override void Talk()
        {
            Random rand = new Random();

            int randomEnemyId = rand.Next(0, Enemies.Count);
            Enemy enemy = Enemies[randomEnemyId];

            Game.Instance.startCombat(enemy);
        }
    }
}
