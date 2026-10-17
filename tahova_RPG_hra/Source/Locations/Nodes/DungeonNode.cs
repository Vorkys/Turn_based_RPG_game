using TurnBasedRPG.Source.Core;

namespace TurnBasedRPG.Source.Locations.Nodes
{
    public class DungeonNode : Node
    {
        private string newLocationName;

        public DungeonNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable, string newLocationName) : base(nodeChar, foregroundColor, backgroundColor, mapColor, isMovable)
        {
            this.NewLocationName = newLocationName;
        }

        public string NewLocationName { get => newLocationName; set => newLocationName = value; }

        public override void Traverse()
        {
            base.Traverse();

            Game.Instance.changeLocation(NewLocationName);
        }
    }
}
