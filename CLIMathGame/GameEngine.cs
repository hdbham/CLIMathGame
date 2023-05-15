
using System;
using static CLIMathGame.Helpers;
namespace CLIMathGame
{
	public class GameEngine
	{
        public static void PlayGame(string name, char operand, string message)
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



                Console.WriteLine($"\n{firstNumber} {operand} {secondNumber}\n");

                var result = Console.ReadLine();
                if (!int.TryParse(result, out var ans))
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                    return;
                }



                if (ans == Math.GetCorrectAnswer(firstNumber, secondNumber, operand))
                {

                    score++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Game Over - Wrong Answer!");
                    streak = false;
                }


            } while (streak);

            Helpers.AddtoHistory(name, score, gameType);
            Console.WriteLine($"Congratulations {name}! Your score for {gameType} is {score}");
            Console.ReadLine();
        }
    }
}

