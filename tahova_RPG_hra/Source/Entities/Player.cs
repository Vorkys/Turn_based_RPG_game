using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Managers;
using TurnBasedRPG.Source.Spells;
using TurnBasedRPG.Source.Utils;

namespace TurnBasedRPG.Source.Entities
{
    public class Player : Entity
    {
        private int immuneMoves;

        public Player(string name, string spritePath, Item[] inventory, Equippable[] equipment, int level, int xPtoLevelUp, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money) : base(name, spritePath, inventory, equipment, level, xPtoLevelUp, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            ImmuneMoves = 4;
            Spells = new List<Spell>();
            Inventory = [null, null, null, null, null, null, null, null, null, null];
            Equipment = [null, null, null, null, null, null];

            AddItem(ItemManager.SmallHealthPotion, 3);
            AddItem(ItemManager.SmallManaPotion, 2);
        }

        //used for Deserialization
        public Player() { }

        public int ImmuneMoves { get => immuneMoves; set => immuneMoves = value; }

        private void AddSpell(Spell spell)
        {
            Spells.Add(spell);
            Spells[Spells.Count - 1].Caster = this;
        }

        public virtual void IncreaseLvl(int numberOfLvls = 1)
        {
            if (Level == MaxLevel)
                return;

            if (EntityXP >= XPtoLevelUp)
                EntityXP -= XPtoLevelUp;

            while (numberOfLvls > 0 && Level < MaxLevel)
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

                switch (Level)
                {
                    case 3:
                        AddSpell(SpellManager.Scorch);
                        break;
                    case 5:
                        AddSpell(SpellManager.MinorHeal);
                        break;
                    case 8:
                        AddSpell(SpellManager.IceSpike);
                        break;
                    case 11:
                        AddSpell(SpellManager.ShadowPunch);
                        break;
                    case 13:
                        AddSpell(SpellManager.LesserHeal);
                        break;
                    case 16:
                        AddSpell(SpellManager.Absorb);
                        break;
                    case 19:
                        AddSpell(SpellManager.ThornSlash);
                        break;
                    case 21:
                        AddSpell(SpellManager.Heal);
                        break;
                    case 24:
                        AddSpell(SpellManager.EarthShock);
                        break;
                    case 27:
                        AddSpell(SpellManager.MajorHeal);
                        break;
                    case 29:
                        AddSpell(SpellManager.MindShock);
                        break;
                    case 32:
                        AddSpell(SpellManager.HolySmite);
                        break;
                    case 35:
                        AddSpell(SpellManager.HolyHeal);
                        break;
                    case 40:
                        AddSpell(SpellManager.Armagedon);
                        break;
                }

                numberOfLvls--;
            }

            this.Health = MaxHealth;
            this.Mana = MaxMana;
        }

        public bool FreeSpaceInInventory(int requiredFreeSpaces = 1)
        {
            int freeSpaces = 0;

            for (int inventoryId = 0; inventoryId < Inventory.Length; inventoryId++)
                if (Inventory[inventoryId] == null)
                    freeSpaces++;

            return freeSpaces >= requiredFreeSpaces ? true : false;
        }

        public override int AttackTarget(int damage)
        {
            CombatState castInstanceState = (CombatState)Game.Instance.GameState;
            int damageToDeal = base.AttackTarget(damage);
            string combatDialogText = "";

            if (isMissed)
                combatDialogText += "You missed your target with your attack and dealt 0 HP";
            else if (isCritical)
                combatDialogText += $"You Critically hit your target and deal {damageToDeal} HP!";
            else
                combatDialogText += $"You hit your target and deal {damageToDeal} HP.";

            Target.ReduceHealth(damageToDeal);

            castInstanceState.CombatDialog = combatDialogText;
            castInstanceState.LastTurnWasPlayer = true;

            return 1;
        }

        public bool CastSpell(int spellIndex)
        {
            CombatState castInstanceState = (CombatState)Game.Instance.GameState;
            string combatDialogText = "";
            bool spellCasted = false;

            switch (Spells[spellIndex])
            {
                case HealSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and recovered {spell.Power} HP.";
                        spellCasted = true;
                    }
                    break;
                case DamageSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and deal {spell.Power} HP to your target.";
                        spellCasted = true;
                    }
                    break;
                case ThornDamageSpell spell:
                    if (spell.Cost <= Mana && spell.Cost / 3 < Health)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and deal {spell.Power} HP to your target but lost {spell.Cost/3} HP doing so.";
                        spellCasted = true;
                    }
                    break;
                case AbsorbSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and deal {spell.Power} HP to your target. You absorbed {spell.Power/3} HP.";
                        spellCasted = true;
                    }
                    break;
                case DarkDamageSpell spell:
                    if (spell.Cost < Health)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and deal {spell.Power} HP to your target but lost {spell.Cost} HP doing so.";
                        spellCasted = true;
                    }
                    break;
                case DarkManaStealSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"You cast {spell.Name} and reduced your target MP by {spell.Power} HP.";
                        spellCasted = true;
                    }
                    break;
            }

            if (spellCasted && combatDialogText.Length > GlobalConstants.consoleRenderSizeWidth - 2)
            {
                castInstanceState.CombatDialog = combatDialogText.Substring(0, GlobalConstants.consoleRenderSizeWidth - 2);
                castInstanceState.LastTurnWasPlayer = true;
            }
            else if (spellCasted)
            {
                castInstanceState.CombatDialog = combatDialogText;
                castInstanceState.LastTurnWasPlayer = true;
            }

            return spellCasted;
        }

        public void UseItem(int itemInventorySlot)
        {
            if (Inventory[itemInventorySlot] is not Consumable)
                return;

            CombatState castInstanceState = (CombatState)Game.Instance.GameState;

            Inventory[itemInventorySlot].Use();

            string combatDialogText = $"You used {Inventory[itemInventorySlot].Name}. ";

            //usage of Pattern matching
            switch (Inventory[itemInventorySlot])
            {
                case HealingItem myItem:
                    combatDialogText += $"You recovered {myItem.Power} HP.";
                    break;
                case ManaIncreaseItem myItem:
                    combatDialogText += $"You recovered {myItem.Power} MP.";
                    break;
                case HybridHealingItem myItem:
                    combatDialogText += $"You recovered {myItem.Power} HP and {myItem.ManaIncrease} MP.";
                    break;
                case DamageItem myItem:
                    combatDialogText += $"You dealt {myItem.Power} HP to your target.";
                    break;
                case ReduceMana myItem:
                    combatDialogText += $"You reduced {myItem.Power} MP to your target.";
                    break;
            }

            castInstanceState.CombatDialog = combatDialogText;
            castInstanceState.LastTurnWasPlayer = true;
        }
    }
}
