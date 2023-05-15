using System;
using System.Threading;

namespace CLIMathGame
{
    public static class GameEngine
    {
        private static ConsoleTimer _consoleTimer;
        private static ConsoleKeyInfo _lastKeystroke;

        public static void PlayGame(string name, char operand, string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            int score = 0;
            var gameOver = false;

            var random = new Random();

            while (!gameOver)
            {
                _consoleTimer = new ConsoleTimer(1000);

                int firstNumber;
                int secondNumber;

                Console.Clear();
                Console.SetCursorPosition(0, 1);

                if (operand == '/')
                {
                    var ints = Math.GetDivisionNumbers(random);
                    firstNumber = ints[0];
                    secondNumber = ints[1];
                }
                else
                {
                    firstNumber = random.Next(1, 20);
                    secondNumber = random.Next(1, 10);
                }

                Console.WriteLine($"{firstNumber} {operand} {secondNumber}");

                if (!int.TryParse(Console.ReadLine(), out var ans))
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                    return;
                }

                _consoleTimer.Dispose();

                if (ans != Math.GetCorrectAnswer(firstNumber, secondNumber, operand))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over - Wrong Answer!");
                    gameOver = true;
                }
                else
                {
                    score++;
                }

            }

            Helpers.AddtoHistory(name, score, message.Split(" ")[0]);

            Console.ReadLine();
        }

    }
}
