using Microsoft.VisualBasic;
using System.Collections.Generic;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Quests;
using TurnBasedRPG.Source.Spells;

namespace TurnBasedRPG.Source.Entities.AllyRoles
{
    public class Transporter : Ally
    {
        private string newLocationName;
        private int newX;
        private int newY;
        private int cost;
        private Quest? requiredQuest;

        public Transporter(string name, string spritePath, int money, string newLocationName, int newX, int newY, int cost, Quest requiredQuest) : base(name, spritePath, money)
        {
            this.NewLocationName = newLocationName;
            this.NewX = newX;
            this.NewY = newY;
            this.Cost = cost;
            this.RequiredQuest = requiredQuest;
        }

        public string NewLocationName { get => newLocationName; set => newLocationName = value; }
        public int NewX { get => newX; set => newX = value; }
        public int NewY { get => newY; set => newY = value; }
        public int Cost { get => cost; set => cost = value; }
        public Quest RequiredQuest { get => requiredQuest; set => requiredQuest = value; }

        public override void Talk()
        {
            if (this.Cost <= Game.Instance.Player.Money && RequiredQuest == null || RequiredQuest?.Status == Status.Finished)
            {
                Game.Instance.Player.Money -= Cost;
                Game.Instance.TeleportPlayerToCoordinates(NewX, NewY);
                Game.Instance.ChangeState(GameStateType.Exploration);
            }
        }
    }
}
