using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class DialogNode : Node
    {
        private string[] dialog;

        public DialogNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, string[] dialog) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.dialog = dialog;
        }

        public override void Traverse() { }
    }
}
