Console.WriteLine("Please type your name.");

var name = Console.ReadLine();
var date = DateTime.UtcNow;


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

if (gameChoice.Trim().ToLower() == "a") {
    AdditionGame("Addition game selected");
}
if (gameChoice.Trim().ToLower() == "s")
{
    SubtractionGame("Subtraction game selected");
}
if (gameChoice.Trim().ToLower() == "m")
{
    MultiplicationGame("Multiplication game selected");
}
if (gameChoice.Trim().ToLower() == "d")
{
    DivisionGame("Division game selected");
}
if (gameChoice.Trim().ToLower() == "q")
{
    Console.WriteLine("Goodbye");
}
else {
    Console.WriteLine("Invalid input");
}

static void AdditionGame(string message)
{
    Console.WriteLine(message);
}

static void SubtractionGame(string message)
{
    Console.WriteLine(message);
}

static void MultiplicationGame(string message)
{
    Console.WriteLine(message);

}

static void DivisionGame(string message)
{
    Console.WriteLine(message);
}

Console.ReadLine();