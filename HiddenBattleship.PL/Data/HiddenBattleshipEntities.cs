using HiddenBattleship.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HiddenBattleship.PL;

public partial class HiddenBattleshipEntities : DbContext
{
    Guid[] playerId = new Guid[5];
    Guid[] gameId = new Guid[4];
    Guid[] gamemoveId = new Guid[4];
    Guid[] chathistoryId = new Guid[4];




    public HiddenBattleshipEntities()
    {
    }

    public HiddenBattleshipEntities(DbContextOptions<HiddenBattleshipEntities> options) : base(options)
    {
    }

    public virtual DbSet<tblChatHistory> tblChatHistory { get; set; }

    public virtual DbSet<tblGame> tblGames { get; set; }

    public virtual DbSet<tblGameMove> tblGameMoves { get; set; }

    public virtual DbSet<tblPlayer> tblPlayers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // different connection strings

        // => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HiddenBattleship.DB;Integrated Security=True");
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FO71P55\\MSSQLLOCALDB;Database=HiddenBattleship.DB; Integrated Security=True; TrustServerCertificate=True");

    //remote DB
    //=> optionsBuilder.UseSqlServer("Server=tcp:server-21287-700175134.database.windows.net,1433;Initial Catalog=bigprojectdb;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default'");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        CreatePlayers(modelBuilder);
        CreateGames(modelBuilder);
        CreateGameMoves(modelBuilder);
        CreateChatHistories(modelBuilder);

    }
    private void CreateChatHistories(ModelBuilder modelBuilder)
    {
        for (int i = 0; i < chathistoryId.Length; i++)
            chathistoryId[i] = Guid.NewGuid();


        modelBuilder.Entity<tblChatHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblChatH__3214EC07CBD56E82");

            entity.ToTable("tblChatHistory");

            entity.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedNever();

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblChatHistories)
            .HasForeignKey(p => p.Sender);

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblChatHistories)
            .HasForeignKey(p => p.Receiver);

            // 1 to many relationship with The Game table
            entity.HasOne(p => p.Game)
            .WithMany(g => g.tblChatHistories)
            .HasForeignKey(p => p.GameId);

            entity.Property(e => e.Message)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(g => g.Timestamp)
            .IsRequired();

            entity.Property(g => g.ChatHistoryId)
            .IsRequired();

        });

        List<tblChatHistory> ChatHistories = new List<tblChatHistory>
        {
            new tblChatHistory {Id = chathistoryId[0], Sender = playerId[3], Receiver = playerId[1], GameId = gameId[0], Message ="1v1 me", Timestamp = new TimeSpan(4,10,55), ChatHistoryId = 1 },
            new tblChatHistory {Id = chathistoryId[1], Sender = playerId[1], Receiver = playerId[3], GameId = gameId[0], Message ="You missed, LOL", Timestamp = new TimeSpan(5,1,20), ChatHistoryId = 1 },
            new tblChatHistory {Id = chathistoryId[2], Sender = playerId[1], Receiver = playerId[2], GameId = gameId[1], Message ="Follow my twitch stream?", Timestamp = new TimeSpan(11,51,14), ChatHistoryId = 1 },
            new tblChatHistory {Id = chathistoryId[3], Sender = playerId[2], Receiver = playerId[3], GameId = gameId[2], Message ="You're hacking, i'm telling my dad he works at Jagex!!11!", Timestamp = new TimeSpan(1,28,19), ChatHistoryId = 3 }
        };
        modelBuilder.Entity<tblChatHistory>().HasData(ChatHistories);
    }

    private void CreateGameMoves(ModelBuilder modelBuilder)
    {
        for (int i = 0; i < gamemoveId.Length; i++)
            gamemoveId[i] = Guid.NewGuid();

        modelBuilder.Entity<tblGameMove>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblGameM__3214EC07B921B560");

            entity.ToTable("tblGameMove");

            entity.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedNever();

            // 1 to many relationship with The Game table
            entity.HasOne(g => g.Game)
            .WithMany(g => g.tblGameMoves)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.GameId);

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblGameMoves)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.PlayerId);


            entity.Property(e => e.TargetCoordinates)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(g => g.TimeStamp)
            .IsRequired();

            entity.Property(g => g.IsHit)
            .IsRequired();

            entity.Property(g => g.GameMoveId)
            .IsRequired();
        });

        List<tblGameMove> GameMoves = new List<tblGameMove>
        {
            new tblGameMove {Id = gamemoveId[0], GameId = gameId[0], PlayerId = playerId[0], TargetCoordinates = "A5", TimeStamp = new TimeSpan(1,20,30), GameMoveId = 0, IsHit = true },
            new tblGameMove {Id = gamemoveId[1], GameId = gameId[0], PlayerId = playerId[0], TargetCoordinates = "A5", TimeStamp = new TimeSpan(1,20,30), GameMoveId = 1, IsHit = true },
            new tblGameMove {Id = gamemoveId[2], GameId = gameId[0], PlayerId = playerId[0], TargetCoordinates = "A5", TimeStamp = new TimeSpan(1,20,30), GameMoveId = 2, IsHit = true },
            new tblGameMove {Id = gamemoveId[3], GameId = gameId[0], PlayerId = playerId[0], TargetCoordinates = "A5", TimeStamp = new TimeSpan(1,20,30), GameMoveId = 3, IsHit = true }
        };
        modelBuilder.Entity<tblGameMove>().HasData(GameMoves);
    }

    private void CreateGames(ModelBuilder modelBuilder)
    {
        for (int i = 0; i < gameId.Length; i++)
            gameId[i] = Guid.NewGuid();

        modelBuilder.Entity<tblGame>(entity =>
        {
            entity.HasKey(g => g.Id).HasName("PK__tblGame__3214EC07DA24F9C4");

            entity.ToTable("tblGame");

            entity.Property(g => g.Id)
            .IsRequired()
            .ValueGeneratedNever();

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblGames)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.Player1);

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblGames)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.Player2);

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblGames)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.WinnerId);

            // 1 to many relationship with The Player table
            entity.HasOne(p => p.Player)
            .WithMany(g => g.tblGames)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(p => p.LoserId);

            entity.Property(g => g.StartTime)
            .IsRequired();

            entity.Property(g => g.EndTime)
            .IsRequired();

            entity.Property(g => g.IsOver)
            .IsRequired();

            entity.Property(g => g.GameId)
            .IsRequired();
        });

        List<tblGame> Games = new List<tblGame>
        {
           new tblGame {Id = gameId[0], Player1 = playerId[0], Player2 = playerId[1], WinnerId = playerId[0], LoserId = playerId[1], StartTime = new TimeSpan(1,20,30), EndTime = new TimeSpan(1,20,30), IsOver = true, GameId = 0},
           new tblGame {Id = gameId[1], Player1 = playerId[0], Player2 = playerId[1], WinnerId = playerId[0], LoserId = playerId[1], StartTime = new TimeSpan(1,20,30), EndTime = new TimeSpan(1,20,30), IsOver = false, GameId = 1},
           new tblGame {Id = gameId[2], Player1 = playerId[0], Player2 = playerId[1], WinnerId = playerId[0], LoserId = playerId[1], StartTime = new TimeSpan(1,20,30), EndTime = new TimeSpan(1,20,30), IsOver = false, GameId = 2},
           new tblGame {Id = gameId[3], Player1 = playerId[0], Player2 = playerId[1], WinnerId = playerId[0], LoserId = playerId[1], StartTime = new TimeSpan(1,20,30), EndTime = new TimeSpan(1,20,30), IsOver = false, GameId = 3}
        };
        modelBuilder.Entity<tblGame>().HasData(Games);
    }

    private void CreatePlayers(ModelBuilder modelBuilder)
    {
        for (int i = 0; i < playerId.Length; i++)
            playerId[i] = Guid.NewGuid();


        modelBuilder.Entity<tblPlayer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblPlaye__3214EC0786DA1BDC");

            entity.ToTable("tblPlayer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblPlayer>().HasData(new tblPlayer
        {
            Id = playerId[0],
            Email = "123@gmail.com",
            UserName = "Sh1PD3STR0Y3R",
            Password = GetHash("password")
        });
        modelBuilder.Entity<tblPlayer>().HasData(new tblPlayer
        {
            Id = playerId[1],
            Email = "456@gmail.com",
            UserName = "Timmy",
            Password = GetHash("flash")
        });
        modelBuilder.Entity<tblPlayer>().HasData(new tblPlayer
        {
            Id = playerId[2],
            Email = "789@yahoo.com",
            UserName = "LoveMyCats1155",
            Password = GetHash("sinatra")
        });
        modelBuilder.Entity<tblPlayer>().HasData(new tblPlayer
        {
            Id = playerId[3],
            Email = "aaabbb@amazon.com",
            UserName = "Skeert",
            Password = GetHash("tango")
        });
        modelBuilder.Entity<tblPlayer>().HasData(new tblPlayer
        {
            Id = playerId[4],
            Email = "uTest@yahoo.com",
            UserName = "uTest",
            Password = GetHash("test")
        });

    }

    public static string GetHash(string Password)
    {
        using (var hasher = new System.Security.Cryptography.SHA1Managed())
        {
            var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
        }
    }
}
