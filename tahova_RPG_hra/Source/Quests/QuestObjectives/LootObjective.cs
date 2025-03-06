using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.GameObjects.Items;

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

        public override void UpdateObjective(List<Item> items)
        {
            if (IsCompleted)
                return;

            foreach (Item item in items)
            {
                if (item.Name.ToLower().Contains(ItemName.ToLower()))
                {
                    if (item.Quantity <= (RequiredAmount - CurrentAmount))
                    {
                        CurrentAmount += item.Quantity;
                        item.Quantity = 0;
                    }
                    else
                    {
                        CurrentAmount += (RequiredAmount - CurrentAmount);
                        item.Quantity -= (RequiredAmount - CurrentAmount);
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
