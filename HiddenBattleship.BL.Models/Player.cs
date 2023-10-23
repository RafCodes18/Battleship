namespace HiddenBattleship.BL.Models
{
    public class Player
    {
        Guid Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
