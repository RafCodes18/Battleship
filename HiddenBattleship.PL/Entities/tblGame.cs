namespace HiddenBattleship.PL.Entities;

public partial class tblGame : IEntity
{
    public Guid Id { get; set; }

    public Guid Player1 { get; set; }

    public Guid Player2 { get; set; }

    public Guid WinnerId { get; set; }

    public Guid LoserId { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public bool IsOver { get; set; }
    public int GameId { get; set; }

    public virtual tblPlayer Player { get; set; }

    public virtual ICollection<tblChatHistory> tblChatHistories { get; } = new List<tblChatHistory>();

    public virtual ICollection<tblGameMove> tblGameMoves { get; } = new List<tblGameMove>();

    public string SortField { get { return GameId.ToString(); } }
}
