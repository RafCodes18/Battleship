using Microsoft.EntityFrameworkCore;

namespace HiddenBattleship.PL;

public partial class HiddenBattleshipEntities : DbContext
{
    public HiddenBattleshipEntities()
    {
    }

    public HiddenBattleshipEntities(DbContextOptions<HiddenBattleshipEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblChatHistory> tblChatHistory { get; set; }

    public virtual DbSet<tblGame> tblGames { get; set; }

    public virtual DbSet<tblGameMove> tblGameMoves { get; set; }

    public virtual DbSet<tblPlayer> tblPlayers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HiddenBattleship.DB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblChatHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblChatH__3214EC07CBD56E82");

            entity.ToTable("tblChatHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblGame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblGame__3214EC07DA24F9C4");

            entity.ToTable("tblGame");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblGameMove>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblGameM__3214EC07B921B560");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TargetCoordinates)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
