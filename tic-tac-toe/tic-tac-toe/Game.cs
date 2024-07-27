namespace tic_tac_toe;

public class Game
{
    private IEnumerable<Player> _players;
    private readonly char[] _board;
    private readonly Dictionary<char, List<int>> _moves;
    private readonly List<List<int>> _winConditions = new()
    {
        new List<int> { 1, 2, 3 },
        new List<int> { 4, 5, 6 },
        new List<int> { 7, 8, 9 },
        new List<int> { 1, 4, 7 },
        new List<int> { 2, 5, 8 },
        new List<int> { 3, 6, 9 },
        new List<int> { 1, 5, 9 },
        new List<int> { 3, 5, 7 }
    };

    public Game(Player player1, Player player2)
    {
        _board = new char[9];
        _players = new[] { player1, player2 };
        _moves = new Dictionary<char, List<int>>();
    }

    public void SwitchPlayer()
    {
        _players = _players.Reverse();
    }

    public bool RegisterMove(int move)
    {
        if(_board[move - 1] != default(char)) return false;
        
        var currentPlayerSign = CurrentPlayer().Sign;
        _board[move - 1] = currentPlayerSign;

        if (!_moves.ContainsKey(currentPlayerSign)) _moves[currentPlayerSign] = new List<int>();
        _moves[currentPlayerSign].Add(move);
        return true;
    }

    public char[] GetBoard()
    {
        return _board;
    }

    public Player CurrentPlayer()
    {
        return _players.First();
    }

    public bool HasWon()
    {
        if (!_moves.ContainsKey(CurrentPlayer().Sign)) return false;

        var currentPlayerMoves = _moves[CurrentPlayer().Sign];
        
        return _winConditions.Any(condition => condition.All(move => currentPlayerMoves.Contains(move)));
    }

    public bool HasDraw()
    {
        return _board.All(move => move != default);
    }
}