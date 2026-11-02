using System;
using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Quests;

namespace TurnBasedRPG.Source.Entities.AllyRoles
{
    public class QuestGiver : Ally
    {
        private List<Quest> quests;

        public QuestGiver(string name, string spritePath, int money, List<Quest> quests) : base(name, spritePath, money)
        {
            this.Quests = quests;
        }

        public List<Quest> Quests { get => quests; set => quests = value; }

        public override void Talk()
        {
            Game.Instance.openDialog(EntryDialog);

            foreach (Quest quest in quests)
                if (quest.isOpen())
                    Game.Instance.AddQuest(quest);

            Console.WriteLine("New quest(s) are added.");
        }
    }
}
