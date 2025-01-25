using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tahova_RPG_hra.GameObjects
{
    internal class GameObject
    {
        private static int nextID = 1;

        private int id;

        public GameObject() => id = nextID++;
    }
}
