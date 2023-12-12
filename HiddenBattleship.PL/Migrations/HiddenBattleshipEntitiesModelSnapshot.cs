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

                    b.HasIndex("GameId");

                    b.HasIndex("Receiver");

                    b.ToTable("tblChatHistory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e71d346-0395-4ce7-b81d-5872013e4231"),
                            ChatHistoryId = 1,
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            Message = "1v1 me",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Timestamp = new TimeSpan(0, 4, 10, 55, 0)
                        },
                        new
                        {
                            Id = new Guid("6cccd770-b687-49c7-bf84-eb3d9ea06cc6"),
                            ChatHistoryId = 1,
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            Message = "You missed, LOL",
                            Receiver = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 5, 1, 20, 0)
                        },
                        new
                        {
                            Id = new Guid("1d861a68-d6ea-4ef3-bfa9-bf9deafb5d19"),
                            ChatHistoryId = 1,
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            Message = "Follow my twitch stream?",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Timestamp = new TimeSpan(0, 11, 51, 14, 0)
                        },
                        new
                        {
                            Id = new Guid("9ad56427-ab95-4f68-a620-5f404085975d"),
                            ChatHistoryId = 1,
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            Message = "You're hacking, i'm telling my dad he works at Jagex!!11!",
                            Receiver = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 1, 28, 19, 0)
                        },
                        new
                        {
                            Id = new Guid("b664b72e-f7a1-4010-9ace-32b6e0bed0d6"),
                            ChatHistoryId = 2,
                            GameId = new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"),
                            Message = "1v1 me",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Timestamp = new TimeSpan(0, 4, 10, 55, 0)
                        },
                        new
                        {
                            Id = new Guid("9d25d72b-e2d3-4962-8ba6-828c3ecc9717"),
                            ChatHistoryId = 2,
                            GameId = new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"),
                            Message = "You missed, LOL",
                            Receiver = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 5, 1, 20, 0)
                        },
                        new
                        {
                            Id = new Guid("ace83a63-6a1d-4ec0-a62e-5b6780674f20"),
                            ChatHistoryId = 2,
                            GameId = new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"),
                            Message = "Follow my twitch stream?",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Timestamp = new TimeSpan(0, 11, 51, 14, 0)
                        },
                        new
                        {
                            Id = new Guid("6de2df82-f7c3-411d-8a6f-32c81a0d3ad3"),
                            ChatHistoryId = 2,
                            GameId = new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"),
                            Message = "You're hacking, i'm telling my dad he works at Jagex!!11!",
                            Receiver = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 1, 28, 19, 0)
                        },
                        new
                        {
                            Id = new Guid("5c0f7587-cfb6-439f-8d59-47f838626d97"),
                            ChatHistoryId = 3,
                            GameId = new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"),
                            Message = "1v1 me",
                            Receiver = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Sender = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Timestamp = new TimeSpan(0, 4, 10, 55, 0)
                        },
                        new
                        {
                            Id = new Guid("e40d1b21-b39f-4cb1-b3d0-ed3890c47ac5"),
                            ChatHistoryId = 3,
                            GameId = new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"),
                            Message = "You missed, LOL",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 5, 1, 20, 0)
                        },
                        new
                        {
                            Id = new Guid("2b3b9d21-e1ab-4d31-9b89-06eaf825cd78"),
                            ChatHistoryId = 3,
                            GameId = new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"),
                            Message = "Follow my twitch stream?",
                            Receiver = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Sender = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Timestamp = new TimeSpan(0, 11, 51, 14, 0)
                        },
                        new
                        {
                            Id = new Guid("4db17c18-56f0-473a-a75f-b871a7d2a8d3"),
                            ChatHistoryId = 3,
                            GameId = new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"),
                            Message = "You're hacking, i'm telling my dad he works at Jagex!!11!",
                            Receiver = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Sender = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Timestamp = new TimeSpan(0, 1, 28, 19, 0)
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("EndTime")
                        .IsRequired()
                        .HasColumnType("time");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOver")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LoserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Player1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Player2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("tblChatHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__tblGame__3214EC07DA24F9C4");

                    b.HasIndex("LoserId");

                    b.HasIndex("tblChatHistoryId");

                    b.ToTable("tblGame", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            EndTime = new TimeSpan(0, 1, 11, 30, 0),
                            GameId = 0,
                            IsOver = true,
                            LoserId = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Player1 = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Player2 = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("3bede396-0071-4304-b330-223bac278b55")
                        },
                        new
                        {
                            Id = new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"),
                            EndTime = new TimeSpan(0, 2, 20, 30, 0),
                            GameId = 1,
                            IsOver = false,
                            LoserId = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Player1 = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Player2 = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            StartTime = new TimeSpan(0, 2, 21, 31, 0),
                            WinnerId = new Guid("6b3380a0-44d0-428c-a889-58607003e041")
                        },
                        new
                        {
                            Id = new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"),
                            EndTime = new TimeSpan(0, 3, 20, 30, 0),
                            GameId = 2,
                            IsOver = false,
                            LoserId = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Player1 = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Player2 = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            StartTime = new TimeSpan(0, 1, 22, 32, 0),
                            WinnerId = new Guid("3bede396-0071-4304-b330-223bac278b55")
                        },
                        new
                        {
                            Id = new Guid("5b2a631a-1a3c-4525-ae7d-1cc83844c23e"),
                            EndTime = new TimeSpan(0, 4, 20, 30, 0),
                            GameId = 3,
                            IsOver = false,
                            LoserId = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Player1 = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Player2 = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc")
                        },
                        new
                        {
                            Id = new Guid("f2c3e5e8-a345-4239-b5bb-956848c90719"),
                            EndTime = new TimeSpan(0, 5, 20, 30, 0),
                            GameId = 4,
                            IsOver = true,
                            LoserId = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Player1 = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Player2 = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc")
                        },
                        new
                        {
                            Id = new Guid("91654455-0c57-45c5-90ad-9475dd2228dc"),
                            EndTime = new TimeSpan(0, 6, 20, 30, 0),
                            GameId = 5,
                            IsOver = false,
                            LoserId = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Player1 = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Player2 = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc")
                        },
                        new
                        {
                            Id = new Guid("7beb78cb-3242-41f3-afbb-40b6ebc0d740"),
                            EndTime = new TimeSpan(0, 7, 20, 30, 0),
                            GameId = 6,
                            IsOver = false,
                            LoserId = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Player1 = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Player2 = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("6b3380a0-44d0-428c-a889-58607003e041")
                        },
                        new
                        {
                            Id = new Guid("acea367a-8739-4412-99bf-0fb107f4891c"),
                            EndTime = new TimeSpan(0, 8, 20, 30, 0),
                            GameId = 7,
                            IsOver = false,
                            LoserId = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Player1 = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Player2 = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            StartTime = new TimeSpan(0, 1, 20, 30, 0),
                            WinnerId = new Guid("6b3380a0-44d0-428c-a889-58607003e041")
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

                    b.Property<bool>("IsHit")
                        .HasColumnType("bit");

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
                            Id = new Guid("a4fb993a-812d-49bd-8806-47f709d3cf9a"),
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            GameMoveId = 0,
                            IsHit = true,
                            PlayerId = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("7338c4b9-49b8-4d8a-99af-09ea772f0bdb"),
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            GameMoveId = 1,
                            IsHit = true,
                            PlayerId = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("80f8c5fc-a8e8-416e-8226-f7887ae176fc"),
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            GameMoveId = 2,
                            IsHit = true,
                            PlayerId = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            TargetCoordinates = "A5",
                            TimeStamp = new TimeSpan(0, 1, 20, 30, 0)
                        },
                        new
                        {
                            Id = new Guid("3552ad94-8285-4ef0-acf8-6ef471e854d3"),
                            GameId = new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"),
                            GameMoveId = 3,
                            IsHit = true,
                            PlayerId = new Guid("3bede396-0071-4304-b330-223bac278b55"),
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
                            Id = new Guid("3bede396-0071-4304-b330-223bac278b55"),
                            Email = "123@gmail.com",
                            Password = "W6ph5Mm5Pz8GgiULbPgzG37mj9g=",
                            UserName = "Sh1PD3STR0Y3R"
                        },
                        new
                        {
                            Id = new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"),
                            Email = "456@gmail.com",
                            Password = "YRfkWrV/hmDYZqIcpenSwx28GUU=",
                            UserName = "Timmy"
                        },
                        new
                        {
                            Id = new Guid("6b3380a0-44d0-428c-a889-58607003e041"),
                            Email = "789@yahoo.com",
                            Password = "7DUut/wAuxmp4mKiKKNr9eEUeG0=",
                            UserName = "LoveMyCats1155"
                        },
                        new
                        {
                            Id = new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"),
                            Email = "aaabbb@amazon.com",
                            Password = "3oUt/zAHVa53n7yyDzprXz4Rxs8=",
                            UserName = "Skeert"
                        },
                        new
                        {
                            Id = new Guid("8d3a7de7-a999-43fe-bc3f-6f544d5b1370"),
                            Email = "uTest@yahoo.com",
                            Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=",
                            UserName = "uTest"
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblShip", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ShipType")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_tblShip");

                    b.ToTable("tblShip", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("35ad5e60-d7f9-4fb2-b633-25b75646d544"),
                            ShipType = 0,
                            Size = 4
                        },
                        new
                        {
                            Id = new Guid("ea42e653-5c96-4aa1-ab47-aa03763fb699"),
                            ShipType = 4,
                            Size = 5
                        },
                        new
                        {
                            Id = new Guid("4fe79b54-53f2-495e-b224-407a9bacd25d"),
                            ShipType = 1,
                            Size = 3
                        },
                        new
                        {
                            Id = new Guid("13468db9-e4c0-48bb-b00d-83d531528d84"),
                            ShipType = 2,
                            Size = 2
                        },
                        new
                        {
                            Id = new Guid("ffbae24a-6cb0-48c0-928f-4042be5b8e07"),
                            ShipType = 3,
                            Size = 2
                        });
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblChatHistory", b =>
                {
                    b.HasOne("HiddenBattleship.PL.Entities.tblGame", "Game")
                        .WithMany("tblChatHistories")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HiddenBattleship.PL.Entities.tblPlayer", "Player")
                        .WithMany("tblChatHistories")
                        .HasForeignKey("Receiver")
                        .IsRequired()
                        .HasConstraintName("fk_tblPlayer_Sender");

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.HasOne("HiddenBattleship.PL.Entities.tblPlayer", "Player")
                        .WithMany("tblGames")
                        .HasForeignKey("LoserId");

                    b.HasOne("HiddenBattleship.PL.Entities.tblChatHistory", null)
                        .WithMany("tblGames")
                        .HasForeignKey("tblChatHistoryId");

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

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblChatHistory", b =>
                {
                    b.Navigation("tblGames");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblGame", b =>
                {
                    b.Navigation("tblChatHistories");

                    b.Navigation("tblGameMoves");
                });

            modelBuilder.Entity("HiddenBattleship.PL.Entities.tblPlayer", b =>
                {
                    b.Navigation("tblChatHistories");

                    b.Navigation("tblGameMoves");

                    b.Navigation("tblGames");
                });
#pragma warning restore 612, 618
        }
    }
}
