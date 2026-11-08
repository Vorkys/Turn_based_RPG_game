using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Core.GameStates;
using TurnBasedRPG.Source.Entities;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.Utils;
using static TurnBasedRPG.Source.Entities.Enemy;

namespace TurnBasedRPG.Source.Quests.QuestObjectives
{
    class LootObjective : Objective
    {
        private string itemName;
        private int requiredAmount;
        private int currentAmount;

        public LootObjective(string itemName, int requiredAmount)
        {
            this.ItemName = itemName;
            this.RequiredAmount = requiredAmount;
            this.CurrentAmount = 0;
            Description = $"Loot {RequiredAmount} {ItemName}(s).";
        }

        //used for Deserialization
        public LootObjective() { }

        public string ItemName { get => itemName; set => itemName = value; }
        public int RequiredAmount { get => requiredAmount; set => requiredAmount = value; }
        public int CurrentAmount { get => currentAmount; set => currentAmount = value; }

        public override void UpdateObjective(List<Drop> items)
        {
            if (IsCompleted)
                return;

            CombatState castInstanceState = (CombatState)Game.Instance.GameState;

            for (int id = 0; id < items.Count; id++)
            {
                bool dropRoll = Roll.RollDice(items[id].DropChance);

                //IF item dropped and is quest
                if (dropRoll && items[id].Item.Name.ToLower().Contains(ItemName.ToLower()))
                {
                    if (items[id].Item.Quantity <= (RequiredAmount - CurrentAmount))
                    {
                        CurrentAmount += items[id].Item.Quantity;
                        items[id].Item.Quantity = 0;
                    }
                    else
                    {
                        CurrentAmount += (RequiredAmount - CurrentAmount);
                        items[id].Item.Quantity -= (RequiredAmount - CurrentAmount);
                    }

                    castInstanceState.QuestInfoText = "Quest objective updated!";

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
