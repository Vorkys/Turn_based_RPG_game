using System.Collections.Generic;
using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Entities.AllyRoles;
using TurnBasedRPG.Source.GameObjects.Items;
using TurnBasedRPG.Source.GameObjects.Items.ItemTypes;
using TurnBasedRPG.Source.Spells;

namespace TurnBasedRPG.Source.Entities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Merchant), nameof(Merchant))]
    [JsonDerivedType(typeof(ArenaOrganisator), nameof(ArenaOrganisator))]
    [JsonDerivedType(typeof(QuestGiver), nameof(QuestGiver))]
    [JsonDerivedType(typeof(Transporter), nameof(Transporter))]

    public class Ally : Entity
    {
        private List<string> entryDialog;

        public Ally(string name, string spritePath, int money) : base(name, spritePath, money)
        {
            entryDialog = null;
        }

        public List<string> EntryDialog { get => entryDialog; set => entryDialog = value; }

        public virtual void Talk() { }
    }
}
