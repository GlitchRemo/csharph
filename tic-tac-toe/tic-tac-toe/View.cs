namespace tic_tac_toe;

public class View
{
    private readonly Game _game;

    public View(Game game)
    {
        _game = game;
    }

    public void AskForInput()
    {
        var currentPlayer = _game.CurrentPlayer();
        Console.WriteLine("Enter a number between 1 and 9, mapped to the board cells! ");
        Console.WriteLine(currentPlayer.Name + "'s Turn (" + currentPlayer.Sign + "):");
    }

    public void DisplayBoard()
    {
        var board = _game.GetBoard();
        var rows = Enumerable.Range(0, 3)
            .Select(i => string.Join(" | ", board.Skip(i * 3).Take(3).Select(c => c == '\0' ? ' ' : c)));

        Console.WriteLine(string.Join("\n---------\n", rows));
    }
}