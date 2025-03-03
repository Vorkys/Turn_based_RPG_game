using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items.ItemTypes
{
    class Equippable : Item
    {
        public enum EquippableSlot
        {
            Helm,
            Body,
            Legs,
            Ring,
            Main_Hand,
            Off_Hand,
        };
        private EquippableSlot slot;
        private int strength;

        public Equippable(string name, string description, int buyPrice, int sellPrice, EquippableSlot slot, int strength) : base(name, description, buyPrice, sellPrice, 1)
        {
            this.slot = slot;
            this.strength = strength;
        }

        public EquippableSlot Slot
        {
            get { return Slot; }
            set { Slot = value; }
        }

        public int Strength
        {
            get { return Strength; }
            set { Strength = value; }
        }

        public void WriteInfo()
        {
            string _slot = "";
            switch (Slot)
            {
                case EquippableSlot.Helm:
                    _slot = "helm";
                    break;
                case EquippableSlot.Body:
                    _slot = "body";
                    break;
                case EquippableSlot.Legs:
                    _slot = "legs";
                    break;
                case EquippableSlot.Ring:
                    _slot = "ring";
                    break;
                case EquippableSlot.Main_Hand:
                    _slot = "main hand";
                    break;
                case EquippableSlot.Off_Hand:
                    _slot = "off hand";
                    break;
            }

            Console.WriteLine($"Name: {Name}\nDescritpion: {Description}\nSlot: {_slot}\nStrength: {Strength}\nPrice buy/sell: {BuyPrice}/{SellPrice}\nQuantity: {Quantity}/{MaxQuantity}");
        }

        //TODO - awaiting implementation of Game
        public override void Use()
        {
            switch (Slot)
            {
                case EquippableSlot.Helm:
                    ////switch items
                    //Item tmpItem = player.Equipment[EquippableSlot.Helm];
                    //Owner.Equipment[EquippableSlot.Helm] = this;
                    //Game.Player.RemoveItem(this);
                    //Game.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Body:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Legs:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Ring:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Main_Hand:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Off_Hand:
                    ////switch items
                    //Item tmpItem = player.Equipment[0];
                    //Game.Player.Equipment[0] = this;
                    //Game.Player.AddItem(tmpItem);
                    break;
            }
        }
    }
}
