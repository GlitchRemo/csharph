namespace HelloWorld;

public static class MyMath
{
    private static int _sum;

    public static void Add()
    {
        var num = Read.ReadNumber("ok");

        while (num.HasValue)
        {
            _sum += num.Value;
            num = Read.ReadNumber("ok");
        }

        Console.WriteLine("Sum: " + _sum);
    }

    public static void Max()
    {
        var input = Console.ReadLine() ?? string.Empty;
        var numbers = input.Split(",").Select(int.Parse).ToArray();
        Console.WriteLine("Max is " + numbers.Max());
    }
}