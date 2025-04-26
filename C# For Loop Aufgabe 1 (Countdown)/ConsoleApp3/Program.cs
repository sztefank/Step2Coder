namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            int summe = 100;
            
            for (i = 100; i > -1; i--)
            {
                Console.WriteLine(summe--);
            }
        }
    }
}
