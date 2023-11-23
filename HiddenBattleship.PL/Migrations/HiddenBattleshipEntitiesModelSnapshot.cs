﻿// <auto-generated />
using System;
using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HiddenBattleship.PL.Migrations
{
    [DbContext(typeof(HiddenBattleshipEntities))]
    partial class HiddenBattleshipEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblChatHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ChatHistoryId")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("Receiver")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Sender")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Timestamp")
                        .HasColumnType("time");

                    b.HasKey("Id")
                        .HasName("PK__tblChatH__3214EC07CBD56E82");

                    b.HasIndex("Receiver");

                    b.ToTable("tblChatHistory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f55d0d8f-ce27-410d-a5eb-0673105cc6bb"),
                            ChatHistoryId = 0,
                            GameId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Message = "1v1 me",
                            Receiver = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Sender = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Timestamp = new TimeSpan(0, 4, 10, 55, 0)
                        },
                        new
                        {
                            Id = new Guid("20c176a5-d912-40f6-8d12-b9546f47a8aa"),
                            ChatHistoryId = 1,
                            GameId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Message = "You missed, LOL",
                            Receiver = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Sender = new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"),
                            Timestamp = new TimeSpan(0, 5, 1, 20, 0)
                        },
                        new
                        {
                            Id = new Guid("aea77a63-18da-4f11-8f78-05e0decbc141"),
                            ChatHistoryId = 2,
                            GameId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Message = "Follow my twitch stream?",
                            Receiver = new Guid("51201723-156f-4787-a43e-3346d08bab18"),
                            Sender = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Timestamp = new TimeSpan(0, 11, 51, 14, 0)
                        },
                        new
                        {
                            Id = new Guid("b2c6665b-07a4-4470-bf7d-34ba3b8860c1"),
                            ChatHistoryId = 3,
                            GameId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Message = "You're hacking, i'm telling my dad he works at Jagex!!11!",
                            Receiver = new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"),
                            Sender = new Guid("51201723-156f-4787-a43e-3346d08bab18"),
                            Timestamp = new TimeSpan(0, 1, 28, 19, 0)
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("IsOver")
                        .HasColumnType("int");

                    b.Property<Guid>("LoserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Player1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Player2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<Guid>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__tblGame__3214EC07DA24F9C4");

                    b.HasIndex("LoserId");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"),
                            EndTime = new TimeSpan(0, 1, 20, 30, 0),
                            GameId = 0,
                            IsOver = 0,
                            LoserId = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Player1 = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Player2 = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0")
                        },
                        new
                        {
                            Id = new Guid("513df2c7-0c39-45ca-9050-c2cbd7d41b7b"),
                            EndTime = new TimeSpan(0, 1, 20, 30, 0),
                            GameId = 0,
                            IsOver = 0,
                            LoserId = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Player1 = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Player2 = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0")
                        },
                        new
                        {
                            Id = new Guid("2cc2f566-97df-40e8-a33c-d3826fd7b2e7"),
                            EndTime = new TimeSpan(0, 1, 20, 30, 0),
                            GameId = 0,
                            IsOver = 0,
                            LoserId = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Player1 = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Player2 = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0")
                        },
                        new
                        {
                            Id = new Guid("3e70c965-656e-46b1-b84f-36cb77743fd4"),
                            EndTime = new TimeSpan(0, 1, 20, 30, 0),
                            GameId = 0,
                            IsOver = 0,
                            LoserId = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Player1 = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Player2 = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0")
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGameMove", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameMoveId")
                        .HasColumnType("int");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TargetCoordinates")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<TimeSpan>("TimeStamp")
                        .HasColumnType("time");

                    b.HasKey("Id")
                        .HasName("PK__tblGameM__3214EC07B921B560");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("tblGameMove", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("26d0b09f-73cf-4d97-9f28-3e6dce1c00ab"),
                            GameId = new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"),
                            GameMoveId = 0,
                            PlayerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("2f0505fb-f138-458f-84c0-7e22e452402d"),
                            GameId = new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"),
                            GameMoveId = 1,
                            PlayerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("cd8c4a0b-009d-43b3-a063-257d593c6c39"),
                            GameId = new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"),
                            GameMoveId = 2,
                            PlayerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("49aa022b-dc16-43fc-be8c-cbf65d906563"),
                            GameId = new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"),
                            GameMoveId = 3,
                            PlayerId = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblPlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id")
                        .HasName("PK__tblPlaye__3214EC0786DA1BDC");

                    b.ToTable("tblPlayer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"),
                            Email = "123@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g=",
                            UserName = "Sh1PD3STR0Y3R"
                        },
                        new
                        {
                            Id = new Guid("7af2115b-bad0-41e8-b017-de547de80c78"),
                            Email = "456@gmail.com",
                            Password = "YRfkWrV/hmDYZqIcpenSwx28GUU=",
                            UserName = "Timmy"
                        },
                        new
                        {
                            Id = new Guid("51201723-156f-4787-a43e-3346d08bab18"),
                            Email = "789@yahoo.com",
                            Password = "7DUut/wAuxmp4mKiKKNr9eEUeG0=",
                            UserName = "LoveMyCats1155"
                        },
                        new
                        {
                            Id = new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"),
                            Email = "aaabbb@amazon.com",
                            Password = "3oUt/zAHVa53n7yyDzprXz4Rxs8=",
                            UserName = "Skeert"
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblChatHistory", b =>
                {
                    b.HasOne("HiddenBattleship.PL.Entities.tblPlayer", "Player")
                        .WithMany("tblChatHistory")
                        .HasForeignKey("Receiver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.HasOne("HiddenBattleship.PL.Entities.tblPlayer", "Player")
                        .WithMany("tblGames")
                        .HasForeignKey("LoserId")
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGameMove", b =>
                {
                    b.HasOne("HiddenBattleship.PL.Entities.tblGame", "Game")
                        .WithMany("tblGameMoves")
                        .HasForeignKey("GameId")
                        .IsRequired();

                    b.HasOne("HiddenBattleship.PL.Entities.tblPlayer", "Player")
                        .WithMany("tblGameMoves")
                        .HasForeignKey("PlayerId")
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.Navigation("tblGameMoves");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblPlayer", b =>
                {
                    b.Navigation("tblChatHistory");

                    b.Navigation("tblGameMoves");

                    b.Navigation("tblGames");
                });
#pragma warning restore 612, 618
        }
    }
}