namespace HiddenBattleship.PL.Entities;

public partial class tblPlayer : IEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual tblGame Game { get; set; }

    public virtual tblGameMove GameMove { get; set; }

    public virtual tblChatHistory ChatHistory { get; set; }



    public string SortField { get { return UserName; } }
}
