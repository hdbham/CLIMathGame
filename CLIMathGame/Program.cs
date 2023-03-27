using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string name = GetName();

        Menu(name);
    }

    static void Menu(string name)
    {
        var date = DateTime.UtcNow;

        Console.Clear();

        Console.WriteLine("__________________________________________________________________________");
        Console.WriteLine($"Hello {name.ToUpper()} It's {date.DayOfWeek}. This is your math's game.\n");
        Console.WriteLine(@$"What game would you like to play today. Choose from the options below:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        Q - Quit the program");
        Console.WriteLine("__________________________________________________________________________");

        var gameChoice = Console.ReadLine();

        switch (gameChoice.Trim().ToLower())
        {
            case "a":
                PlayGame("+", "Addition game selected");
                break;
            case "s":
                PlayGame("-", "Subtraction game selected");
                break;
            case "m":
                PlayGame("*", "Multiplication game selected");
                break;
            case "d":
                PlayGame("/", "Division game selected");
                break;
            case "q":
                Console.WriteLine("Goodbye");
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("invalid input");
                Environment.Exit(1);
                break;
        }
    }

    static void PlayGame(string gameType, string message)
    {
        Console.WriteLine(message);

        var random = new Random();

        int firstNumber;
        int secondNumber;
        int score = 0;
        var incorrect = false;

        do
        {
            Console.Clear();

            if (gameType == "/")
            {
                var ints = GetDivisionNumbers(random);
                firstNumber = ints[0];
                secondNumber = ints[1];
            }
            else
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
            }


            Console.WriteLine($"{firstNumber} {gameType} {secondNumber}");
            var result = Console.ReadLine();

            if (int.Parse(result) != GetCorrectAnswer(firstNumber, secondNumber, gameType))
            {
                Console.WriteLine("Game Over");
                incorrect = true;
            }
            else
            {
                Console.WriteLine("Your answer was correct!");
                score++;
            }
        } while (incorrect == false);
        Console.Clear();
        Console.WriteLine($"your score is {score}");
    }

    static int GetCorrectAnswer(int firstNumber, int secondNumber, string gameType)
    {
        switch (gameType)
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
                throw new ArgumentException($"Invalid game type: {gameType}");
        }
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
        return name;
    }

}