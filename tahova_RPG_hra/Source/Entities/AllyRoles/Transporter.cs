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
        private int newX;
        private int newY;
        private int cost;
        private Quest? requiredQuest;

        public Transporter(string name, string spritePath, int money, int newX, int newY, int cost, Quest requiredQuest) : base(name, spritePath, money)
        {
            this.newX = newX;
            this.newY = newY;
            this.cost = cost;
            this.requiredQuest = requiredQuest;
        }

        public override void Talk()
        {
            if (this.cost <= Game.Instance.Player.Money && requiredQuest.Status == Status.Finished || requiredQuest == null)
            {
                Game.Instance.Player.Money -= cost;
                Game.Instance.TeleportPlayerToCoordinates(newX, newY);
            }
        }
    }
}
