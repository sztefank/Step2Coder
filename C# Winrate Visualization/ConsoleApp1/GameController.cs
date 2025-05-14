using OxyPlot;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public static class GameController
    {
        public static Random random = new Random();

        public static Stack<Undead> zombie_stack = new Stack<Undead>();

        public static Queue<Undead> undeads = new Queue<Undead>();
        public static Queue<Mage> mages = new Queue<Mage>();

        private static int i;

        private static int game_progress = 0;
        private static int round = 0;
        private static int undead_wins = 0;
        private static int mage_wins = 0;

        private static double random_multiplier = random.NextDouble();

        private static string lines = "--------------------------------------------------";
        private static string file_path = Path.GetFullPath("winrate.png");

        public static void startBattle()
        {
            while (undeads.Count != 0 && mages.Count != 0)
            {
                round++;

                Console.WriteLine("Let round " + round + " begin\n");

                Undead undead = undeads.Dequeue();
                Mage mage = mages.Dequeue();

                do
                {
                    if (game_progress % 2 == 0)
                    {
                        Console.WriteLine("The mage attacks and deals: " + (mage.damage * random_multiplier));
                        undead.health -= (mage.damage * random_multiplier);

                        if (undead.health <= 0)
                        {
                            Console.WriteLine(lines + "\nThe undead has died\n");
                            Console.WriteLine("The winner of round " + round + " is the mage\n" + lines + "\n");
                            mage_wins++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The undead has " + undead.health + " health left\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("The undead attacks and deals: " + (undead.damage * random_multiplier));
                        mage.health -= (undead.damage * random_multiplier);

                        if (mage.health <= 0)
                        {
                            Console.WriteLine(lines + "\nThe mage has died\n");
                            Console.WriteLine("The winner of round " + round + " is the undead\n" + lines + "\n");
                            undead_wins++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The mage has " + mage.health + " health left\n");
                        }
                    }

                    game_progress++;

                } while (mage.health > 0 && undead.health > 0);
            }
        }
            
        public static void addUndead(int amount)
        {
            for (i = 0; i < amount; i++)
            {
                Undead undead = new Undead();
                undead.id = i + 1;
                undeads.Enqueue(undead);
            }

            Console.WriteLine(amount + " Zombies added");

        }
        public static void addMage(int amount)
        {
            for (i = 0; i < amount; i++)
            {
                Mage mage = new Mage();
                mage.id = i + 1;
                mages.Enqueue(mage);
            }

            Console.WriteLine(amount + " Mages added");
        }

 
        public static void showWinrate()
        {
            var model = new PlotModel { Title = "Winrate" };
            var pie = new PieSeries();

            pie.Slices.Add(new PieSlice("Mage", mage_wins) { IsExploded = true, Fill = OxyColors.Blue });
            pie.Slices.Add(new PieSlice("Undead", undead_wins) { IsExploded = true, Fill = OxyColors.Red });
            model.Series.Add(pie);

            using (var stream = File.Create("winrate.png"))
            {
                var exporter = new PngExporter { Width = 600, Height = 400};
                exporter.Export(model, stream);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(file_path) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", file_path);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", file_path);
            }

        }
    }
}
