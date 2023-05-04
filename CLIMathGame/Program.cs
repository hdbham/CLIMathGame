using System.Collections.Generic;

internal class Program
{
    private static bool playing = true;
    private static bool outofTime = false;
    private static bool timerFinished = false;

    private static DateTime date = DateTime.UtcNow;
    private static List<string> games = new List<string>();


    private static void Main(string[] args)
    {
        string name = GetName();
        do
        {
            Menu(name);
        } while (playing == true);
    }

    static void Menu(string name)
    {
        var date = DateTime.UtcNow;
        outofTime = false;

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
                PlayGame(name, "+", "Addition game selected");
                break;
            case "s":
                PlayGame(name, "-", "Subtraction game selected");
                break;
            case "m":
                PlayGame(name, "*", "Multiplication game selected");
                break;
            case "d":
                PlayGame(name, "/", "Division game selected");
                break;
            case "h":
                showHistory();
                break;
            case "q":
                Console.WriteLine("Goodbye");
                Environment.Exit(1);
                playing = false;
                break;
            default:
                Console.WriteLine("invalid input");
                Environment.Exit(1);
                break;
        }
    }

    static void PlayGame(string name, string operand, string message)
    {
        Console.WriteLine(message);

        var random = new Random();

        int firstNumber;
        int secondNumber;
        int score = 0;
        var streak = true;

        var words = message.Split(" ");
        string gameType = words[0];

        do
        {
            Console.Clear();
            timerFinished = false;

            if (operand == "/")
            {
                var ints = GetDivisionNumbers(random);
                firstNumber = ints[0];
                secondNumber = ints[1];
            }
            else
            {
                firstNumber = random.Next(1, 20);
                secondNumber = random.Next(1, 10);
            }


            //// Start timer
            //var startTime = DateTime.Now;


            //var timerThread = new Thread(() =>
            //{
            //    while (timer)
            //    {
            //        var timeElapsed = DateTime.Now - startTime;
            //        Console.Write($"\rTime elapsed: {timeElapsed.TotalSeconds:F2} seconds");
            //        Thread.Sleep(5);
                    
            //        if (timeElapsed.TotalSeconds > 30)
            //        {
            //            Console.WriteLine("\nGAME OVER - You took too long to answer! Guess the answer to continue");
            //            outofTime = true;
            //            break;
            //        }
            //    }
            //});

            //timerThread.Start();

            Console.WriteLine($"\n{firstNumber} {operand} {secondNumber}\n");

            var result = Console.ReadLine();
            if (!int.TryParse(result, out var ans))
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.");
                return;
            }

            // Stop timer
            //timer = false; ;

            //var endTime = DateTime.Now;

            if (ans == GetCorrectAnswer(firstNumber, secondNumber, operand))
            {

                //Console.WriteLine($"Your answer was correct! Time taken: {(endTime-startTime).TotalSeconds:F2} seconds\nPress any key to continue");
                score++;
                //Console.ReadLine();
            }
            else
            {
               Console.Clear();
               Console.WriteLine("Game Over - Wrong Answer!");
               streak = false;
            }

            if (outofTime == true) {
                streak = false;
            }


        } while (streak == true);

        AddtoHistory(name, score, gameType);
        Console.WriteLine($"Congratulations {name}! Your score for {gameType} is {score}");
        Console.ReadLine();
    }

    private static void AddtoHistory(string name, int gameScore, string gameType)
    {
        games.Add($"{name} - {DateTime.Now} - {gameType}: {gameScore}");

    }

    static int GetCorrectAnswer(int firstNumber, int secondNumber, string operand)
    {
        switch (operand)
        {
            case "+":
                return firstNumber + secondNumber;
            case "-":
                return firstNumber - secondNumber;
            case "*":
                return firstNumber * secondNumber;
            case "/":
                return firstNumber / secondNumber;
            default:
                throw new ArgumentException($"Invalid game type: {operand}");
        }
    }
  static  void showHistory() {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("---------------------\n");

        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("---------------------\n");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();     
    }

    static int[] GetDivisionNumbers(Random random)
    {
        var firstNumber = random.Next(1, 99);
        var secondNumber = random.Next(1, 99);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        return new int[] { firstNumber, secondNumber };
    }

    static string GetName()
    {
        Console.WriteLine("Please enter your name!");
        var name = Console.ReadLine();
        return name?.Substring(0,1).ToUpper() + name?.Substring(1,name.Length-1);
    }

}