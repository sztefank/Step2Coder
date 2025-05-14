namespace ConsoleApp1
{
    public class Undead : GameCharacter
    {
        public Undead()
        {
            name = "Undead";
            health = random.Next(150, 250);
            damage = random.Next(10, 20);
        }

        public Undead(string name, double health, double damage, int id)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.id = id;

        }  
    }
}
