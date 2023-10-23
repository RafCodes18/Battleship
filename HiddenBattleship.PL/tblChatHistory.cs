using System;
using System.Collections.Generic;

namespace HiddenBattleship.PL;

public partial class tblChatHistory
{
    public Guid Id { get; set; }

    public Guid Sender { get; set; }

    public Guid Receiver { get; set; }

    public Guid GameId { get; set; }

    public string Message { get; set; } = null!;

    public TimeSpan Timestamp { get; set; }
}
