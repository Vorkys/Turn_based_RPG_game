using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Managers
{
    class SpellManager
    {
        public static HealSpell MinorHeal = new(
            caster: null,
            name: "Minor heal",
            description: "Focus your inner self to heal a little bit.",
            cost: 3,
            power: 6,
            criticalHitChance: 5,
            missChance: 1
            );

        public static HealSpell LesserHeal = new(
            caster: null,
            name: "Lesser heal",
            description: "Focus your inner self to heal a bit.",
            cost: 6,
            power: 12,
            criticalHitChance: 5,
            missChance: 1
            );

        public static DamageSpell Scorch = new(
            caster: null,
            name: "Scorch",
            description: "Use your fire fists to punch your target.",
            cost: 3,
            power: 6,
            criticalHitChance: 10,
            missChance: 2
            );

        public static DamageSpell IceSpikes = new(
            caster: null,
            name: "Ice spikes",
            description: "Throw ice spikes at your enemy.",
            cost: 7,
            power: 10,
            criticalHitChance: 10,
            missChance: 2
            );

        public static AbsorbSpell AbsorbBolt = new(
            caster: null,
            name: "Absorb bolt",
            description: "Attack your enemy with a bolt that heals you a portion of the damage.",
            cost: 15,
            power: 30,
            criticalHitChance: 10,
            missChance: 2
            );

        public static DarkDamageSpell ShadowPunch = new(
            caster: null,
            name: "Shadow punch",
            description: "Use your own life force to strengthen your punch.",
            cost: 5,
            power: 10,
            criticalHitChance: 10,
            missChance: 2
            );
    }
}
