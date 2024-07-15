// See https://aka.ms/new-console-template for more information

using tic_tac_toe;

var player1 = new Player("Riya", 'X');
var player2 = new Player("Swagato", 'O');

var game = new Game(player1, player2);
var view = new View(game);

var gameController = new GameController(game, view);
gameController.Start();