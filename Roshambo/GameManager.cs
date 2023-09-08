sealed class GameManager
{
    private Player _player;
    private ComputerPlayer _computerPlayer;
    private int _totalRounds;
    private int _pointsToWin;

    public bool GameOver { get; set; }

    public GameManager(Player player, ComputerPlayer computerPlayer)
    {
        _player = player;
        _computerPlayer = computerPlayer;
        GameOver = false;
    }

    //  EstablishTotalRounds
    //  This method asks the player the maximum number of rounds (must be an odd number)
    //  Input:  none
    //  Output: none
    public void EstablishTotalRounds()
    {
        string typedBestOfChoice = "";
        do
        {
            Console.Write("Best of (must be an odd number): ");
            typedBestOfChoice = Console.ReadLine();
            _totalRounds = Convert.ToInt32(typedBestOfChoice);
        }
        //  Input validation to ensure given number is odd
        while (_totalRounds % 2 == 0);
        //  Integer division to make rounds needed to win one more than half of total possible rounds
        _pointsToWin = (_totalRounds / 2) + 1;
    }

    //  DetermineRoundWinner
    //  This method calculates the outcome of the round based on the decisions of the player and computer
    //  Input:  none
    //  Output: none
    public void DetermineRoundWinner()
    {
        string feedback = "";
        //  Compare choices from player and computer to determine round winner
        if (_player.MoveChoice == _computerPlayer.MoveChoice)
        {
            feedback = "It's a tie!";
        }
        else
        {
            switch (_player.MoveChoice)
            {
                case MoveChoice.Rock:
                    if (_computerPlayer.MoveChoice == MoveChoice.Scissors)
                    {
                        feedback = "You win!";
                    }
                    else
                    {
                        feedback = "You lose!";
                    }
                    break;
                case MoveChoice.Paper:
                    if (_computerPlayer.MoveChoice == MoveChoice.Rock)
                    {
                        feedback = "You win!";
                    }
                    else
                    {
                        feedback = "You lose!";
                    }
                    break;
                case MoveChoice.Scissors:
                    if (_computerPlayer.MoveChoice == MoveChoice.Paper)
                    {
                        feedback = "You win!";
                    }
                    else
                    {
                        feedback = "You lose!";
                    }
                    break;
            }
        }
        //  Distribute points based on winner
        if (feedback == "You win!")
        {
            _player.Score++;
        }
        else if (feedback == "You lose!")
        {
            _computerPlayer.Score++;
        }
        Console.WriteLine(feedback);
        Console.WriteLine("Current score is " + _player.Score + " - " + _computerPlayer.Score + "\n");
    }

    //  CheckGameOver
    //  This method checks if the game should continue
    //  Input:  none
    //  Output: none
    public void CheckGameOver()
    {
        if ((_player.Score >= _pointsToWin) || (_computerPlayer.Score >= _pointsToWin))
        {
            GameOver = true;
        }
    }
}


/*
 * Error handling/Input validation
 */
