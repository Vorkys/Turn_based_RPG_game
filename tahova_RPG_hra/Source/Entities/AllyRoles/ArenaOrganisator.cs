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
            Enemy enemy = Enemies[randomEnemyId];

            Game.Instance.startCombat(enemy);
        }
    }
}
