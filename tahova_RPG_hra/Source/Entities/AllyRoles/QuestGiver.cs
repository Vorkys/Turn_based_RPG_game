﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;
using tahova_RPG_hra.Source.GameObjects.Items.ItemTypes;
using tahova_RPG_hra.Source.Quests;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Entities.AllyRoles
{
    class QuestGiver : Ally
    {
        private List<Quest> quests;

        public QuestGiver(string name, string sprite, Item[] inventory, Equippable[] equipment, Entity target, int level, int entityXP, int xPtoLevelUp, int health, int maxHealth, int mana, int maxMana, List<Spell> spells, int damage, int criticalHitChance, int missChance, int armor, int speed, int money, List<Quest> quests) : base(name, sprite, inventory, equipment, target, level, entityXP, xPtoLevelUp, health, maxHealth, mana, maxMana, spells, damage, criticalHitChance, missChance, armor, speed, money)
        {
            this.Quests = quests;
        }

        public List<Quest> Quests { get => quests; set => quests = value; }

        public override void Talk()
        {
            Game.Instance.openDialog(EntryDialog);

            foreach (Quest quest in quests)
                if (quest.isOpen())
                    Game.Instance.AddQuest(quest);

            Console.WriteLine("New quest(s) are added.");
        }
    }
}
