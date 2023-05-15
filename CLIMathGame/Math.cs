using System;
namespace CLIMathGame
{
	public class Math
	{
        public static int GetCorrectAnswer(int firstNumber, int secondNumber, char operand)
        {
            switch (operand)
            {
                case '+':
                    return firstNumber + secondNumber;
                case '-':
                    return firstNumber - secondNumber;
                case '*':
                    return firstNumber * secondNumber;
                case '/':
                    return firstNumber / secondNumber;
                default:
                    throw new ArgumentException($"Invalid game type: {operand}");
            }
        }

        public static int[] GetDivisionNumbers(Random random)
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

    }
}

