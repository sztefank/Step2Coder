using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            int sum = 0;
            int amount;

            Console.WriteLine("Enter the number to start from: ");
            amount = Convert.ToInt32(Console.ReadLine());

            for (i = amount; i > 0; i--)
            {
                sum += amount * i;
            }
            Console.WriteLine(sum);


        }
    }
}
