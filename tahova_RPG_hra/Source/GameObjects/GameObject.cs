using System.Text.Json.Serialization;
using TurnBasedRPG.Source.GameObjects.Items;

namespace TurnBasedRPG.Source.GameObjects
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Item), nameof(Item))]

    public class GameObject
    {
        private static int nextID = 1;

        private int id;

        public GameObject() => id = nextID++;
    }
}
