// See https://aka.ms/new-console-template for more information

using tic_tac_toe;

View.ShowWelcomeMessage();

var player1 = new Player(View.GetPlayerName(1), 'X');
var player2 = new Player(View.GetPlayerName(2), 'O');

View.ShowGameLoading();

var game = new Game(player1, player2);
var view = new View(game);

var gameController = new GameController(game, view);
gameController.Start();