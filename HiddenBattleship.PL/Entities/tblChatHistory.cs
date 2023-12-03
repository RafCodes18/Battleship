namespace HiddenBattleship.PL.Entities;

public partial class tblChatHistory : IEntity
{
    public Guid Id { get; set; }

    public Guid Sender { get; set; }

    public Guid Receiver { get; set; }

    public Guid GameId { get; set; }

    public string Message { get; set; } = null!;

    public TimeSpan Timestamp { get; set; }
    public int ChatHistoryId { get; set; }

    public virtual tblPlayer Player { get; set; }

    public virtual tblGame Game { get; set; }


    public virtual ICollection<tblGame> tblGames { get; } = new List<tblGame>();

    public string SortField { get { return ChatHistoryId.ToString(); } }
}
