namespace HiddenBattleship.BL.Models
{
    public class GameMoves
    {
        public Guid MoveId { get; set; }
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public string TargetCoordinates { get; set; }
        public bool IsHit { get; set; }
        public TimeOnly TimeStamp { get; set; }

        public string GameMoveId { get; set; }
    }
}
