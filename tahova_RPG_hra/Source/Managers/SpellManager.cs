using TurnBasedRPG.Source.Spells;

namespace TurnBasedRPG.Source.Managers
{
    //Here you can add spells. Try to keep the names and descriptions small.
    class SpellManager
    {
        #region T1_spells
        public static DamageSpell Scorch = new(
            caster: null,
            name: "Scorch",
            description: "Use your fire fists to punch your target. Deal 7 HP.",
            cost: 5,
            power: 8,
            criticalHitChance: 6,
            missChance: 3
            );

        public static HealSpell MinorHeal = new(
            caster: null,
            name: "Minor heal",
            description: "Focus your inner self to heal 8 HP.",
            cost: 4,
            power: 7,
            criticalHitChance: 6,
            missChance: 1
            );
        #endregion

        #region T2_spells
        public static DamageSpell IceSpike = new(
            caster: null,
            name: "Ice Spike",
            description: "Use your hands to conjure ice spikes and throw them at your target. Deal 12 HP.",
            cost: 6,
            power: 12,
            criticalHitChance: 6,
            missChance: 3
            );

        public static DarkDamageSpell ShadowPunch = new(
            caster: null,
            name: "Shadow Punch",
            description: "Use your fists empowered by darkness to punch your target. Uses HP instead of MP to cast. Deal 16 HP.",
            cost: 5,
            power: 12,
            criticalHitChance: 6,
            missChance: 3
            );

        public static HealSpell LesserHeal = new(
            caster: null,
            name: "Lesser heal",
            description: "Focus your inner self to heal 20 HP.",
            cost: 11,
            power: 20,
            criticalHitChance: 6,
            missChance: 1
            );
        #endregion

        #region T3_spells
        public static AbsorbSpell Absorb = new(
            caster: null,
            name: "Absorb",
            description: "Absorb health from your target. Deal 21 HP and heal 1/3 of Damage.",
            cost: 14,
            power: 21,
            criticalHitChance: 6,
            missChance: 3
            );

        public static ThornDamageSpell ThornSlash = new(
            caster: null,
            name: "Thorn Slash",
            description: "Conjure a thorn whip and smack your target. Loose 1/3 of MP cost and Deal 30 HP.",
            cost: 15,
            power: 30,
            criticalHitChance: 6,
            missChance: 3
            );
        #endregion

        #region T4_spells
        public static HealSpell Heal = new(
            caster: null,
            name: "Heal",
            description: "Focus your inner self to heal 38 HP.",
            cost: 19,
            power: 38,
            criticalHitChance: 6,
            missChance: 1
            );

        public static DamageSpell EarthShock = new(
            caster: null,
            name: "Earth Shock",
            description: "Conjure a small earthquake. Deal 42 HP.",
            cost: 20,
            power: 42,
            criticalHitChance: 6,
            missChance: 3
            );
        #endregion

        #region T5_spells
        public static HealSpell MajorHeal = new(
            caster: null,
            name: "Major Heal",
            description: "Focus your inner self to heal 80 HP.",
            cost: 40,
            power: 80,
            criticalHitChance: 6,
            missChance: 1
            );

        public static DamageSpell MindShock = new(
            caster: null,
            name: "Mind Shock",
            description: "Make your target go crazy. Deal 68 HP.",
            cost: 29,
            power: 68,
            criticalHitChance: 6,
            missChance: 3
            );
        #endregion

        #region Bonus_spells
        public static DamageSpell HolySmite = new(
            caster: null,
            name: "Holy Smite",
            description: "Smite your target. Deal 80 HP.",
            cost: 32,
            power: 80,
            criticalHitChance: 6,
            missChance: 3
            );

        public static HealSpell HolyHeal = new(
            caster: null,
            name: "Holy Heal",
            description: "Focus your inner self to heal 100 HP.",
            cost: 45,
            power: 100,
            criticalHitChance: 2,
            missChance: 0
            );

        public static DamageSpell Armagedon = new(
            caster: null,
            name: "Armagedon",
            description: "Send a meteor on your target.",
            cost: 1,
            power: 1000,
            criticalHitChance: 0,
            missChance: 0
            );
        #endregion
    }
}
