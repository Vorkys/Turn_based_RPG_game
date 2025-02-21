using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    internal class TownNode : Node
    {
        private string name;
        public string description;
        private string[] townSprite;
        private Ally[] townPeople;

        public TownNode(char nodeChar, string foregroundColor, string backgroundColor, string mapColor, bool isMovable, string name, string description, string[] townSprite, Ally[] townPeople) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.name = name;
            this.description = description;
            this.townSprite = townSprite;
            this.townPeople = townPeople;
        }

        //TODO
        public override void Traverse(Game game)
        {
            game.openTown(name, description, townSprite, townPeople);
        }
    }
}
