using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Utils;

namespace tahova_RPG_hra.Source.Locations.Nodes
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Node), nameof(Node))]
    [JsonDerivedType(typeof(CombatNode), nameof(CombatNode))]
    [JsonDerivedType(typeof(BossNode), nameof(BossNode))]
    [JsonDerivedType(typeof(DialogNode), nameof(DialogNode))]
    [JsonDerivedType(typeof(DungeonNode), nameof(DungeonNode))]
    [JsonDerivedType(typeof(RewardNode), nameof(RewardNode))]
    [JsonDerivedType(typeof(TownNode), nameof(TownNode))]
    public class Node
    {
        private char nodeChar;
        private string backgroundColor;
        private string foregroundColor;
        private string mapColor;
        private bool isMovable;

        public Node(char nodeChar, string backgroundColor, string foregroundColor, string mapColor, bool isMovable)
        {
            NodeChar = nodeChar;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            MapColor = mapColor;
            IsMovable = isMovable;
        }

        public char NodeChar { get => nodeChar; set => nodeChar = value; }
        public string ForegroundColor { get => foregroundColor; set => foregroundColor = value; }
        public string BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public string MapColor { get => mapColor; set => mapColor = value; }
        public bool IsMovable { get => isMovable; set => isMovable = value; }


        //TODO possible performance upgrade (dont always store default console colors)
        /// <summary>
        /// Print node when player is exploring.
        /// </summary>
        public void Write(bool player = false)
        {
            if (!player)
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), backgroundColor, true);
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), foregroundColor, true);
                Console.Write(nodeChar);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.Write('P');
            }

            Console.ResetColor();
        }

        public virtual void Traverse()
        {
            if (Game.Instance.Player.ImmuneMoves > 0)
                Game.Instance.Player.ImmuneMoves--;
        }
    }
}
