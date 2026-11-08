using TurnBasedRPG.Source.Core;

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
