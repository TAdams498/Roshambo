// Welcome statements
Console.WriteLine("Welcome to the game, it's still a work in progress :)");
Console.WriteLine("Please enjoy");


// Declarations
Player player = new Player();
ComputerPlayer computerPlayer = new ComputerPlayer();
GameManager gameManager = new GameManager(player, computerPlayer);


// Program
gameManager.EstablishTotalRounds();
do
{
    player.EstablishMoveChoice();
    Console.WriteLine("You chose " + player.MoveChoice.ToString());
    computerPlayer.EstablishMoveChoice();
    Console.WriteLine("Computer chose " + computerPlayer.MoveChoice.ToString());
    gameManager.DetermineRoundWinner();
    gameManager.CheckGameOver();
}
while (!gameManager.GameOver);


// Enums
public enum MoveChoice { Rock, Paper, Scissors };


/*
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
 * -Error handling/Input validation
 * -Array to hold past decisions (record how game played out, like chess)
 * -Final winner acknowledgement
 */
