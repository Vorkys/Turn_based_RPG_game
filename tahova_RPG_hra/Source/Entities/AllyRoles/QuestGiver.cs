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
            Quests = quests;
        }

        public List<Quest> Quests { get => quests; set => quests = value; }

        public override void Talk()
        {
            foreach (Quest quest in Game.Instance.ActiveQuests)
                quest.RecalculateActiveQuestsStatus();

            foreach (Quest quest in quests)
            {
                quest.RecalculateOpenStatus();

                bool isQuestAddable = true;

                //when quest is taken can no longer take it again
                if (quest.isOpen())
                {
                    //make sure quest isnt already taken
                    foreach (Quest activeQuests in Game.Instance.ActiveQuests)
                        if (quest.Name == activeQuests.Name)
                        {
                            isQuestAddable = false;
                            break;
                        }

                    if (isQuestAddable)
                        Game.Instance.AddQuest(quest);
                }
            }
        }
    }
}
