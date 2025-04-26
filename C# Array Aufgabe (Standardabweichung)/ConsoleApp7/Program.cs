using System.Xml.Serialization;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen
            int choice;
            int product_amount;
            int i;
            int product_product_amount;
            int[] products = null; // Verstehe ich nicht um ehrlich zu sein aber muss man machen sonst funktioniert das Array nicht (die einzige verwendung von chatgpt)
            int smallest_num;
            int largest_num;
            int product_sum = 0;
            double product_average;
            double[] new_array;
            double final_sum = 0;
            string warnung = "Bitte zuerst produkte hinzufügen";

            Console.WriteLine("Waren Simulator");

            do {

            Console.WriteLine("\n1 Um die Anzahl der verschiedenen Produkte & ihre Menge anzugeben.\n" +
                              "2 Um das am wenigsten vorhandene Produkt anzuzeigen.\n" +
                              "3 Um das am häufigsten vorhandene Produkt anzuzeigen.\n" +
                              "4 Um die Produkte zu sortieren.\n" +
                              "5 Um die Standardabweichung anzuzeigen.\n" +
                              "6 Um das Programm zu beenden.");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                        Console.WriteLine("Wie viele Produkte?: ");
                        product_amount = Convert.ToInt32(Console.ReadLine());

                        products = new int[product_amount]; // Array definieren

                        for (i = 0; i < product_amount; i++)
                        {
                            Console.WriteLine("Wie viel von Produkt" + (i + 1) + "?");
                            product_product_amount = Convert.ToInt32(Console.ReadLine());
                            products[i] = product_product_amount;
                        }

                        break;
                case 2:
                        // Minimalen Wert berechnen

                        if (products != null)
                        {
                            smallest_num = products[0];

                            for (i = 0; i < products.Length; i++)
                            {
                                if (products[i] < smallest_num)
                                {
                                    smallest_num = products[i];

                                }
                            }

                            Console.WriteLine("\nDas am wenigsten vorhandene produkt ist nur: " + smallest_num + " mal vorhanden");
                        }
                        else
                        {
                            Console.WriteLine(warnung);
                        }
                        
                        break;
                case 3:
                        // Maximalen Wert berechnen

                        if (products != null)
                        {
                            largest_num = products[0];

                            for (i = 0; i < products.Length; i++)
                            {
                                if (products[i] > largest_num)
                                {
                                    largest_num = products[i];
                                }
                            }

                            Console.WriteLine("\nDas am häufigsten vorhandene produkt ist: " + largest_num + " mal vorhanden");
                        }
                        else
                        {
                            Console.WriteLine(warnung);
                        }
                        break;
                case 4:
                        // Array sortieren 

                        if (products != null)
                        {
                            Console.WriteLine("\nUnsortierter Array: ");

                            for (i = 0; i < products.Length; i++)
                            {
                                Console.WriteLine(products[i]);
                            }

                            Array.Sort(products);

                            Console.WriteLine("Sortierter Array: ");

                            for (i = 0; i < products.Length; i++)
                            {
                                Console.WriteLine(products[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine(warnung);
                        }

                        break;
                case 5:
                        // Standardabweichung berechnen 

                        if (products != null)
                        {
                            for (i = 0; i < products.Length; i++)
                            {
                                product_sum += products[i]; // Summe aller Array Elemente berechnen
                            }

                            product_average = product_sum / products.Length; // Mittelwert berechnen

                            product_sum = 0; // Variable auf 0 setzen um sie wiederverwenden zu können

                            new_array = new double[products.Length]; // Zweiter Array um die Daten im ersten nicht zu verändern 

                            for (i = 0; i < products.Length; i++)
                            {
                                new_array[i] = products[i]; // Zweiten Array auffüllen mit Elementen

                                new_array[i] -= (product_average); // Von jeder Zahl den Mittelwert subtrahieren

                                final_sum += Math.Pow(new_array[i], 2); // Alle Zahlen quadrieren und anschließend addieren
                            }

                            final_sum /= (products.Length - 1); // Die Summe von den vorherigen rechnungen durch die Anzahl der Elemente - 1 dividieren
                            final_sum = Math.Sqrt(final_sum); // Die Wurzel ziehen

                            Console.WriteLine(final_sum);

                        }
                        else
                        {
                            Console.WriteLine(warnung);
                        }

                    break;
                case 6:
                    break;
            }
            } while (choice != 6);
        }
    }
}
