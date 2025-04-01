using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Quests.QuestObjective
{
    class KillObjective : Objective
    {
        private string enemyName;
        private int requiredKills;
        private int currentKills;

        public KillObjective(bool isCompleted, string description, string enemyName, int requiredKills, int currentKills) : base(isCompleted, description)
        {
            this.enemyName = enemyName;
            this.requiredKills = requiredKills;
            this.currentKills = currentKills;
            Description = $"Kill {RequiredKills} {EnemyName}(s).";
        }

        public string EnemyName { get => enemyName; set => enemyName = value; }
        public int RequiredKills { get => requiredKills; set => requiredKills = value; }
        public int CurrentKills { get => currentKills; set => currentKills = value; }

        public override void UpdateObjective(Enemy enemy)
        {
            if (IsCompleted)
                return;

            if (enemy.Name.ToLower().Contains(EnemyName.ToLower()))
                this.CurrentKills++;

            if (CurrentKills >= RequiredKills)
                IsCompleted = true;
        }
    }
}
