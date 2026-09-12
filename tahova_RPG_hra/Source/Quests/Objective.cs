using System.Collections.Generic;
using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.Quests.QuestObjectives;
using static TurnBasedRPG.Source.Entities.Enemy;

namespace TurnBasedRPG.Source.Quests
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(KillObjective), nameof(KillObjective))]
    [JsonDerivedType(typeof(LootObjective), nameof(LootObjective))]

    public class Objective
    {
        private bool isCompleted;
        private string description;

        public Objective(bool isCompleted, string description)
        {
            this.isCompleted = isCompleted;
            this.description = description;
        }

        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }
        public string Description { get => description; set => description = value; }

        public virtual void UpdateObjective(Enemy enemy) { }
        public virtual void UpdateObjective(List<Drop> items) { }
    }
}
