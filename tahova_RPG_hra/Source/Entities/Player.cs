﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Managers;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;

namespace tahova_RPG_hra.Source.Entities
{
    internal class Player : Entity
    {
        private int immuneMoves;

        public Player(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money) : base(name, spritePath, inventory, equipment, level, xPtoLevelUp, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.ImmuneMoves = 4;
            Spells = new List<Spell>();
        }

        public int ImmuneMoves { get => immuneMoves; set => immuneMoves = value; }

        private void AddSpell(Spell spell)
        {
            Spells.Add(SpellManager.MinorHeal);
            Spells[Spells.Count - 1].Caster = this;
        }

        public virtual void IncreaseLvl(int numberOfLvls = 1)
        {
            if (Level == MaxLevel)
                return;

            int xpOverflow = EntityXP - XPtoLevelUp;

            while (numberOfLvls > 0)
            {
                //huge upgrade
                if (this.Level % 5 == 0)
                {
                    this.MaxHealth += 2;
                    this.MaxMana += 2;
                    this.Damage += 1;
                    this.Armor += 1;
                    this.Speed += 1;
                }
                //mid upgrade
                else if (this.Level % 3 == 0)
                {
                    this.MaxHealth += 2;
                    this.MaxMana += 1;
                    this.Damage += 1;
                    this.Speed += 1;
                }
                //average upgrade
                else if (this.Level % 2 == 0)
                {
                    this.MaxHealth += 1;
                    this.MaxMana += 1;
                }
                //basic upgrade
                else
                    this.MaxHealth += 1;

                this.Level++;
                numberOfLvls--;
            }

            this.Health = MaxHealth;
            this.Mana = MaxMana;
            this.EntityXP = xpOverflow;

            switch (Level)
            {
                case 2:
                    AddSpell(SpellManager.MinorHeal);
                    break;
                case 3:
                    AddSpell(SpellManager.Scorch);
                    break;
                case 6:
                    AddSpell(SpellManager.IceSpikes);
                    break;
                case 7:
                    AddSpell(SpellManager.ShadowPunch);
                    break;
                case 8:
                    AddSpell(SpellManager.LesserHeal);
                    break;
                case 14:
                    AddSpell(SpellManager.AbsorbBolt);
                    break;
            }
        }

        public override void AttackTarget(int damage)
        {
            base.AttackTarget(damage);

            if (this.Health <= 0)
                Game.Instance.GameOver();
            else if (this.Target.Health <= 0)
            {
                Enemy castTarget = (Enemy)Game.Instance.Player.Target;
                castTarget.Defeated();
            }
        }
    }
}
