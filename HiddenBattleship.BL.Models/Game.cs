namespace HiddenBattleship.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid Player1 { get; set; }
        public Guid Player2 { get; set; }
        public Guid? WinnerId { get; set; }
        public Guid? LoserId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        //TimeOnly date = TimeOnly.FromDateTime(DateTime.Now);
        public bool IsOver { get; set; }
        
        //public Board Board { get; set; }

       //public List<Ship> Player1Ships { get; set; }
        //public List<Ship> Player2Ships { get; set; }

    }
}
