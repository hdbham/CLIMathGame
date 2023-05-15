using System.Collections.Generic;
namespace CLIMathGame;

internal class Program
{
    public static bool playing = true;
    private static bool outofTime = false;
    private static bool timerFinished = false;

    private static DateTime date = DateTime.UtcNow;
    public static List<string> games = new List<string>();
    private static string name = "user";


    private static void Main(string[] args)
    {
        name = Helpers.GetName();
        do
        {
            Menu.ShowMenu(name);
        } while (playing == true);
    }

}