namespace tic_tac_toe;

public class View
{
    private readonly Game _game;

    public View(Game game)
    {
        _game = game;
    }

    public static void AskForInput()
    {
        PrintCentered("Enter a number between 1 and 9, mapped to the board cells!: ", false);
    }

    public void DisplayBoard()
    {
        var board = _game.GetBoard();
        var rows = Enumerable.Range(0, 3)
            .Select(i => string.Join(" | ", board.Skip(i * 3).Take(3).Select(c => c == '\0' ? ' ' : c))).ToArray();

        PrintCentered("");

        PrintCentered( rows[0]);
        PrintCentered("---------");
        PrintCentered( rows[1]);
        PrintCentered("---------");
        PrintCentered( rows[2]);
        
        PrintCentered("");
    }

    public void DisplayCurrentPlayerName()
    {
        var currentPlayer = _game.CurrentPlayer();
        PrintCentered(currentPlayer.Name + "'s Turn (" + currentPlayer.Sign + "):");
    }

    public void DeclareWinner()
    {
        DisplayBoard();
        PrintCentered(_game.CurrentPlayer().Name + " is the winner!! 🏆🎉🥳 ");
    }

    public void DeclareDraw()
    {
        DisplayBoard();
        PrintCentered("Game is draw!!");
    }

    public static void InvalidMove()
    {
        PrintCentered("Invalid move! Enter a number between 1 to 9. Try again!!: ", false);
    }

    public static void CellAlreadyOccupied()
    {
        PrintCentered("Invalid move! The cell is already occupied. Try again!!: ", false);
    }

    public static void ShowWelcomeMessage()
    {
        PrintCentered("Welcome to Tic-Tac-Toe!!");
        PrintCentered("Let's get started!!");
        PrintCentered("");
    }

    public static string? GetPlayerName(int playerNumber)
    {
        PrintCentered($"Player {playerNumber}, enter your name: ", false);
        return Console.ReadLine();
    }

    public static void ShowGameLoading()
    {
        PrintCentered("Game is Loading \u23f3 \u231b ", false);
        Thread.Sleep(2000);
    }
    
    public static void ClearScreen()
    {
        Console.Clear();
    }
    
    private static void PrintCentered(string text, bool newLine = true)
    {
        var padding = (Console.WindowWidth - text.Length) / 2;

        var format = new string(' ', padding) + text;
        
        if (newLine) Console.WriteLine(format);
        else Console.Write(format);
    }
}