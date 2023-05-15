using System;
namespace CLIMathGame
{
	public class Menu
	{
        public static void ShowMenu(string name)
        {
            var date = DateTime.UtcNow;

            Console.Clear();

            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine($"Hello {name} It's {date.DayOfWeek}. This is your Maths game.\n");
            Console.WriteLine(@$"What game would you like to play today. Choose from the options below:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        Q - Quit the program
        H - Show History");

            Console.WriteLine("__________________________________________________________________________");

            var gameChoice = Console.ReadLine().Trim();

            switch (gameChoice.Trim().ToLower())
            {
                case "a":
                    GameEngine.PlayGame(name, '+', "Addition game selected");
                    break;
                case "s":
                    GameEngine.PlayGame(name, '-', "Subtraction game selected");
                    break;
                case "m":
                    GameEngine.PlayGame(name, '*', "Multiplication game selected");
                    break;
                case "d":
                    GameEngine.PlayGame(name, '/', "Division game selected");
                    break;
                case "h":
                    Helpers.showHistory();
                    break;
                case "n":
                    Console.Clear();
                    name = Helpers.GetName();
                    Menu.ShowMenu(name);
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    Environment.Exit(1);
                    Program.playing = false;
                    break;
                default:
                    Console.WriteLine("invalid input");
                    Environment.Exit(1);
                    break;
            }
        }
    }
}

