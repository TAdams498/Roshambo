// Welcome statements
Console.WriteLine("Welcome to the game, it's still a work in progress :)");
Console.WriteLine("Please enjoy");


// Classes
Player player = new Player();
ComputerPlayer computerPlayer = new ComputerPlayer();
GameManager gameManager = new GameManager(player, computerPlayer);
player.Manager = gameManager;
computerPlayer.Manager = gameManager;


// Program
gameManager.EstablishTotalRounds();
do
{
    //  practice for threading here by having computerPlayer turn handled in a separate thread
    Thread computerPlayerTurn = new Thread(computerPlayer.HandleTurn);
    computerPlayerTurn.Start();
    //  player turn
    player.HandleTurn();
    //  end computer player turn
    computerPlayerTurn.Join();
    //  turns over
    gameManager.DetermineRoundWinner();
    player.ScoreChanged += gameManager.HandleMoveRecording;
    computerPlayer.ScoreChanged += gameManager.HandleMoveRecording;
    player.ScoreChanged -= gameManager.HandleMoveRecording;
    computerPlayer.ScoreChanged -= gameManager.HandleMoveRecording;
    gameManager.CheckGameOver();
}
while (!gameManager.GameOver);


/*NOTES
 * Flow:
 * -Player select best of #
 * -Player select rock paper or scissors
 * -Computer makes random selection (can go before or after player)
 * -Display results
 * -Record results into past choices
 * -Loop until Player or Computer wins
 * 
 * Objects:
 * -Player
 * -Computer
 * -Game manager
 * 
 * Todo:
 * -
 */
