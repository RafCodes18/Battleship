namespace HiddenBattleship.PL;

public partial class tblGameMove
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public Guid PlayerId { get; set; }

    public string TargetCoordinates { get; set; } = null!;

    public TimeSpan TimeStamp { get; set; }
    public int GameMoveId { get; set; }
}
