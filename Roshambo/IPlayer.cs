//  though this interface doesnt do much, I'm including it to ensure I get to practice using it
interface IPlayer
{
    int Score { get; }
    MoveChoice MoveChoice { get; set; }
    void EstablishMoveChoice();
}