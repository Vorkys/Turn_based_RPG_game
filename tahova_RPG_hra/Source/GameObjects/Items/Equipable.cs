using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    class Equipable : Item
    {
        private int equippableSlot;
        private int strength;

        public Equipable(string name, string description, int buyPrice, int sellPrice, int maxQuantity, int equippableSlot, int strength) : base(name, description, buyPrice, sellPrice, maxQuantity)
        {
            this.equippableSlot = equippableSlot;
            this.strength = strength;
        }

        public int EquippableSlot
        {
            get { return EquippableSlot; }
            set { EquippableSlot = value; }
        }

        public int Strength
        {
            get { return Strength; }
            set { Strength = value; }
        }

        public void WriteInfo()
        {
            string slot = "";
            switch (EquippableSlot)
            {
                case -1:
                    slot = "cannot be equiped";
                    break;
                case 0:
                    slot = "helm";
                    break;
                case 1:
                    slot = "body";
                    break;
                case 2:
                    slot = "legs";
                    break;
                case 3:
                    slot = "ring";
                    break;
                case 4:
                    slot = "main hand";
                    break;
                case 5:
                    slot = "off hand";
                    break;
                case 6:
                    slot = "usable in inventory or combat (usable)";
                    break;
            }

            Console.WriteLine($"Name: {Name}\nDescritpion: {Description}\nSlot: {slot}\nStrength: {Strength}\nPrice buy/sell: {BuyPrice}/{SellPrice}\nQuantity: {Quantity}/{MaxQuantity}");
        }

        //TODO - awaiting implementation of Game
        public override void Use(Game game)
        {
            switch (EquippableSlot)
            {
                //Cannot be equipped
                case -1:
                    break;
                case 0:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case 1:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case 2:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case 3:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case 4:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case 5:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
            }
        }
    }
}
