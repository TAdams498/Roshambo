sealed class ComputerPlayer : Player, IPlayer
{
    Random _random = new Random();

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
 * Array to hold past decisions (record how game played out, like chess) (maybe inherited)
 */