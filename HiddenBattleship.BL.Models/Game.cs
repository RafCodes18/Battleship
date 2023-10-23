namespace HiddenBattleship.BL.Models
{
    public class Game
    {
        Guid Id { get; set; }
        Guid Player1 { get; set; }
        Guid Player2 { get; set; }
        Guid WinnerId { get; set; }
        Guid LoserId { get; set; }
        TimeOnly StartTime { get; set; }
        TimeOnly EndTime { get; set; }
        //TimeOnly date = TimeOnly.FromDateTime(DateTime.Now);

    }
}
