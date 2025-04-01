using System.Collections.Generic;
using System.Linq;
using tahova_RPG_hra.Source.Quests;

namespace tahova_RPG_hra.Source.Managers
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
