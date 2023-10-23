namespace HiddenBattleship.BL.Models
{
    public class GameMoves
    {
        Guid MoveId { get; set; }
        Guid GameId { get; set; }
        Guid PlayerId { get; set; }
        string TargetCoordinates { get; set; }
        bool IsHit { get; set; }
        TimeOnly TimeStamp { get; set; }

    }
}
