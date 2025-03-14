using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tahova_RPG_hra.Source.Entities;
using tahova_RPG_hra.Source.Locations.Nodes;

namespace tahova_RPG_hra.Source.Managers
{
    class NodeManager
    {
        public Node Grass = new Node(' ', "Green", "Green", "Green", true);
        public CombatNode CombatGrass = new CombatNode(' ', "Green", "Green", "Green", true, 25, 2, 10, new List<Enemy> { EntityManager.Goblin });
        public Node GrassWithPebles = new Node('.', "Green", "Grey", "Green", true);
        public Node Water = new Node('~', "Blue", "DarkBlue", "Blue", false);
        public Node Town1 = new Node('M', "Green", "Pink", "Pink", true);
    }
}
