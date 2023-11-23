namespace HiddenBattleship.PL.Entities;

public partial class tblPlayer : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;


    public virtual ICollection<tblGame> tblGames { get; } = new List<tblGame>();
    public virtual ICollection<tblChatHistory> tblChatHistory { get; } = new List<tblChatHistory>();

    public virtual ICollection<tblGameMove> tblGameMoves { get; } = new List<tblGameMove>();



    public string SortField { get { return UserName; } }
}
