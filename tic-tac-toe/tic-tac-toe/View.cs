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
        Console.WriteLine("Enter a number between 1 and 9, mapped to the board cells! ");
    }

    public void DisplayBoard()
    {
        var board = _game.GetBoard();
        var rows = Enumerable.Range(0, 3)
            .Select(i => string.Join(" | ", board.Skip(i * 3).Take(3).Select(c => c == '\0' ? ' ' : c)));

        Console.WriteLine(string.Join("\n---------\n", rows));
    }

    public void DisplayCurrentPlayerName()
    {
        var currentPlayer = _game.CurrentPlayer();
        Console.WriteLine(currentPlayer.Name + "'s Turn (" + currentPlayer.Sign + "):");
    }

    public void DeclareWinner()
    {
        DisplayBoard();
        Console.WriteLine(_game.CurrentPlayer().Name + " is the winner!!");
    }

    public void DeclareDraw()
    {
        DisplayBoard();
        Console.WriteLine("Game is draw!!");
    }

    public static void InvalidMove()
    {
        Console.WriteLine("Invalid move! Enter a number between 1 to 9. Try again!!");
    }

    public static void CellAlreadyOccupied()
    {
        Console.WriteLine("Invalid move! The cell is already occupied. Try again!!");
    }
}