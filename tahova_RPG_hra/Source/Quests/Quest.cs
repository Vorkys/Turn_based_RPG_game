using System.Collections.Generic;
using System.Numerics;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.GameObjects.Items;

namespace TurnBasedRPG.Source.Quests
{
    public enum Status
    {
        Close,
        Open,
        Active,
        Finished
    }

    public class Quest
    {
        public struct Reward
        {
            public Item Item { get; set; }
            public int Quantity { get; set; }

            public Reward(Item item, int quantity)
            {
                Item = item;
                Quantity = quantity;
            }

            //used for deserialization
            public Reward() { }
        }

        private Status status;
        private List<Quest> prerequisities;
        private string name;
        private string description;
        private List<Objective> objectives;
        private List<Reward> rewards;
        private int rewardMoney;

        public Quest(List<Quest> prerequisities, string name, string description, List<Objective> objectives, List<Reward> rewards, int rewardMoney)
        {
            status = Status.Close;
            this.prerequisities = prerequisities;
            this.name = name;
            this.description = description;
            this.objectives = objectives;
            this.rewards = rewards;
            this.rewardMoney = rewardMoney;
        }

        public Quest(Status status, List<Quest> prerequisities, string name, string description, List<Objective> objectives, List<Reward> rewards, int rewardMoney)
        {
            this.status = status;
            this.prerequisities = prerequisities;
            this.name = name;
            this.description = description;
            this.objectives = objectives;
            this.rewards = rewards;
            this.rewardMoney = rewardMoney;
        }

        //used for Deserialization
        public Quest() { }

        public Status Status { get => status; set => status = value; }
        public List<Quest> Prerequisities { get => prerequisities; set => prerequisities = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public List<Objective> Objectives { get => objectives; set => objectives = value; }
        public List<Reward> Rewards { get => rewards; set => rewards = value; }
        public int RewardMoney { get => rewardMoney; set => rewardMoney = value; }

        public void RecalculateOpenStatus()
        {
            if (Status != Status.Close)
                return;

            if (prerequisities == null)
            {
                Status = Status.Open;
                return;
            }

            bool isQuestValid = false;

            //if quest names are same and status isnt Finished then Cant mve status to Open
            foreach (Quest quest in Prerequisities)
                foreach (Quest activeQuest in Game.Instance.ActiveQuests)
                    if (quest.name == activeQuest.name && activeQuest.Status == Status.Finished)
                        isQuestValid = true;

            if (isQuestValid)
                Status = Status.Open;
        }

        public void RecalculateActiveQuestsStatus()
        {
            if (Status == Status.Finished)
                return;

            bool allIsOk = true;

            if (Objectives != null)
                foreach (Objective obj in Objectives)
                    if (!obj.IsCompleted)
                    {
                        allIsOk = false;
                        break;
                    }

            if (allIsOk && AbleToGetRewards())
                GetReward();
        }

        public bool isOpen()
        {
            if (Status == Status.Open)
                return true;
            else
                return false;
        }

        public bool AbleToGetRewards()
        {
            if (rewards == null)
                return true;

            Item[] tmpPlayerInv = [null, null, null, null, null, null, null, null, null, null];
            Game.Instance.Player.Inventory.CopyTo(tmpPlayerInv, 0);

            bool ableToLoot = true;

            //Test if player can take all quest Items
            foreach (Reward rewardItem in rewards)
                if (!Game.Instance.Player.AddItem(rewardItem.Item, rewardItem.Quantity))
                {
                    ableToLoot = false;
                    break;
                }

            //Put Inv back to its original state
            Game.Instance.Player.Inventory = tmpPlayerInv;

            return ableToLoot;
        }

        public void GetReward()
        {
            if (Objectives != null)
                foreach (Objective obj in Objectives)
                    if (!obj.IsCompleted || !AbleToGetRewards())
                        return;

            if (!AbleToGetRewards())
                return;

            Game.Instance.Player.Money += RewardMoney;

            if (rewards != null)
                foreach (Reward item in rewards)
                    Game.Instance.Player.AddItem(item.Item, item.Quantity);

            this.status = Status.Finished;
        }
    }
}
