using System.ComponentModel.DataAnnotations.Schema;

namespace HiddenBattleship.BL.Models
{
    public class ChatHistory
    {
        public Guid Id { get; set; }
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public int ChatHistoryId { get; set; }
    }
}
