namespace tahova_RPG_hra.Source.GameObjects
{
    public class GameObject
    {
        private static int nextID = 1;

        private int id;

        public GameObject() => id = nextID++;
    }
}
