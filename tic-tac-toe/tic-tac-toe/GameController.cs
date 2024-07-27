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
        var isValid = false;

        while (!isValid)
        {
            _view.DisplayCurrentPlayerName();
                
            _view.DisplayBoard();

            _view.AskForInput();
            var move = ReadMove();

            isValid = _game.RegisterMove(move);

            if (!isValid)
            {
                View.ShowInvalidMessage();
            }
        }
    }

    private static int ReadMove()
    {
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }
}