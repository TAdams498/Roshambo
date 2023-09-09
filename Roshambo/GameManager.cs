sealed class GameManager
{
    private Player _player;
    private ComputerPlayer _computerPlayer;
    private uint _totalRounds;
    private uint _pointsToWin;
    private Player _winner;
    private List<string> _gameRecording;

    public bool GameOver { get; set; }

    public GameManager(Player player, ComputerPlayer computerPlayer)
    {
        _player = player;
        _computerPlayer = computerPlayer;
        _gameRecording = new List<string>();
        GameOver = false;
    }

    //  HandleMoveRecording
    //  This method is [mostly to practice events and delegates, but actually] to record when moves happen
    //  Input:  none
    //  Output: none
    public void HandleMoveRecording(Player targetedPlayer)
    {
        _gameRecording.Add(targetedPlayer.ID + " has chosen " + targetedPlayer.MoveChoice.ToString());
    }

    //  HandleScoreRecording
    //  This method is [mostly to practice events and delegates, but actually] to record when score changes happen
    //  Input:  none
    //  Output: none
    public void HandleScoreRecording(Player targetedPlayer)
    {
        _gameRecording.Add(targetedPlayer.ID + "'s score is now " + targetedPlayer.Score);
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
        _gameRecording.Add("Game set to best of " + _totalRounds);
        _pointsToWin = (_totalRounds / 2) + 1;
        _gameRecording.Add("Points needed to win: " + _pointsToWin);
        Console.WriteLine("Points needed to win: " + _pointsToWin);
    }

    //  DetermineRoundWinner
    //  This method calculates the outcome of the round based on the decisions of the player and computer
    //  Input:  none
    //  Output: none
    public void DetermineRoundWinner()
    {
        Player winner = default;
        string feedback = "";
        string currentScore = "";
        //  Output about move selections
        Console.WriteLine(_player + " chose " + _player.MoveChoice.ToString());
        Console.WriteLine(_computerPlayer + " chose " + _computerPlayer.MoveChoice.ToString());
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
                        winner = _player;
                    }
                    else
                    {
                        winner = _computerPlayer;
                    }
                    break;
                case MoveChoice.Paper:
                    if (_computerPlayer.MoveChoice == MoveChoice.Rock)
                    {
                        winner = _player;
                    }
                    else
                    {
                        winner = _computerPlayer;
                    }
                    break;
                case MoveChoice.Scissors:
                    if (_computerPlayer.MoveChoice == MoveChoice.Paper)
                    {
                        winner = _player;
                    }
                    else
                    {
                        winner = _computerPlayer;
                    }
                    break;
            }
            //  Distribute points based on winner
            feedback = winner.ID + " wins!";
            winner.AddToScore();
        }
        _gameRecording.Add(feedback);
        Console.WriteLine(feedback);
        currentScore = "Current score is " + _player.Score + " - " + _computerPlayer.Score + "\n";
        _gameRecording.Add(currentScore);
        Console.WriteLine(currentScore);
    }

    //  CheckGameOver
    //  This method checks if the game should continue
    //  Input:  none
    //  Output: none
    public void CheckGameOver()
    {
        string winnerStatement = "";
        if ((_player.Score >= _pointsToWin) || (_computerPlayer.Score >= _pointsToWin))
        {
            if (_player.Score >= _pointsToWin)
            {
                _winner = _player;
            }
            else
            {
                _winner = _computerPlayer;
            }
            winnerStatement = _winner.ID + " won the game!";
            _gameRecording.Add(winnerStatement);
            Console.WriteLine(winnerStatement);
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
        //  set array length to match count of list of recorded lines
        string[] _recordedStrings = new string[_gameRecording.Count];
        //  move strings from List into array to feed to file output
        for (int i = 0; i < _gameRecording.Count; i++)
        {
            _recordedStrings[i] = _gameRecording[i].ToString();
        }
        //  set filename
        string fileName = "gameResults_" + DateTime.Now.ToString("ssmmHHddMMyyyy");
        //  write to file
        File.WriteAllLines("..\\..\\..\\gameResults\\" + fileName + ".txt", _recordedStrings);
    }
}


/*
 * 
 */
