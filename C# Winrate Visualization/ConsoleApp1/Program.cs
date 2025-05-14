namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController.addUndead(100);
            GameController.addMage(100);
            GameController.startBattle();
            GameController.showWinrate();
        }
    }
}
