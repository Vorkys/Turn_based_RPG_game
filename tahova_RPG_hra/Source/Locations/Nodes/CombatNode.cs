using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class CombatNode : Node
    {
        private int spawnRate;
        private int minEnemyLvl;
        private int maxEnemyLvl;
        private Enemy[] enemyToSpawn;

        public CombatNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, int spawnRate, int minEnemyLvl, int maxEnemyLvl, Enemy[] enemyToSpawn) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.spawnRate = spawnRate;
            this.minEnemyLvl = minEnemyLvl;
            this.maxEnemyLvl = maxEnemyLvl;
            this.enemyToSpawn = enemyToSpawn;
        }

        //TODO
        public override void Traverse() { }
    }
}
