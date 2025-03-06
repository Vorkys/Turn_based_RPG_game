using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Spells
{
    internal abstract class Spell
    {
        private Entity caster;
        private string name;
        private string description;
        private int cost;
        private int power;
        private int criticalHitChance;
        private int missChance;

        public Spell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance)
        {
            this.Caster = caster;
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.Power = power;
            this.CriticalHitChance = criticalHitChance;
            this.MissChance = missChance;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Power { get => power; set => power = value; }
        public int CriticalHitChance { get => criticalHitChance; set => criticalHitChance = value; }
        public int MissChance { get => missChance; set => missChance = value; }
        internal Entity Caster { get => caster; set => caster = value; }

        public abstract int Cast();
    }
}
