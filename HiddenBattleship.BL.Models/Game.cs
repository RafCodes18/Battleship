namespace HiddenBattleship.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid Player1 { get; set; }
        public Guid Player2 { get; set; }
        public Guid WinnerId { get; set; }
        public Guid LoserId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        //TimeOnly date = TimeOnly.FromDateTime(DateTime.Now);

        public bool IsOver { get; set; }

    }
}
