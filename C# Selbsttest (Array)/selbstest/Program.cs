namespace selbstest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 7 zahlen in einen array einlesen (doubles)
            // switch 1 für einlesen 2 für ausgeben
            // nur die ungeraden elemente ausgeben (index)

            double[] doubles = new double[7];
            int choice;
            double number_to_add;
            int i;

            do
            {
                Console.WriteLine("\n1 Um Zahlen einzulesen.\n" +
                              "2 Um Zahlen auszugeben.\n" +
                              "3 Um das Programm zu beenden.\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        for (i = 0; i < doubles.Length; i++)
                        {
                            Console.WriteLine("Geben sie die Doubles an die in den Array sollen: \n");

                            number_to_add = Convert.ToDouble(Console.ReadLine());

                            doubles[i] = number_to_add;
                            
                        }
                        break;
                    case 2:
                        for (i = 0; i < doubles.Length; i++)
                        {
                            if (doubles[i] % 2 != 0)
                            {
                                Console.WriteLine(doubles[i]);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Programm wird beendet.");
                        break;
                    default:
                        Console.WriteLine("Geben sie bitte eine richtige Zahl ein.");
                        break;
                }
            } while (choice != 3);
        }
    }
}
