using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Utils;

namespace tahova_RPG_hra.Source.Spells
{
    class HealSpell : Spell
    {
        public HealSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance = 5, missChance = 1)
        {
        }

        public override int Cast()
        {
            bool missRoll = Roll.RollDice(MissChance);

            if (missRoll)
                return 0;

            bool critRoll = Roll.RollDice(CriticalHitChance);

            if (!critRoll)
            {
                Caster.IncreaseHealth(Power);
                Caster.ReduceMana(Cost);
                return 1;
            }
            else
            {
                Caster.IncreaseHealth(Power * 2);
                Caster.ReduceMana(Cost);
                return 2;
            }
        }
    }

    class DamageSpell : Spell
    {
        public DamageSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance = 10, missChance = 2)
        {
        }

        public override int Cast()
        {
            bool missRoll = Roll.RollDice(MissChance);

            if (missRoll)
                return 0;

            bool critRoll = Roll.RollDice(CriticalHitChance);

            if (!critRoll)
            {
                Caster.Target.ReduceHealth(Power);
                Caster.ReduceMana(Cost);
                return 1;
            }
            else
            {
                Caster.Target.ReduceHealth(Power * 2);
                Caster.ReduceMana(Cost);
                return 2;
            }
        }
    }

    class AbsorbSpell : Spell
    {
        public AbsorbSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance = 7, missChance = 3)
        {
        }

        public override int Cast()
        {
            bool missRoll = Roll.RollDice(MissChance);

            if (missRoll)
                return 0;

            bool critRoll = Roll.RollDice(CriticalHitChance);

            if (!critRoll)
            {
                Caster.Target.ReduceHealth(Power);
                Caster.IncreaseHealth((int)(Power / 3));
                Caster.ReduceMana(Cost);
                return 1;
            }
            else
            {
                Caster.Target.ReduceHealth(Power);
                Caster.IncreaseHealth(((int)(Power / 3)) * 2);
                Caster.ReduceMana(Cost);
                return 2;
            }
        }
    }

    class DarkDamageSpell : Spell
    {
        public DarkDamageSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance = 10, missChance = 1)
        {
        }

        public override int Cast()
        {
            bool missRoll = Roll.RollDice(MissChance);

            if (missRoll)
                return 0;

            bool critRoll = Roll.RollDice(CriticalHitChance);

            if (!critRoll)
            {
                Caster.Target.ReduceHealth(Power);
                Caster.ReduceHealth(Cost);
                return 1;
            }
            else
            {
                Caster.Target.ReduceHealth(Power * 2);
                Caster.ReduceHealth(Cost);
                return 2;
            }
        }
    }

    class DarkManaStealSpell : Spell
    {
        public DarkManaStealSpell(Entity caster, string name, string description, int cost, int power, int criticalHitChance, int missChance) : base(caster, name, description, cost, power, criticalHitChance = 5, missChance = 1)
        {
        }

        public override int Cast()
        {
            bool missRoll = Roll.RollDice(MissChance);

            if (missRoll)
                return 0;

            bool critRoll = Roll.RollDice(CriticalHitChance);

            if (!critRoll)
            {
                Caster.Target.ReduceMana(Power);
                Caster.IncreaseMana(Power);
                Caster.ReduceHealth(Cost);
                return 1;
            }
            else
            {
                Caster.Target.ReduceMana(Power * 2);
                Caster.IncreaseMana(Power * 2);
                Caster.ReduceHealth(Cost);
                return 2;
            }
        }
    }
}
