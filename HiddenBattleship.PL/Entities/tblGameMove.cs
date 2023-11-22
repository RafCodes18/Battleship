namespace HiddenBattleship.PL.Entities;

public partial class tblGameMove : IEntity
{
    public Guid Id { get; set; }

    public Guid GameId { get; set; }

    public Guid PlayerId { get; set; }

    public string TargetCoordinates { get; set; } = null!;

    public TimeSpan TimeStamp { get; set; }
    public int GameMoveId { get; set; }

    public virtual tblGame Game { get; set; }

    public virtual tblPlayer Player { get; set; }

    public string SortField { get { return GameMoveId.ToString(); } }
}
