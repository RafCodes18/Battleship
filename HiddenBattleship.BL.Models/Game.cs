namespace HiddenBattleship.BL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid Player1 { get; set; }
        public Guid Player2 { get; set; }
        public Guid WinnerId { get; set; }
        public Guid LoserId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        //TimeOnly date = TimeOnly.FromDateTime(DateTime.Now);
        public bool IsOver { get; set; }

        // multidimensional array for the gameboard TODO
        //public string[,] GameBoard = { { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" }, { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" } };

        //public List<Ship> Player1Ships { get; set; }
        //public List<Ship> Player2Ships { get; set; }

    }
}
