namespace ConsoleApp1
{
    internal class Program
    {
        // 1. Art void Funktion ohne Parameter und ohne Rückgabewert
        static void summieren() // funktionen klein schreiben - function body - functions definition
        {
            double a, b; // diese variablen sind nur in dieser funktion sichtbar (lokal)

            Console.WriteLine("Geben die zwei Zahlen ein die summiert werden sollen."); // hier sind die aufgaben der funktion

            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Die Summe lautet: " + (a + b)); 
        }

        static void print(string a)
        {
            Console.WriteLine(a);
        }

        static void sayHiTo()
        {
            string name;

            Console.WriteLine("Wie heißt du? ");

            name = Console.ReadLine();

            Console.WriteLine("Hi " +  name);
        }

        static void arthurFragen()
        {
            int amount, i;

            Console.WriteLine("Wie viele fragen hast du: ");

            amount = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < amount; i++)
            {
                print("Arthur ich hab eine frage");
            }

        }

        // 2. Art void Funktion mit Parameter
        static void addieren(int a, int b) // In dieser Funktion sind a und b die Parameter 
        {
            int sum;

            sum = a + b;

            Console.WriteLine("Die summe der Addition ergibt: " + sum);
        }

        // 3. Art Funktion mit Return/rückgabewert und Parameter
        static int addierenMitReturn(int a, int b)
        {
            int sum;

            sum = a + b;

            return sum;
        }
        static int[] arrayErstellen()
        {
            int length, number, i;

            Console.WriteLine("Wie groß soll das Array sein?: ");

            length = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[length];

            for (i = 0; i < length; i++)
            {
                Console.WriteLine("Geben sie Zahl" + (i + 1) + " an: ");

                number = Convert.ToInt32(Console.ReadLine());

                numbers[i] = number;
            }

            Console.WriteLine("\nIhr Array ist fertig.");

            return numbers;

        }
        static double mittelwertBerechnen(int[] arr)
        {
            double avg = 0;
            int i;

            for (i = 0; i < arr.Length; i++)
            {
                avg += arr[i];
            }

            avg /= arr.Length;

            return avg;
        }

        // 4. Art ohne Parameter mit Rückgabewert
        static int addieren_3()
        {
            int num1, num2, sum;

            Console.WriteLine("Geben sie beide Zahlen nacheinander ein: ");

            num1 = Convert.ToInt32(Console.ReadLine());
            num2 = Convert.ToInt32(Console.ReadLine());

            sum = num1 + num2;

            return sum;
        }

        static void Main(string[] args) // Haupt funktion / main function
        {
            //int a, b, sum;

            //Console.WriteLine("Hello World"); // Funktionsaufruf.. function call - to call a function
            //summieren(); // function call 
            //print("fort");
            //sayHiTo();
            //arthurFragen();

            //Console.WriteLine("Geben die zwei Zahlen ein die summiert werden sollen."); // hier sind die aufgaben der funktion

            //a = Convert.ToInt32(Console.ReadLine());
            //b = Convert.ToInt32(Console.ReadLine());

            //addieren(a, b); // Function call benötigt keine datentypen aber die Parameter falls welche in der Function vorhanden sind.

            //sum = addierenMitReturn(a, b);
            //Console.WriteLine("Das Ergebnis lautet: " + sum);

            //sum = addieren_3();
            //Console.WriteLine("Die summe ist: " + sum);

            int[] fertiger_array = arrayErstellen(); ;

            double mittelwert_print = mittelwertBerechnen(fertiger_array);

            Console.WriteLine("\nDer Mittelwert liegt bei: " + mittelwert_print);

        }
    }
}
