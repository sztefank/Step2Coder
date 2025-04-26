namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            int summe = 0;

            for (i = 0; i < 1000; i++)
            {
                if (i % 2 != 0)
                {
                    summe += i;
                }
            }
            Console.WriteLine("Die summe ist: " + summe);
        }
    }
}
