using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.GameObjects.Items;
using static tahova_RPG_hra.Source.Entities.Enemy;

namespace tahova_RPG_hra.Source.Quests
{
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
