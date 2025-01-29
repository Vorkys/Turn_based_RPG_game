using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.Source.GameObjects
{
    internal class Item : GameObject
    {
        private string name;
        private string description;
        private int equippableSlot;
        private int strength;
        private int buyPrice;
        private int sellPrice;
        private int quantity;
        private int maxQuantity;

        public Item(string name, string description, int equippableSlot, int strength, int buyPrice, int sellPrice, int quantity, int maxQuantity)
        {
            this.name = name;
            this.description = description;
            this.equippableSlot = equippableSlot;
            this.strength = strength;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.quantity = quantity;
            this.maxQuantity = maxQuantity;
        }

        public Item(string name, string description, int equippableSlot, int strength, int buyPrice, int sellPrice, int maxQuantity)
        {
            this.name = name;
            this.description = description;
            this.equippableSlot = equippableSlot;
            this.strength = strength;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            quantity = 1;
            this.maxQuantity = maxQuantity;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { name = value; }
        }

        public int EquippableSlot
        {
            get { return equippableSlot; }
            set { equippableSlot = value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        public int BuyPrice
        {
            get { return buyPrice; }
            set { buyPrice = value; }
        }

        public int SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int MaxQuantity
        {
            get { return maxQuantity; }
            set { maxQuantity = value; }
        }

        public bool AddQuantity(int amout)
        {
            quantity += amout;
            return true;
        }

        public void WriteInfo()
        {
            string slot = "";
            switch (equippableSlot)
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
            Console.WriteLine($"Name: {name}\nDescritpion: {description}\nSlot: {slot}\nStrength: {strength}\nPrice buy/sell: {buyPrice}/{sellPrice}\nQuantity: {quantity}/{maxQuantity}");
        }

        //TODO
        public void UseItem() { }
    }
}
