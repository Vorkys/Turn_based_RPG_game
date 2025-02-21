using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class BossNode : Node
    {
        private string[]? openDialog;
        private string[]? endDialog;
        private Enemy boss;

        public BossNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, string[] openDialog, string[] endDialog, Enemy boss) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.openDialog = openDialog;
            this.endDialog = endDialog;
            this.boss = boss;
        }

        //TODO - uncomment when Game implemented
        public override void Traverse(Game game)
        {
            game.openDialog(openDialog);

            game.startCombat(boss);

            game.openDialog(endDialog);
        }
    }
}
