// See https://aka.ms/new-console-template for more information

using HelloWorld;

var divider = new string('=', 40);

Console.WriteLine(divider);
Console.WriteLine("Check if a number is valid");
IsValidInput.Validate();

Console.WriteLine(divider);
Console.WriteLine("Enter numbers to add. 'ok' to stop");
MyMath.Add();

Console.WriteLine(divider);
Console.WriteLine("Guess the lucky number between 1 to 10 in 4 chances");
GuessTheNumber.Play();

Console.WriteLine(divider);
Console.WriteLine("Enter a series of numbers separated by comma like 1,2,3,4");
MyMath.Max();