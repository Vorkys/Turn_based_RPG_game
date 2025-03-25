using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    public class CombatNode : Node
    {
        private int spawnRate;
        private int minEnemyLvl;
        private int maxEnemyLvl;
        private List<Enemy> enemyToSpawn;

        public CombatNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, int spawnRate, int minEnemyLvl, int maxEnemyLvl, List<Enemy> enemyToSpawn) : base(nodeChar, backgroundColor, foregroundColor, mapColor, isMovable)
        {
            this.SpawnRate = spawnRate;
            this.MinEnemyLvl = minEnemyLvl;
            this.MaxEnemyLvl = maxEnemyLvl;
            this.EnemyToSpawn = enemyToSpawn;
        }

        public int SpawnRate { get => spawnRate; set => spawnRate = value; }
        public int MinEnemyLvl { get => minEnemyLvl; set => minEnemyLvl = value; }
        public int MaxEnemyLvl { get => maxEnemyLvl; set => maxEnemyLvl = value; }
        public List<Enemy> EnemyToSpawn { get => enemyToSpawn; set => enemyToSpawn = value; }

        //TODO
        public override void Traverse()
        {
            base.Traverse();

            if (Game.Instance.Player.ImmuneMoves > 0)
                return;
            
            Random rand = new Random();

            int spawnRoll = rand.Next(1, 101);

            //TODO - implement imune steps after successfull combat
            //enemy spawn roll is positive combat iniciated
            if (spawnRoll <= SpawnRate)
            {
                int randLvl = rand.Next(MinEnemyLvl, MaxEnemyLvl + 1);
                Enemy randEnemy = EnemyToSpawn[rand.Next(0, EnemyToSpawn.Count)];
                randEnemy.SetLvl(randLvl);

                Game.Instance.startCombat(randEnemy);
                Game.Instance.Player.ImmuneMoves = 4;
            }
        }
    }
}
