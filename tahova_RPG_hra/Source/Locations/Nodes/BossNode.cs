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
        private List<string> openDialog;
        private List<string> endDialog;
        private Enemy boss;
        private bool visited;

        public BossNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, List<string> openDialog, List<string> endDialog, Enemy boss, bool visited) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.OpenDialog = openDialog;
            this.EndDialog = endDialog;
            this.Boss = boss;
            this.Visited = visited;
        }

        public List<string> OpenDialog { get => openDialog; set => openDialog = value; }
        public List<string> EndDialog { get => endDialog; set => endDialog = value; }
        public bool Visited { get => visited; set => visited = value; }
        internal Enemy Boss { get => boss; set => boss = value; }

        //TODO - uncomment when Game implemented
        public override void Traverse()
        {
            if (Visited)
                return;

            Game.Instance.openDialog(OpenDialog);

            Game.Instance.startCombat(Boss);

            Game.Instance.openDialog(EndDialog);
        }
    }
}
