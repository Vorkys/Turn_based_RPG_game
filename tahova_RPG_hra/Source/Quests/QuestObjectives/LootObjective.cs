﻿using System.Collections.Generic;
using static tahova_RPG_hra.Source.Entities.Enemy;

namespace tahova_RPG_hra.Source.Quests.QuestObjective
{
    class LootObjective : Objective
    {
        private string itemName;
        private int requiredAmount;
        private int currentAmount;

        public LootObjective(bool isCompleted, string description, string itemName, int requiredAmount, int currentAmount) : base(isCompleted, description)
        {
            this.ItemName = itemName;
            this.RequiredAmount = requiredAmount;
            this.CurrentAmount = currentAmount;
            Description = $"Loot {RequiredAmount} {ItemName}(s).";
        }

        public string ItemName { get => itemName; set => itemName = value; }
        public int RequiredAmount { get => requiredAmount; set => requiredAmount = value; }
        public int CurrentAmount { get => currentAmount; set => currentAmount = value; }

        public override void UpdateObjective(List<Drop> items)
        {
            if (IsCompleted)
                return;

            foreach (Drop item in items)
            {
                if (item.Item.Name.ToLower().Contains(ItemName.ToLower()))
                {
                    if (item.Item.Quantity <= (RequiredAmount - CurrentAmount))
                    {
                        CurrentAmount += item.Item.Quantity;
                        item.Item.Quantity = 0;
                    }
                    else
                    {
                        CurrentAmount += (RequiredAmount - CurrentAmount);
                        item.Item.Quantity -= (RequiredAmount - CurrentAmount);
                    }

                    if (CurrentAmount >= RequiredAmount)
                    {
                        IsCompleted = true;
                        return;
                    }
                }
            }
        }
    }
}
