using System;
using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Quests;
using TurnBasedRPG.Source.Spells;

namespace TurnBasedRPG.Source.Entities.AllyRoles
{
    public class ArenaOrganisator : Ally
    {
        private List<Enemy> enemies;

        public ArenaOrganisator(string name, string spritePath, int money, List<Enemy> enemies) : base(name, spritePath, money)
        {
            this.Enemies = enemies;
        }

        public List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public override void Talk()
        {
            Random rand = new Random();

            int randomEnemyId = rand.Next(0, Enemies.Count);
            Enemy randEnemy = Enemies[randomEnemyId];

            //clone enemy
            Enemy combatEnemy = new Enemy(
                randEnemy.Name,
                randEnemy.SpritePath,
                randEnemy.Level,
                randEnemy.MaxLevel,
                randEnemy.MaxHealth,
                randEnemy.MaxMana,
                randEnemy.Spells,
                randEnemy.Damage,
                randEnemy.CriticalHitChance,
                randEnemy.MissChance,
                randEnemy.Armor,
                randEnemy.Speed,
                randEnemy.ItemDrops,
                randEnemy.GoldDrop,
                randEnemy.EscapeChance,
                randEnemy.XpDrop
            );

            Game.Instance.startCombat(combatEnemy);
        }
    }
}
