using System.Collections.Generic;
using System.Linq;
using TurnBasedRPG.Source.Quests;

namespace TurnBasedRPG.Source.Managers
{
    public class QuestManager
    {
        public static List<Quest> InitializeQuests()
        {
            List<Quest> quests = new List<Quest>();

            quests.Append(new Quest());

            return quests;
        }
    }
}
