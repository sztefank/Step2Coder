namespace ConsoleApp1
{
    public class GameCharacter
    {
        public Random random = new Random();

        public int id;

        public double health;
        public double damage;

        public string name;

        public GameCharacter()
        {

        }

        public GameCharacter(string name, double health, double damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
}
