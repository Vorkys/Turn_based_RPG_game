using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Quests;

namespace TurnBasedRPG.Source.Locations.Nodes
{
    public class GateKeepNode : Node
    {
        private List<Quest> requiredQuests;

        public GateKeepNode(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, List<Quest> requiredQuests) : base(nodeChar, backgroundColor, foregroundColor, mapColor)
        {
            this.requiredQuests = requiredQuests;
            IsMovable = false;
        }

        public List<Quest> RequiredQuests { get => requiredQuests; }

        public void UpdateMovable()
        {
            if (requiredQuests == null)
                IsMovable = true;

            bool allRequirementsOK = false;
            bool breakCycle = false;

            foreach (Quest quest in requiredQuests)
            {
                foreach (Quest activeQuest in Game.Instance.ActiveQuests)
                {
                    if (quest.Name == activeQuest.Name && activeQuest.Status == Status.Finished)
                        allRequirementsOK = true;
                    else if (quest.Name == activeQuest.Name && activeQuest.Status != Status.Finished)
                    {
                        allRequirementsOK = false;
                        breakCycle = true;
                        break;
                    }
                }

                if (breakCycle)
                    break;
            }

            IsMovable = allRequirementsOK;
        }

        public override void Traverse()
        {
            if (Game.Instance.Player.ImmuneMoves > 0)
                Game.Instance.Player.ImmuneMoves--;
        }
    }
}
