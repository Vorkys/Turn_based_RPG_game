using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Core;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Spells;

namespace tahova_RPG_hra.Source.Managers
{
    class EntityManager
    {
        public static Enemy Goblin = new Enemy("Small Goblin", "asda", [], [], Game.Instance.Player, 5, 0, 100, 12, 12, 3, 3, new List<Spell> { }, 4, 2, 2, 1, 4, 27, [], 60, 10);
    }
}
