namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            double num3;
            double num4;

            Console.WriteLine("Enter your first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(num1 + num2);

            Console.WriteLine("Enter your first number: ");
            num3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your second number: ");
            num4 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(num3 + num4);


            



        }
    }
}
