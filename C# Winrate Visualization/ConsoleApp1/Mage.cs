namespace ConsoleApp1
{
    public class Mage : GameCharacter
    {

        public Mage()
        {
            name = "Mage";
            health = random.Next(50, 100);
            damage = random.Next(25, 50);
        }

        public Mage(string name, double health, double damage, int id) 
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.id = id;
        }
    }
}
