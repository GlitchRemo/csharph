namespace HelloWorld;

public static class GuessTheNumber
{
    private const string DisplayMsg = "Guess a number";
    private static readonly int Answer = new Random().Next(1, 10);

    public static void Play()
    {
        for (var i = 1; i <= 4; i++)
        {
            var guess = Read.ReadNumber(DisplayMsg);

            if (guess != Answer) continue;

            Console.WriteLine("You Won");
            return;
        }

        Console.WriteLine("You Lost");
    }
}