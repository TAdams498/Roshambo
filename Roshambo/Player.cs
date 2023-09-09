class Player : IPlayer
{
    public string ID { get; set; }
    public int Score { get; set; }
    public MoveChoice MoveChoice { get; set; }
    public List<MoveChoice> PastChoices { get; }
    public GameManager Manager { get; set; }
    public Player()
    {
        ID = "Player";
        PastChoices = new List<MoveChoice>();
    }

    //  EstablishMoveChoice
    //  This method prompts the player for which item to choose
    //  Input:  none
    //  Output: none
    public virtual void EstablishMoveChoice()
    {
        while (true)
        {
            try
            {
                string typedPlayerChoice = "";
                Console.Write("Rock, Paper, or Scissors: ");
                typedPlayerChoice = Console.ReadLine();
                MoveChoice = typedPlayerChoice.ToLower() switch
                {
                    "rock" => MoveChoice.Rock,
                    "paper" => MoveChoice.Paper,
                    "scissors" => MoveChoice.Scissors,
                    _ => throw new Exception("Player selected invalid option.")
                };
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }
        }
        RecordMoveChoice(MoveChoice);
    }

    //  RecordMoveChoice
    //  This method is to record the move choice into the PastChoices list
    //  Input:  choice  The decision made by the player for this round
    //  Output: none
    public void RecordMoveChoice(MoveChoice choice)
    {
        PastChoices.Add(choice);
        ChoiceChanged?.Invoke(this);
    }

    //  AddToScore
    //  This method is to add to the score when the player wins a round
    //  Input:  none
    //  Output: none
    public void AddToScore()
    {
        Score++;
        ScoreChanged?.Invoke(this);
    }

    //  HandleTurn
    //  Handles actions that define a players single turn
    //  Input:  none
    //  Output: none
    public void HandleTurn()
    {
        ChoiceChanged += Manager.HandleMoveRecording;
        EstablishMoveChoice();
        ChoiceChanged -= Manager.HandleMoveRecording;
    }

    public event Action<Player> ChoiceChanged;
    public event Action<Player> ScoreChanged;
}


/*
 * 
 */

/*QUESTION
 * when initializing a derived class, why would you ever initialize it as the base class?
 * for example, ComputerPlayer is derived from Player
 * what is the benefit of doing it like:
 * Player player = new ComputerPlayer();
 * insted of
 * ComputerPlayer player = new ComputerPlayer();
 * ?
 * 
 * also
 * is the benefit of an abstract over an interface just that the abstract can define things to be inherited
 * where an interface only requires those things and doesnt give any info about what they do or are
 */
