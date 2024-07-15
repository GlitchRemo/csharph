namespace tic_tac_toe;

public class Game
{
    private IEnumerable<Player> _players;
    private readonly char[] _board;
    private readonly Dictionary<char, List<int>> _moves;

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

    public void RegisterMove(int move)
    {
        var currentPlayerSign = CurrentPlayer().Sign;
        _board[move - 1] = currentPlayerSign;

        if (!_moves.ContainsKey(currentPlayerSign)) _moves[currentPlayerSign] = new List<int>();
        _moves[currentPlayerSign].Add(move);
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
        var winConditions = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 4, 5, 6 },
            new() { 7, 8, 9 },
            new() { 1, 4, 7 },
            new() { 2, 5, 8 },
            new() { 3, 6, 9 },
            new() { 1, 5, 9 },
            new() { 3, 5, 7 }
        };

        return winConditions.Any(condition => condition.All(move => currentPlayerMoves.Contains(move)));
    }
}