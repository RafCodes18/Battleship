namespace HiddenBattleship.PL;

public partial class tblGame
{
    public Guid Id { get; set; }

    public Guid Player1 { get; set; }

    public Guid Player2 { get; set; }

    public Guid WinnerId { get; set; }

    public Guid LoserId { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public int IsOver { get; set; }
    public int GameId { get; set; }
}
