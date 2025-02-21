﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class DialogNode : Node
    {
        private string[] dialog;
        private bool visited;

        public DialogNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, string[] dialog) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.dialog = dialog;
            this.visited = false;
        }

        public override void Traverse(Game game)
        {
            if (!visited)
            {
                game.openDialog(dialog);
                visited = true;
            }
        }
    }
}
