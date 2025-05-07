namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Car car = new Car(); // generierung eines neuen autos (Objekt) (Basis Konstruktor)

            Console.WriteLine("Welche Farbe hat das Auto: ");
            car.color = Console.ReadLine();

            car.broken = false;
            car.baujahr = 2020;

            car.drive(); // methoden aufruf (method call)
            car.stop();*/

            // Initialisieren
            Car kia = new Car("fortnite", 500, 2025);

            Console.WriteLine(kia);
        }
    }
}
