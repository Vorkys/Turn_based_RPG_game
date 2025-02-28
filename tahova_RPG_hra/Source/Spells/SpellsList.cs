using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.Spells
{
    class HealSpell : Spell
    {
        public HealSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance, missChance)
        {
        }

        public override void Cast()
        {
            Caster.IncreaseHealth(Power);
            Caster.ReduceMana(Cost);
        }
    }

    class DamageSpell : Spell
    {
        public DamageSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance, missChance)
        {
        }

        public override void Cast()
        {
            Caster.Target.ReduceHealth(Power);
            Caster.ReduceMana(Cost);
        }
    }
}
