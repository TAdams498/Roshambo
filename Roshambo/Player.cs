class Player : IPlayer
{
    public int Score { get; set; }
    public MoveChoice MoveChoice { get; set; }
    public List<MoveChoice> PastChoices { get; }

    //  EstablishMoveChoice
    //  This method prompts the player for which item to choose
    //  Input:  none
    //  Output: none
    public virtual void EstablishMoveChoice()
    {
        string typedPlayerChoice = "";
        Console.Write("Rock, Paper, or Scissors: ");
        typedPlayerChoice = Console.ReadLine();
        MoveChoice = typedPlayerChoice.ToLower() switch
        {
            "rock" => MoveChoice.Rock,
            "paper" => MoveChoice.Paper,
            _ => MoveChoice.Scissors
        };
        RecordMoveChoice(MoveChoice);
    }

    //  RecordMoveChoice
    //  This method is to record the move choice into the PastChoices list
    //  Input:  choice  The decision made by the player for this round
    //  Output: none
    public void RecordMoveChoice(MoveChoice choice)
    {
        PastChoices.Add(choice);
    }
}


/*
 * Error handling/Input validation
 * Array to hold past decisions (record how game played out, like chess)
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
 * is the benefit of an abstract over an interface just that the abstract can define things to be inherited, where an interface only requires those things and doesnt give any info about what they do or are
 */
