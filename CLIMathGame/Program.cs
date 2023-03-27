using static System.Formats.Asn1.AsnWriter;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string name = GetName();

        Menu(name);

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
            Console.Clear();

            switch (gameChoice.Trim().ToLower())
            {
                case "a":
                    AdditionGame("Addition game selected");
                    break;
                case "s":
                    SubtractionGame("Subtraction game selected");
                    break;
                case "m":
                    MultiplicationGame("Multiplication game selected");
                    break;
                case "d":
                    DivisionGame("Division game selected");
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

        string GetName()
        {
            Console.WriteLine("Please type your name.");
            var name = Console.ReadLine();
            return name;
        }

        static void AdditionGame(string message)
            {
                Console.WriteLine(message);
                var random = new Random();

                int firstNumber;
                int secondNumber;
                int score = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();    
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);

                    Console.WriteLine($"{firstNumber} + {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) != firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadLine();
                    }
                else
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                }
                Console.WriteLine($"your score is {score}");
        }

        static void SubtractionGame(string message)
        {
            {
                Console.WriteLine(message);
                var random = new Random();

                int firstNumber;
                int secondNumber;
                int score = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);

                    Console.WriteLine($"{firstNumber} - {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) != firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                }
                Console.WriteLine($"your score is {score}");
            }
        }

        static void MultiplicationGame(string message)
        {
            {
                Console.WriteLine(message);
                var random = new Random();

                int firstNumber;
                int secondNumber;
                int score = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);

                    Console.WriteLine($"{firstNumber} * {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) != firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                }
                Console.WriteLine($"your score is {score}");
            }
        }

        static void DivisionGame(string message)
        {
            {
                Console.WriteLine(message);

                int score = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    int[] ints = GetDivisionNumbers();
                    int firstNumber = ints[0];
                    int secondNumber = ints[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    var result = Console.ReadLine();

                    if (int.Parse(result) != firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                }

                Console.WriteLine($"your score is {score}");
            }
        }

        static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);

            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }
    }
}