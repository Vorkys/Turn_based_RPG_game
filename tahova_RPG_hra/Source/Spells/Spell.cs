using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Entities;

namespace TurnBasedRPG.Source.Spells
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(HealSpell), nameof(HealSpell))]
    [JsonDerivedType(typeof(DamageSpell), nameof(DamageSpell))]
    [JsonDerivedType(typeof(AbsorbSpell), nameof(AbsorbSpell))]
    [JsonDerivedType(typeof(DarkDamageSpell), nameof(DarkDamageSpell))]
    [JsonDerivedType(typeof(DarkManaStealSpell), nameof(DarkManaStealSpell))]

    public abstract class Spell
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

        internal Entity Caster { get => caster; set => caster = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Power { get => power; set => power = value; }
        public int CriticalHitChance { get => criticalHitChance; set => criticalHitChance = value; }
        public int MissChance { get => missChance; set => missChance = value; }

        public abstract int Cast();
    }
}
