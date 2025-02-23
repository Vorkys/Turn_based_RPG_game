using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    class Consumable : Item
    {
        private bool forPlayer;

        public Consumable(string name, string description, int buyPrice, int sellPrice, int maxQuantity, bool forPlayer) : base(name, description, buyPrice, sellPrice, maxQuantity)
        {
            this.forPlayer = forPlayer;
        }

        public Consumable(string name, string description, int buyPrice, int sellPrice, int quantity, int maxQuantity, bool forPlayer) : base(name, description, buyPrice, sellPrice, quantity, maxQuantity)
        {
            this.forPlayer = forPlayer;
        }

        public override void Use(Game game)
        {
            if (forPlayer)
            {
                switch (Name)
                {
                    case "Small health potion":
                        game.Player.Heal(5);
                        break;
                    case "Medium health potion":
                        game.Player.Heal(15);
                        break;
                    case "Big health potion":
                        game.Player.Heal(25);
                        break;
                }
            }
            else
            {
                switch (Name)
                {
                    case "Molotov":
                        game.Enemy.TakeDamage(5);
                        break;
                    case "Bomb":
                        game.Enemy.TakeDamage(25);
                        break;
                    case "Dynamite":
                        game.Enemy.TakeDamage(50);
                        break;
                }
            }
        }
    }
}
