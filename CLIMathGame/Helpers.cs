using System;
namespace CLIMathGame;



	public class Helpers
	{
        public static void AddtoHistory(string name, int gameScore, string gameType)
        {
            Program.games.Add($"{name} - {DateTime.Now} - {gameType}: {gameScore}");
            Console.WriteLine($"Congratulations {name}! Your score for {gameType} is {gameScore}");

    }

    public static void showHistory()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------\n");

            foreach (var game in Program.games)
            {
                Console.WriteLine(game);
            }

            Console.WriteLine("---------------------\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

    
        public static string GetName()
        {
            Console.WriteLine("Please enter your name!");
            var name = Console.ReadLine();
            return name?.Substring(0, 1).ToUpper() + name?.Substring(1, name.Length - 1);
        }
    }

