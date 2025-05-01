using System.Collections;

namespace ConsoleApp1
{
    internal class Program
    {
        static ArrayList airport = new ArrayList();
        static int i;
        static int choice;
        static string str_choice;
        static string aircraft;
        static string warning = "Bitte fügen sie zuerst flugzeuge hinzu.";
        static bool running = true;

        static void addAircraft()
        {
            Console.WriteLine("Welches Flugzeug wollen sie hinzufügen?: ");
            aircraft = Console.ReadLine();

            airport.Add(aircraft);

            Console.WriteLine(aircraft + " wurde hinzugefügt.\n");
        }

        static void removeAircraft()
        {
            if (airport.Count != 0)
            {
                Console.WriteLine("Welches Flugzeug wollen sie entfernen?: \n");
                aircraft = Console.ReadLine();

                if (airport.Contains(aircraft))
                {
                    airport.Remove(aircraft);
                    Console.WriteLine(aircraft + " wurde entfernt.\n");
                }
                else
                {
                    Console.WriteLine("Dieses Flugzeug ist nicht vorhanden.\n");
                }
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void findAircraft()
        {
            if (airport.Count != 0)
            {
                Console.WriteLine("Geben sie den namen des flugzeuges ein nach dem sie suchen: \n");
                aircraft = Console.ReadLine();

                if (airport.Contains(aircraft))
                {
                    Console.WriteLine(aircraft + " ist vorhanden.\n");
                }
                else
                {
                    Console.WriteLine(aircraft + " ist nicht vorhanden.\n" +
                                                 "Möchten sie es hinzufügen(y/n)?\n");
                    str_choice = Console.ReadLine();

                    airport.Add(aircraft);
                    Console.WriteLine(aircraft + " wurden hinzugefügt.\n");
                }
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void printAllAircrafts()
        {
            if (airport.Count != 0)
            {
                foreach (var n in airport)
                {
                    Console.WriteLine(n);
                }
            }
            else
            {
                Console.WriteLine(warning);
            }
        }

        static void endProgram()
        {
            Console.WriteLine("Programm wird beendet.");
            Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            // Array: statisch & typ 
            // ArrayList dynamisch & kein typ
            // List: dynamisch & typ

            // ziel ist flugzeuge in diesen flughafen hinzuzufügen.

            /*airport.Add("LH123");
            airport.Add("Norwegian333");
            airport.Add("Emirates445");*/

            /*airport.Add(1);
            airport.Add(2);
            airport.Add(3);

            airport.Add(("a", 1));
            airport.Add((2, "b"));*/

            // wenn man komplexere container und collections oder datentypen hat
            // dann ist oft eine foreach schleife praktisch

            // var ist zum automatisch erkennen des typen von n
            /*foreach (var n in airport)
            {
                Console.WriteLine(n);
            }*/

            // gleiche funktionalität nur mit for 
            /*for (i = 0; i < airport.Count; i++)
            {
                Console.WriteLine(airport[i]);
            }*/

            while (running) 
            {
                Console.WriteLine("1 um ein Flugzeug hinzuzufügen.\n" +
                                  "2 um ein Flugzeug zu entfernen.\n" +
                                  "3 um ein Flugzeug zu suchen.\n" +
                                  "4 um alle flugzeuge auszulesen.\n" +
                                  "5 um das Programm zu beenden.");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addAircraft();
                        break;
                    case 2:
                        removeAircraft();
                        break;
                    case 3:
                        findAircraft();
                        break;
                    case 4:
                        printAllAircrafts();
                        break;
                    case 5:
                        endProgram();
                        break;
                }
            } 
        }
    }
}
