using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Core.GameStates;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;
using tahova_RPG_hra.Source.Statuses;
using tahova_RPG_hra.Source.Utils;

namespace tahova_RPG_hra.Source.Entities
{
    public class Enemy : Entity
    {
        public struct Drop
        {
            public Item Item { get; }
            public int DropChance { get; }

            public Drop(Item item, int dropChance)
            {
                Item = item;
                DropChance = dropChance;
            }
        }

        private List<Drop> itemDrops;
        private int goldDrop;
        private int escapeChance;
        private int xpDrop;

        public Enemy(string name, string spritePath, int level, int maxHealth, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, List<Drop> itemDrops, int goldDrop, int escapeChance, int xpDrop) : base(name, spritePath, level, maxHealth, maxMana, spells, damage, criticalHitChance, missChance, armor, speed)
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
            int healthPercentage = (this.Health * 100) / this.MaxHealth;

            if (healthPercentage < 25 && Inventory != null)
                //search inventory for health potion
                for (int id = 0; id < Inventory.Length; id++)
                    if (Inventory[id].Name.ToLower().Contains("potion"))
                    {
                        Inventory[id].Use();

                        if (Game.Instance.GameState is CombatState)
                        {
                            //TODO - BP text "cast"
                            CombatState castGameState = (CombatState)Game.Instance.GameState;
                            castGameState.EntityAction = $"{Name} used {Inventory[id].Name}.";
                        }

                        this.RemoveItem(Inventory[id]);
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
                this.Target.ReduceHealth(this.Damage);

                if (Game.Instance.GameState is CombatState)
                {
                    CombatState castGameState = (CombatState)Game.Instance.GameState;
                    castGameState.EntityAction = $"{Name} attacked {Game.Instance.Player.Name}.";
                }

                return true;
            }
            else if (random == 1)
                while (true) {
                    random = rand.Next(0, Spells.Count);

                    if (Spells[random].Cost <= this.Mana)
                    {
                        Spells[random].Cast();

                        if (Game.Instance.GameState is CombatState)
                        {
                            CombatState castGameState = (CombatState)Game.Instance.GameState;
                            castGameState.EntityAction = $"{Name} casted {Spells[random].Name}.";
                        }
                        return true;
                    }

                }

            return false;
        }

        public virtual void Defeated()
        {
            //check for quest items
            foreach (Quest quest in Game.Instance.ActiveQuests)
                foreach (Objective objective in quest.Objectives)
                    objective.UpdateObjective(ItemDrops);

            //item drops
            for (int i = 0; i < ItemDrops.Count; i++)
            {
                bool dropRoll = Roll.RollDice(ItemDrops[i].DropChance);

                if (dropRoll)
                    Game.Instance.Player.AddItem(ItemDrops[i].Item);
            }

            //player add XP
            int lvlDif = Game.Instance.Player.Level - this.Level;

            //player same lvl as enemy
            if (lvlDif == 0 || lvlDif == 1)
                Game.Instance.Player.EntityXP += this.XpDrop;
            //player smaller lvl than enemy and add bonus xp
            else if (lvlDif <= -3)
                Game.Instance.Player.EntityXP += this.XpDrop + ((this.XpDrop / 10) * -lvlDif);
            //player bigger lvl than enemy then remove some xp up to 80%
            else if (lvlDif > 1 && lvlDif <= 5)
                Game.Instance.Player.EntityXP += this.XpDrop - ((this.XpDrop / 16) * lvlDif);

            //player add Gold
            Random rand = new Random();
            //rand num 0.9 || 1.0 || 1.1
            double randomMoneyModifier = rand.Next(9, 12) / 10;

            Game.Instance.Player.Money += (int)(this.GoldDrop * randomMoneyModifier);

            //Update quest journal
            foreach (Quest quest in Game.Instance.ActiveQuests)
                foreach (Objective objective in quest.Objectives)
                    objective.UpdateObjective(this);

            Game.Instance.Player.Target = null;
            Game.Instance.ChangeState(GameStateType.Exploration);
        }
    }
}
