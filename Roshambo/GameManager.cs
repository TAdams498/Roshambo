sealed class GameManager
{
    private Player _player;
    private ComputerPlayer _computerPlayer;
    private uint _totalRounds;
    private uint _pointsToWin;
    private Player _winner;
    private string[] _gameRecording;

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
        while(true)
        {
            try
            {
                Console.Write("Best of (must be an odd number): ");
                typedBestOfChoice = Console.ReadLine();
                _totalRounds = Convert.ToUInt32(typedBestOfChoice);
                if (_totalRounds % 2 == 0)
                {
                    Console.WriteLine("Must be an odd number.");
                    continue;
                }
                break;
            }
            catch (OverflowException)
            {
                if (typedBestOfChoice.Contains("-"))
                {
                    Console.WriteLine("Must be a positive number.");
                }
                else
                {
                    Console.WriteLine("Number too large.");
                }
                continue;
            }
            catch (Exception)
            {
                Console.WriteLine("Must be a number.");
                continue;
            }
        }    
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
            if (_player.Score >= _pointsToWin)
            {
                Console.WriteLine("You've won the game!");
                _winner = _player;
            }
            else
            {
                Console.WriteLine("You've lost the game!");
                _winner = _computerPlayer;
            }
            GameOver = true;
            RecordGame();
        }
    }

    //  RecordGame
    //  This method records the decisions of each round in a game
    //  Input:  none
    //  Output: none
    public void RecordGame()
    {
        //  set array length to match number of rounds played+1 to accommodate for line stating winner
        _gameRecording = new string[_winner.PastChoices.Count+1];
        _gameRecording[0] = "Winner is " + _winner.ID;
        //  populate array with lines of text to place into output file
        for (int i = 0;  i < _winner.PastChoices.Count; i++)
        {
            _gameRecording[i+1] = "P:" + _player.PastChoices[i].ToString() + " C:" + _computerPlayer.PastChoices[i].ToString();
        }
        //  set filename
        string fileName = "gameResults_" + DateTime.Now.ToString("ssmmHHddMMyyyy");
        //  write to file
        File.WriteAllLines("..\\..\\..\\gameResults\\" + fileName + ".txt", _gameRecording);
    }
}


/*
 * 
 */
