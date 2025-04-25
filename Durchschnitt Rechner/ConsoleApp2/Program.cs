namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            int runs = 0;
            int mark;
            int sum = 0;
            int i;
            double avg;

            int[] marks = null;
            string[] students = null;

            do
            {
                Console.WriteLine("\nDurchschnitt berechner.\n1 Um die Anzahl der Noten zu bestimmen.\n2 Um Noten hinzuzufügen.\n3 Um den Durchschnitt zu berechnen.\n4 Um das Programm zu beenden.");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Geben sie bitte die anzahl der Noten ein: ");
                        runs = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Die Anzahl der Noten ist nun " + runs);

                        marks = new int[runs];
                        students = new string[runs];

                        break;
                    case 2:
                        if (marks == null)
                        {
                            Console.WriteLine("Bitte geben sie zuerst die Anzahl der Noten ein");
                        }
                        for (i = 0; i < runs; i++)
                        {
                            Console.WriteLine("Geben sie eine Note ein: ");
                            mark = Convert.ToInt32(Console.ReadLine());
                            marks[i] = mark;
                            sum += mark;
                        }
                        break;
                    case 3:
                        avg = sum / runs;
                        Console.WriteLine("Der Durchschnitt liegt bei: " + avg);
                        break;
                    case 4:
                        Console.WriteLine("Programm wird beendet.");
                        break;
                }
            } while (choice != 4);
        }
    }
}
