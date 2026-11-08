using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedRPG.Source.Core;
using TurnBasedRPG.Source.Quests;

namespace TurnBasedRPG.Source.Entities.AllyRoles
{
    public class TavernKeeper : Ally
    {
        public TavernKeeper(string name, string spritePath, int money) : base(name, spritePath, money) { }

        public override void Talk()
        {
            Game.Instance.Player.Health = Game.Instance.Player.MaxHealth;
            Game.Instance.Player.Mana = Game.Instance.Player.MaxMana;
        }
    }
}
