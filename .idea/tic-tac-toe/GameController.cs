namespace tic_tac_toe;

public class GameController
{
    private readonly Game _game;
    private readonly View _view;


    public GameController(Game game, View view)
    {
        _game = game;
        _view = view;
    }

    public void Start()
    {
        while (true)
        {
            PlayARound();
            View.ClearScreen();

            if (_game.HasDraw())
            {
                _view.DeclareDraw();
                return;
            }

            if (_game.HasWon())
            {
                _view.DeclareWinner();
                return;
            }

            _game.SwitchPlayer();
        }
    }

    private void PlayARound()
    {
        _view.DisplayCurrentPlayerName();

        _view.DisplayBoard();

        View.AskForInput();
        var move = ReadMove();

        while (!_game.RegisterMove(move))
        {
            View.CellAlreadyOccupied();
            move = ReadMove();
        }
    }

    private static int ReadMove()
    {
        int move;

        while (!IsValidMove(Console.ReadLine(), out move))
        {
            View.InvalidMove();
        }

        return move;
    }

    private static bool IsValidMove(string? input, out int move)
    {
        return int.TryParse(input, out move) && move is > 0 and < 10;
    }
}