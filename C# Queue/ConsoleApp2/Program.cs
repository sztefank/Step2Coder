using System.Xml.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> warteschlange = new Queue<string>();
            string name;
            int choice;
            bool running = true;

            // ArrayList 
            // List, Stack, Dictionary, Hashtable, (Queue = first in first out)

            while (running)
            {
                Console.WriteLine("1 Um Person zur Queue hinzuzufügen.\n" +
                                  "2 Um Person aus der Queue zu entfernen.\n" +
                                  "3 Um das Programm zu beenden.\n");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Name: ");
                        name = Console.ReadLine();

                        warteschlange.Enqueue(name);
                        
                        foreach (string n in warteschlange)
                        {
                            Console.WriteLine(n);
                        }

                        break;
                    case 2:
                        warteschlange.Dequeue();

                        foreach (string n in warteschlange)
                        {
                            Console.WriteLine(n);
                        }

                        break;
                    case 3:
                        break;
                    default:
                        break;
                }               
            }
        }
    }
}
