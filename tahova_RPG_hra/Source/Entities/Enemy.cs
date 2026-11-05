using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.Entities.EnemyTypes;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.Locations.Nodes;
using TurnBasedRPG.Source.Quests;
using TurnBasedRPG.Source.Spells;
using TurnBasedRPG.Source.Utils;

namespace TurnBasedRPG.Source.Entities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Slime), nameof(Slime))]
    [JsonDerivedType(typeof(Goblin), nameof(Goblin))]
    [JsonDerivedType(typeof(Animal), nameof(Animal))]
    [JsonDerivedType(typeof(Human), nameof(Human))]
    [JsonDerivedType(typeof(Magical), nameof(Magical))]
    [JsonDerivedType(typeof(Demonic), nameof(Demonic))]
    [JsonDerivedType(typeof(Godly), nameof(Godly))]

    public class Enemy : Entity
    {
        public struct Drop
        {
            public Item Item { get; set; }
            public int DropChance { get; set; }

            public Drop(Item item, int dropChance)
            {
                Item = item;
                DropChance = dropChance;
            }

            //used for deserialization
            public Drop() { }
        }

        private List<Drop> itemDrops;
        private int goldDrop;
        private int escapeChance;
        private int xpDrop;

        public Enemy(string name, string spritePath, int level, int maxLevel, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxLevel, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed)
        {
            this.ItemDrops = itemDrops;
            this.GoldDrop = goldDrop;
            this.EscapeChance = escapeChance;
            this.XpDrop = xpDrop;
        }

        public List<Drop> ItemDrops { get => itemDrops; set => itemDrops = value; }
        public int GoldDrop { get => goldDrop; set => goldDrop = value; }
        public int EscapeChance { get => escapeChance; set => escapeChance = value; }
        public int XpDrop { get => xpDrop; set => xpDrop = value; }

        //TODO - when lvl == max/minLevel => break
        public void SetLvl(int setLevel)
        {
            if (setLevel > MaxLevel)
                setLevel = MaxLevel;

            if (setLevel > this.Level)
                IncreaseLvl(setLevel - this.Level);
            else if (setLevel < this.Level)
                ReduceLvl(this.Level - setLevel);
        }

        //default enemy leveling
        public virtual void IncreaseLvl(int numberOfLvls)
        {
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
                numberOfLvls--;
            }

            this.Health = MaxHealth;
            this.Mana = MaxMana;
        }

        //default enemy leveling
        public virtual void ReduceLvl(int numberOfLvls)
        {
            while (numberOfLvls > 0)
            {
                //huge upgrade
                if (this.Level % 5 == 0)
                {
                    this.MaxHealth -= 2;
                    this.MaxMana -= 2;
                    this.Damage -= 1;
                    this.Armor -= 1;
                    this.Speed -= 1;
                }
                //mid upgrade
                else if (this.Level % 3 == 0)
                {
                    this.MaxHealth -= 2;
                    this.MaxMana -= 1;
                    this.Damage -= 1;
                    this.Speed -= 1;
                }
                //average upgrade
                else if (this.Level % 2 == 0)
                {
                    this.MaxHealth -= 1;
                    this.MaxMana -= 1;
                }
                //basic upgrade
                else
                    this.MaxHealth -= 1;

                this.Level--;
                numberOfLvls--;
            }

            this.Health = MaxHealth;
            this.Mana = MaxMana;
        }

        public bool ChooseMove()
        {
            if (Health <= 0)
            {
                Defeated();
                return false;
            }

            CombatState castInstanceState = (CombatState)Game.Instance.GameState;
            int healthPercentage = (this.Health * 100) / this.MaxHealth;
            string combatDialogText = "";

            if (isMissed)
                combatDialogText += $"{Name} missed you with his attack and dealt 0 HP";

            if (healthPercentage < 25 && Inventory != null)
                //search inventory for health potion
                for (int id = 0; id < Inventory.Length; id++)
                    if (Inventory[id] is HealingItem)
                    {
                        HealingItem castHealingItem = (HealingItem)Inventory[id];
                        Inventory[id].Use();
                        combatDialogText += $"{Name} used {castHealingItem.Name} and recovered {castHealingItem.Power} HP.";

                        castInstanceState.CombatDialog = combatDialogText;

                        return true;
                    }

            int cantCastSpell = 0;
            int leastManaNeeded = -1;

            if (Spells != null)
                foreach (Spell spell in Spells)
                    if (leastManaNeeded == -1 || spell.Cost < leastManaNeeded)
                        leastManaNeeded = spell.Cost;

            //check if can cast spell
            if (this.Mana < leastManaNeeded || leastManaNeeded == -1)
                cantCastSpell = 1;

            Random rand = new Random();
            int random = rand.Next(0, 2 - cantCastSpell);

            //attack
            if (random == 0)
            {
                AttackTarget(Damage);
                return true;
            }
            //spell
            else if (random == 1)
                while (true)
                {
                    random = rand.Next(0, Spells.Count);

                    if (Spells[random].Cost <= this.Mana)
                    {
                        CastSpell(random);
                        return true;
                    }
                }

            return false;
        }

        public virtual void Defeated()
        {
            Node castCurrentNode = Game.Instance.Maps[Game.Instance.ActiveMap].Map[Game.Instance.Maps[Game.Instance.ActiveMap].PlayerX][Game.Instance.Maps[Game.Instance.ActiveMap].PlayerY];
            CombatState castInstanceState = (CombatState)Game.Instance.GameState;

            //check for quest items/monster type + Arena monsters cant give objective progression; QoL - items dont need to be in players Inv, just need to "encounter" them
            if (castCurrentNode is not TownNode)
                foreach (Quest quest in Game.Instance.ActiveQuests)
                    foreach (Objective objective in quest.Objectives)
                        objective.UpdateObjective(ItemDrops);

            if (castCurrentNode is not TownNode)
                foreach (Quest quest in Game.Instance.ActiveQuests)
                    foreach (Objective objective in quest.Objectives)
                        objective.UpdateObjective(this);

            //item drops + Arena monsters cant drop any items
            if (castCurrentNode is not TownNode)
                if (ItemDrops != null)
                {
                    for (int i = 0; i < ItemDrops.Count; i++)
                    {
                        bool dropRoll = Roll.RollDice(ItemDrops[i].DropChance);

                        if (dropRoll)
                            castInstanceState.AddItemToDropTable(ItemDrops[i].Item);
                    }
                }

            //player add XP
            int lvlDif = Game.Instance.Player.Level - this.Level;

            //player same lvl as enemy
            if (lvlDif == 0 || lvlDif == 1)
                Game.Instance.Player.EntityXP += this.XpDrop;
            //player smaller lvl than enemy and add bonus xp up to 30%
            else if (lvlDif >= -3 && lvlDif < 0)
                Game.Instance.Player.EntityXP += this.XpDrop + ((this.XpDrop / 10) * -lvlDif);
            //player bigger lvl than enemy then remove some xp up to 80%
            else if (lvlDif > 1 && lvlDif <= 5)
                Game.Instance.Player.EntityXP += this.XpDrop - ((this.XpDrop / 16) * lvlDif);

            //Check if player level up
            if (Game.Instance.Player.EntityXP >= Game.Instance.Player.XPtoLevelUp)
                Game.Instance.Player.IncreaseLvl();

            //player add Gold
            double randomMoneyModifier;
            Random rand = new Random();

            //rand num 0.9 || 1.0 || 1.1
            randomMoneyModifier = rand.Next(9, 12) / 10.0;

            Game.Instance.Player.Money += (int)(this.GoldDrop * randomMoneyModifier);
            castInstanceState.DroppedMoney = (int)(this.GoldDrop * randomMoneyModifier);

            Game.Instance.Player.Target = null;
            //QoL - If player was in combat when standing on a Town node then he probably was in the Arena to open town by default (so he doesnt have to move out and in to load town)
            if (castCurrentNode is TownNode)
            {
                Game.Instance.Player.Health = Game.Instance.Player.MaxHealth;
                Game.Instance.Player.Mana = Game.Instance.Player.MaxMana;
                castCurrentNode.Traverse();
            }
            else if (castInstanceState.DropTable.Count == 0)
                Game.Instance.ChangeState(GameStateType.Exploration);
            else
                castInstanceState.CurrentState = CombatState.CombatDialogState.DropDialog;
        }

        public override int AttackTarget(int damage)
        {
            CombatState castInstanceState = (CombatState)Game.Instance.GameState;
            int damageToDeal = base.AttackTarget(damage);
            string combatDialogText = "";

            if (isMissed)
                combatDialogText += $"{Name} missed you with his attack and dealt 0 HP";
            else if (isCritical)
                combatDialogText += $"{Name} Critically hits you and deal {damageToDeal} HP!";
            else
                combatDialogText += $"{Name} hits you and deal {damageToDeal} HP.";

            Target.ReduceHealth(damageToDeal);

            castInstanceState.CombatDialog = combatDialogText;
            castInstanceState.LastTurnWasPlayer = false;

            //Player is killed
            if (this.Target.Health <= 0)
                Game.Instance.GameOver();
            //Enemy somehow killed himself
            else if (this.Health <= 0)
                this.Defeated();

            return 0;
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
                        combatDialogText += $"{Name} cast {spell.Name} and recovered {spell.Power} HP.";
                        spellCasted = true;
                    }
                    break;
                case DamageSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"{Name} cast {spell.Name} and deal {spell.Power} HP to you.";
                        spellCasted = true;
                    }
                    break;
                case ThornDamageSpell spell:
                    if (spell.Cost <= Mana && spell.Cost / 3 < Health)
                    {
                        spell.Cast();
                        combatDialogText += $"{Name} cast {spell.Name} and deal {spell.Power} HP to you but lost {spell.Cost / 3} HP doing so.";
                        spellCasted = true;
                    }
                    break;
                case AbsorbSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"{Name} cast {spell.Name} and deal {spell.Power} HP to you. {Name} absorbed {spell.Power / 3} HP.";
                        spellCasted = true;
                    }
                    break;
                case DarkDamageSpell spell:
                    if (spell.Cost < Health)
                    {
                        spell.Cast();
                        combatDialogText += $"{Name} cast {spell.Name} and deal {spell.Power} HP to you but lost {spell.Cost} HP doing so.";
                        spellCasted = true;
                    }
                    break;
                case DarkManaStealSpell spell:
                    if (spell.Cost <= Mana)
                    {
                        spell.Cast();
                        combatDialogText += $"{Name} cast {spell.Name} and reduced your MP by {spell.Power} HP.";
                        spellCasted = true;
                    }
                    break;
            }

            if (spellCasted && combatDialogText.Length > GlobalConstants.consoleRenderSizeWidth - 2)
            {
                castInstanceState.CombatDialog = combatDialogText.Substring(0, GlobalConstants.consoleRenderSizeWidth - 2);
                castInstanceState.LastTurnWasPlayer = false;
            }
            else if (spellCasted)
            {
                castInstanceState.CombatDialog = combatDialogText;
                castInstanceState.LastTurnWasPlayer = false;
            }

            return spellCasted;
        }
    }
}
