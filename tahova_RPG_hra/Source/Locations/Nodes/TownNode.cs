using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Entities;

namespace TurnBasedRPG.Source.Locations.Nodes
{
    public class TownNode : Node
    {
        private string name;
        private string description;
        private string townSprite;
        private Ally[] townPeople;

        public TownNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, string name, string description, string townSprite, Ally[] townPeople) : base(nodeChar, backgroundColor, foregroundColor, mapColor, isMovable)
        {
            this.Name = name;
            this.Description = description;
            this.TownSprite = townSprite;
            this.TownPeople = townPeople;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string TownSprite { get => townSprite; set => townSprite = value; }
        public Ally[] TownPeople { get => townPeople; set => townPeople = value; }

        public override void Traverse()
        {
            base.Traverse();

            Game.Instance.openTown(this);
        }
    }
}
