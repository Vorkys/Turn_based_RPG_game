using System.Text.Json.Serialization;
using TurnBasedRPG.Source.Core.InputHandlers;

namespace TurnBasedRPG.Source.Core.GameStates
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(MainMenuState), nameof(MainMenuState))]
    [JsonDerivedType(typeof(PauseState), nameof(PauseState))]
    [JsonDerivedType(typeof(ExplorationState), nameof(ExplorationState))]
    [JsonDerivedType(typeof(CombatState), nameof(CombatState))]
    [JsonDerivedType(typeof(DialogState), nameof(DialogState))]
    [JsonDerivedType(typeof(InventoryState), nameof(InventoryState))]
    [JsonDerivedType(typeof(JournalState), nameof(JournalState))]
    [JsonDerivedType(typeof(TownState), nameof(TownState))]
    [JsonDerivedType(typeof(TradingState), nameof(TradingState))]
    public abstract class GameState
    {
        //TODO
        private InputHandler inputHandler;

        public InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }

        public abstract void Render();

        //TODO - after implemented all change "virtual" to "abstract"
        public virtual void Update() { }
    }
}
