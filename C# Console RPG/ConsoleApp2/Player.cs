namespace ConsoleApp2
{
    internal class Player
    {
        public Dictionary<int, Item> inventory = new Dictionary<int, Item>();

        public Dictionary<int, Item> equipped_items = new Dictionary<int, Item>(5) 
        {
            { 1, new Item("none", 0, "none", "none") },
            { 2, new Item("none", 0, "none", "none") },
            { 3, new Item("none", 0, "none", "none") },
            { 4, new Item("none", 0, "none", "none") },
            { 5, new Item("none", 0, "none", "none") }
        };

        public int level;
        public int xp;
        public int difficulty;
        public int round;
        public int gold;

        public double max_health;
        public double current_health;
        public double armor;
        public double damage;

        public bool alive;

        public string name;
        public string player_class;
        
        public Player(string name, Tuple<string, double, double, double> class_specifications, int difficulty, double current_health, int round, int level, int xp, int gold, Dictionary<int, Item>? inventory = null, Dictionary<int, Item>? equipped_items = null)
        {
            this.name = name;
            this.player_class = class_specifications.Item1;
            this.max_health = class_specifications.Item2;
            this.armor = class_specifications.Item3;
            this.damage = class_specifications.Item4;
            this.difficulty = difficulty;
            this.current_health = current_health;
            this.round = round;
            this.level = level;
            this.xp = xp;
            this.gold = gold;
            this.inventory = inventory ?? new Dictionary<int, Item>();
            this.equipped_items = equipped_items ?? new Dictionary<int, Item>()
            {
                { 1, new Item("none", 0, "none", "none") },
                { 2, new Item("none", 0, "none", "none") },
                { 3, new Item("none", 0, "none", "none") },
                { 4, new Item("none", 0, "none", "none") },
                { 5, new Item("none", 0, "none", "none") }
            };
            this.alive = true;
        }
        public void levelUp()
        {
            level++;
            xp -= 100;
            Console.WriteLine(name + ", you have leveled up to: " + level + "!");

            max_health += (max_health / 10) * difficulty;
            armor += (armor / 10) * difficulty;
            damage += (damage / 10) * difficulty;
        }
    }
}
