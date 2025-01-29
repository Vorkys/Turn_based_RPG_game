using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class BossNode : Node
    {
        private int bossLvl;
        private Enemy boss;

        public BossNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, int bossLvl, Enemy boss) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.bossLvl = bossLvl;
            this.boss = boss;
        }

        public override void Traverse() { }
    }
}
