using System;
using System.Collections.Generic;

namespace HiddenBattleship.PL;

public partial class tblPlayer
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
