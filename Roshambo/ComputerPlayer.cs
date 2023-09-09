sealed class ComputerPlayer : Player, IPlayer
{
    Random _random = new Random();
    public ComputerPlayer()
    {
        ID = "ComputerPlayer";
    }

    //  EstablishMoveChoice
    //  This method makes the computer choose an item
    //  Input:  none
    //  Output: none
    public override void EstablishMoveChoice()
    {
        MoveChoice = _random.Next(3) switch
        {
            0 => MoveChoice.Rock,
            1 => MoveChoice.Paper,
            _ => MoveChoice.Scissors
        };
        RecordMoveChoice(MoveChoice);
    }
}


/*
 * 
 */