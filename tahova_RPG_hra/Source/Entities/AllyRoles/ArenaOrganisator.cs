using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public ArenaOrganisator(string name, string[] sprite, Item[] inventory, Equippable[] equipment, Entity target, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int? money, Quest[] quests, List<Enemy> enemies) : base(name, sprite, inventory, equipment, target, level, entityXP, xPtoLevelUp, health, maxHealth, mana, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.Enemies = enemies;
        }

        internal List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public override void Talk(Game game)
        {
            Random rand = new Random();

            int randomEnemyId = rand.Next(0, Enemies.Count);
            Enemy enemy = Enemies[randomEnemyId];

            game.startCombat(enemy);
        }
    }
}
