using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.Entities;

namespace TurnBasedRPG.Source.Quests.QuestObjectives
{
    class KillObjective : Objective
    {
        private string enemyName;
        private int requiredKills;
        private int currentKills;

        public KillObjective(string enemyName, int requiredKills)
        {
            this.enemyName = enemyName;
            this.requiredKills = requiredKills;
            this.currentKills = 0;
            Description = $"Kill {RequiredKills} wild {EnemyName}(s).";
        }

        //used for Deserialization
        public KillObjective() { }

        public string EnemyName { get => enemyName; set => enemyName = value; }
        public int RequiredKills { get => requiredKills; set => requiredKills = value; }
        public int CurrentKills { get => currentKills; set => currentKills = value; }

        public override void UpdateObjective(Enemy enemy)
        {
            if (IsCompleted)
                return;

            CombatState castInstanceState = (CombatState)Game.Instance.GameState;

            if (enemy.Name.ToLower().Contains(EnemyName.ToLower()))
            {
                CurrentKills++;
                castInstanceState.QuestInfoText = "Quest objective updated!";
            }

            if (CurrentKills >= RequiredKills)
                IsCompleted = true;
        }
    }
}
