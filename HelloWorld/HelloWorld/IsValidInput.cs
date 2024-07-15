namespace HelloWorld;

public static class IsValidInput
{
    private const string InvalidText = "Invalid";
    private const string ValidText = "Valid";
    private const string DisplayMsg = "Enter a number between 1 to 10!";

    public static void Validate()
    {
        var input = Read.ReadNumber(DisplayMsg);
        Console.WriteLine(input is >= 1 and <= 10 ? ValidText : InvalidText);
    }
}