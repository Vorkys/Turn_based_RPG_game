using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;

namespace tahova_RPG_hra.Source.GameObjects.Items.ItemTypes
{
    public class Equippable : Item
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
            this.Slot = slot;
            this.Strength = strength;
        }

        public EquippableSlot Slot { get => slot; set => slot = value; }
        public int Strength { get => strength; set => strength = value; }

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

        public override bool Use()
        {
            Item tmpItem;

            switch (Slot)
            {
                case EquippableSlot.Helm:
                    ////switch items
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Helm];
                    Owner.Equipment[(int)EquippableSlot.Helm] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Body:
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Body];
                    Owner.Equipment[(int)EquippableSlot.Body] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Legs:
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Legs];
                    Owner.Equipment[(int)EquippableSlot.Legs] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Ring:
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Ring];
                    Owner.Equipment[(int)EquippableSlot.Ring] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Main_Hand:
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Main_Hand];
                    Owner.Equipment[(int)EquippableSlot.Main_Hand] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
                case EquippableSlot.Off_Hand:
                    tmpItem = Game.Instance.Player.Equipment[(int)EquippableSlot.Off_Hand];
                    Owner.Equipment[(int)EquippableSlot.Off_Hand] = this;
                    Game.Instance.Player.RemoveItem(this);
                    Game.Instance.Player.AddItem(tmpItem);
                    break;
            }

            return true;
        }
    }
}
