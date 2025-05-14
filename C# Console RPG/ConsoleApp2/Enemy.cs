namespace ConsoleApp2
{
    internal class Enemy
    {
        public List<Item> loot_table = new List<Item>()
        {
            new Item("wooden sword", 5, "damage", "sword"),
            new Item("stone sword", 10, "damage", "sword"),
            new Item("iron sword", 15, "damage", "sword"),
            new Item("small potion", 10, "heal", "potion"),
            new Item("medium potion", 25, "heal", "potion"),
            new Item("large potion", 50, "heal", "potion"),
            new Item("giga potion", 100, "heal", "potion"),
            new Item("leather helmet", 1, "armor", "helmet"),
            new Item("leather chestplate", 2, "armor", "chestplate"),
            new Item("leather legplate", 2, "armor", "legplate"),
            new Item("leather boot", 1, "armor", "boot"),
            new Item("gold helmet", 2, "armor", "helmet"),
            new Item("gold chestplate", 3, "armor", "chestplate"),
            new Item("gold legplate", 3, "armor", "legplate"),
            new Item("gold boot", 2, "armor", "boot"),
            new Item("chainmail helmet", 3, "armor", "helmet"),
            new Item("chainmail chestplate", 4, "armor", "chestplate"),
            new Item("chainmail legplate", 4, "armor", "legplate"),
            new Item("chainmail boot", 3, "armor", "boot"),
            new Item("iron helmet", 4, "armor", "helmet"),
            new Item("iron chestplate", 5, "armor", "chestplate"),
            new Item("iron legplate", 5, "armor", "legplate"),
            new Item("iron boot", 4, "armor", "boot"),
        };

        private Random random = new Random();

        public int xp;
        public int gold;
        public int difficulty;

        public double health;
        public double armor;
        public double damage;

        public string name;
      
        public Enemy(Player player)
        {
            difficulty = player.difficulty;

            health = random.Next((10 * difficulty), (20 * difficulty));
            armor = random.Next((2 * difficulty), (5 * difficulty));
            damage = random.Next((3 * difficulty), (7 * difficulty));
            xp = random.Next((5 * difficulty), (15 * difficulty));
            gold = random.Next((10 * difficulty), (20 * difficulty));
            name = "Enemy-" + random.Next(1000);
        }
    }
}