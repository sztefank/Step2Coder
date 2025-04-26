using System.Xml.Serialization;

namespace ConsoleApp9
{
    internal class Program
    {
        // static 
        // const sind konstante variablen die man nicht verändern kann
        // Globale variablen hier hin

        static Dictionary<string, int> name_mark = new Dictionary<string, int>();

        static void Main(string[] args) // start methode - lokal sichtbar (global)
        {
            // deklarationen & definitionen
            int students_amount = 0; 
            string student_name;
            int student_mark;
            int i;
            int choice;
            string warning = "\nBitte geben sie zuerst Studenten an.";
            string check_person;
            int counter = 1;

            do
            {
                Console.WriteLine("\n1 Um den Namen & die Note eines Studenten anzugeben.\n" +
                                  "2 Um einen Studenten & seine Note auszulesen.\n" +
                                  "3 Um alle Studenten & ihre Noten auszulesen.\n" +
                                  "4 Um einen Studenten zu entfernen.\n" +
                                  "5 Um den Wert an einer bestimmten Stelle anzuzeigen.\n" +
                                  "6 Um das Programm zu beenden.\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Geben sie den zuerst den Namen an und dann die Note");

                        student_name = Console.ReadLine();
                        student_mark = Convert.ToInt32(Console.ReadLine());

                        if (student_mark > 0 || student_mark < 6) 
                        {
                            name_mark.Add(student_name, student_mark);
                            Console.WriteLine("\nDer Student " +  student_name + " mit der Note " + student_mark + " wurde hinzugefügt");
                        }
                        else 
                        {
                            Console.WriteLine("Bitte geben sie eine gültige Note ein.");
                        }

                        break;
                    case 2:
                        if (name_mark.Count != 0)
                        {
                            Console.WriteLine("Geben sie den namen des Studenten ein: ");
                            check_person = (Console.ReadLine());

                            foreach (var element in name_mark)
                            {
                                if (element.Key == check_person)
                                {
                                    Console.WriteLine("\n" + element.Key + " " + element.Value);
                                }
                            }
                        }
                        else
                        {
                           Console.WriteLine(warning);
                        }
                        break;
                    case 3:
                        if (name_mark.Count != 0)
                        {
                            foreach (var element in name_mark)
                            {
                                Console.WriteLine("\n" + element.Key + " " + element.Value);
                            }
                        }
                        else
                        {
                            Console.WriteLine(warning);
                        }
                        break;
                    case 4:
                        if (name_mark.Count != 0)
                        {
                            Console.WriteLine("Geben sie den Namen des Studenten ein der gelöscht werden soll: ");
                            check_person = Console.ReadLine();

                            foreach (var element in name_mark)
                            {
                                if (element.Key == check_person)
                                {
                                    name_mark.Remove(element.Key);
                                    Console.WriteLine("Der Student " + check_person + " wurde entfernt.");
                                    break;
                                }
                                else 
                                {
                                    Console.WriteLine("Dieser Student ist nicht vorhanden.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(warning);
                        }
                        break;
                    case 5:
                        if (name_mark.Count != 0)
                        {
                            Console.WriteLine("Geben sie die Stelle ein: ");
                            choice = Convert.ToInt32(Console.ReadLine());

                            foreach (var element in name_mark)
                            {
                                if (counter == choice)
                                {
                                    Console.WriteLine(element.Key + " " + element.Value);
                                    break;
                                }
                                counter += 1;
                            }
                            counter = 1;
                        }
                        else
                        {
                            Console.WriteLine(warning);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Programm wird beendet.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Bitte geben sie eine richtige Zahl ein.");
                        break;

                }

                // student_names[0] die erste position und die ist ein string
                // student_names[1] die zweite position usw.
                // student_names[student_amount - 1] die letzte position
                // wenn 5 studenten im array sind existiert student_names[5] nicht! (error: array out of bounds)

                // for schleife und arrays hängen zusammen
                // 1. teil von der for schleife: wo fange ich an
                // 2. teil der for scheleife: wie lange soll ich zählen / bis wohin soll ich zählen
                // 3. teil der for schleife: wie schnell zähle ich (i++, i--) - schritte in der for schleife ausmachen
                // WPF oder C++ anschauen
                // die gleiche app in WPF

                // 1 einlesen von einem array

                // methoden in c# die vordefiniert sind sind gross geschrieben
                // jede methode sollte man klein schreiben

                // sortieren, suchen, löschen oder wert auslesen

                // 2 ausgeben von einem array

            } while (choice != 6);
            
        }
    }
}
