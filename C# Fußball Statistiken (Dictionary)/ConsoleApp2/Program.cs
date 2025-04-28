using System.Collections;

namespace ConsoleApp2
{
    internal class Program
    {
        static string warning = "Bitte geben sie zuerst Spiele an.";
        static int i;
        static int choice;
        static Dictionary<string, int> dict = new Dictionary<string, int>();

        static Dictionary<string, int> datenAngabe()
        {
            int games_amount, scores_amount;

            Console.WriteLine("Wie viele Spiele wollen sie angeben?: \n");
            games_amount = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < games_amount; i++)
            {
                Console.WriteLine("Geben sie die Tore für Spiel" + (i + 1) + " an\n");
                scores_amount = Convert.ToInt32(Console.ReadLine());
                dict["Spiel" + (i + 1)] = scores_amount;
            }

            Console.WriteLine("Spiele mit den toren sind bestimmt.\n");

            return dict;
        }

        static void datenAusgabe(Dictionary<string, int> dict)
        {
            if (dict.Count != 0)
            {
                
                foreach (var element in dict)
                {
                    Console.WriteLine(element.Key + ": " + element.Value);
                }
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void mittelwert(Dictionary<string, int> dict)
        {
            double sum = 0;
            double result;

            if (dict.Count != 0)
            {
                foreach (var element in dict)
                {
                    sum += element.Value;
                }

                result = sum / dict.Count;
                Console.WriteLine("Der Mittelwert bei den vorhandenen " + dict.Count + " spielen liegt bei: " + result);
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static Dictionary<string, int> elementEntfernen(Dictionary<string, int> dict)
        {
            if (dict.Count != 0)
            {
                Console.WriteLine("Welches Spiel möchten sie entfernen?: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (dict.ContainsKey("Spiel" + choice))
                {
                    dict.Remove("Spiel" + choice);
                    Console.WriteLine("Spiel" + choice + " wurde entfernt.");
                }
                else
                {
                    Console.WriteLine("Spiel nicht vorhanden");
                }

                return dict;
            }
            else
            {
                Console.WriteLine(warning);
                return dict;
            }
        }

        static void elementAuslesen(Dictionary<string, int> dict)
        {
            if (dict.Count != 0)
            {
                Console.WriteLine("Welches Spiel möchten sie auslesen?: ");
                choice = Convert.ToInt32(Console.ReadLine());

                foreach (var element in dict)
                {
                    if (element.Key == ("Spiel" + choice))
                    {
                        Console.WriteLine(element.Key + ": " + element.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void minimalerWert(Dictionary<string, int> dict)
        {
            int min_value;

            if (dict.Count != 0)
            {
                min_value = dict["Spiel1"];
                
                foreach (var element in dict)
                {
                    if  (element.Value < min_value)
                    {
                        min_value = element.Value;
                    }
                }

                Console.WriteLine("Das Spiel mit den wenigsten toren ist: " + min_value);

            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void maximalWert(Dictionary<string, int> dict)
        {
            int max_value; 
            string max_value_game = "";

            if (dict.Count != 0)
            {
                max_value = dict["Spiel1"];

                foreach (var element in dict)
                {
                    if (element.Value > max_value )
                    {
                        max_value = element.Value;
                        max_value_game = element.Key;
                    }
                }

                Console.WriteLine("Das Spiel mit den meisten toren ist " + max_value_game + ": " + max_value);

            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void elementErsetzten(Dictionary<string, int> dict)
        {
            string choice2;
            int choice3;

            if (dict.Count != 0)
            {
                Console.WriteLine("Welches Spiel wollen sie ersetzen?: ");
                choice2 = "Spiel" + Console.ReadLine();

                Console.WriteLine("Womit wollen sie die anzahl der Tore von " +  choice2 + " ersetzen:? ");
                choice3 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Die " + dict[choice2] + " Tore von " + choice2 + " wurden auf " + choice3 + " geändert.");

                dict[choice2] = choice3;
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n1 Um Daten anzugeben.\n" +
                                    "2 Um alle Daten auszulesen.\n" +
                                    "3 Um den Mitellwert aller Tore zu berechnen.\n" +
                                    "4 Um ein Spiel zu entfernen.\n" +
                                    "5 Um ein bestimmtes Spiel auszulesen.\n" +
                                    "6 Um das Spiel mit den wenigsten toren auszulesen.\n" +
                                    "7 Um das Spiel mit den meisten toren auszulesen.\n" +
                                    "8 Um die Tore eines Spiels zu ersetzen.\n" +
                                    "9 Um das Programm zu beenden.\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        datenAngabe();
                        break;
                    case 2:
                        datenAusgabe(dict);
                        break;
                    case 3:
                        mittelwert(dict);
                        break;
                    case 4:
                        elementEntfernen(dict);
                        break;
                    case 5:
                        elementAuslesen(dict);
                        break;
                    case 6:
                        minimalerWert(dict);
                        break;
                    case 7:
                        maximalWert(dict);
                        break;
                    case 8:
                        elementErsetzten(dict);
                        break;
                    case 9:
                        Console.WriteLine("Programm wird beendet.\n");
                        break;
                    default:
                        Console.WriteLine("Geben sie bitte eine Valide Zahl ein.\n");
                        break;
                }
            } while (choice != 9);
        }
    }
}