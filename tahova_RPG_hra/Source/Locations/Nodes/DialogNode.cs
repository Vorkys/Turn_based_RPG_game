using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    public class DialogNode : Node
    {
        private List<string> dialog;
        private bool visited;

        public DialogNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, List<string> dialog) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.Dialog = dialog;
            this.Visited = false;
        }

        public List<string> Dialog { get => dialog; set => dialog = value; }
        public bool Visited { get => visited; set => visited = value; }

        public override void Traverse()
        {
            base.Traverse();

            if (!Visited)
            {
                Game.Instance.openDialog(Dialog);
                Visited = true;
            }
        }
    }
}
