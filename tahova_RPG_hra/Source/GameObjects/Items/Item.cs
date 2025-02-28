using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items
{
    internal class Item : GameObject
    {
        private Entity owner;
        private string name;
        private string description;
        private int buyPrice;
        private int sellPrice;
        private int quantity;
        private int maxQuantity;

        public Item(Entity owner, string name, string description, int buyPrice, int sellPrice, int quantity, int maxQuantity)
        {
            this.owner = owner;
            this.name = name;
            this.description = description;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.quantity = quantity;
            this.maxQuantity = maxQuantity;
        }

        public Item(Entity owner, string name, string description, int buyPrice, int sellPrice, int maxQuantity)
        {
            this.owner = owner;
            this.name = name;
            this.description = description;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.quantity = 1;
            this.maxQuantity = maxQuantity;
        }

        public Item(string name, string description, int buyPrice, int sellPrice, int quantity, int maxQuantity)
        {
            this.owner = null;
            this.name = name;
            this.description = description;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.quantity = quantity;
            this.maxQuantity = maxQuantity;
        }

        public Item(string name, string description, int buyPrice, int sellPrice, int maxQuantity)
        {
            this.owner = null;
            this.name = name;
            this.description = description;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.quantity = 1;
            this.maxQuantity = maxQuantity;
        }

        public Entity Owner
        {
            get { return owner; }
            set { owner = value; }
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

        //TODO
        public virtual void Use() { }
    }
}
