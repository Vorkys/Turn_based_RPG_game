﻿using System.Collections.Generic;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.GameObjects.Items;

namespace tahova_RPG_hra.Source.Quests
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
        private Status status;
        private List<Quest> prerequisities;
        private string name;
        private string description;
        private List<Objective> objectives;
        private List<Item> rewards;

        public Status Status { get => status; set => status = value; }
        public List<Quest> Prerequisities { get => prerequisities; set => prerequisities = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public List<Objective> Objectives { get => objectives; set => objectives = value; }
        public List<Item> Rewards { get => rewards; set => rewards = value; }

        public void CheckStatus()
        {
            foreach (Quest quest in Prerequisities)
                if (quest.Status != Status.Finished)
                    return;

            this.Status = Status.Open;
        }

        public bool isOpen()
        {
            if (Status == Status.Open)
                return true;
            else
                return false;
        }

        public void GetReward()
        {
            foreach (Objective obj in Objectives)
                if (!obj.IsCompleted)
                    return;

            //TODO - get reward and close quest
            foreach (Item item in rewards)
                Game.Instance.Player.AddItem(item, item.Quantity);

            this.status = Status.Close;
        }
    }
}
