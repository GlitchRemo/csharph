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
            _view.DisplayBoard();
            _view.AskForInput();
            var move = ReadMove();
            _game.RegisterMove(move);

            if (_game.HasWon())
            {
                _view.DisplayBoard();
                Console.WriteLine(_game.CurrentPlayer().Name + " is the winner");
                return;
            }
            
            _game.SwitchPlayer();
        }
    }

    private static int ReadMove()
    {
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }
}