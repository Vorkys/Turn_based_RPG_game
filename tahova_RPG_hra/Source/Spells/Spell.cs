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
            this.caster = caster;
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.power = power;
            this.criticalHitChance = criticalHitChance;
            this.missChance = missChance;
        }

        public Entity Caster
        {
            get { return caster; }
            set { caster = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public abstract void Cast();
    }
}
