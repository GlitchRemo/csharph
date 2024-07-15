namespace HelloWorld;

public static class Read
{
    public static int? ReadNumber(string? eoi = null, string displayMsg = "Enter a number")
    {
        Console.WriteLine(displayMsg);
        var input = Console.ReadLine() ?? string.Empty;

        if (input == eoi) return null;

        try
        {
            var numberedInput = int.Parse(input);
            return numberedInput;
        }
        catch (Exception e)
        {
            Console.WriteLine("Enter a valid Input");
            return ReadNumber(displayMsg);
        }
    }
}