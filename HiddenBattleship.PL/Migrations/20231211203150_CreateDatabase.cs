using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HiddenBattleship.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPlayer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblPlaye__3214EC0786DA1BDC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblShip",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", unicode: false, nullable: false),
                    ShipType = table.Column<int>(type: "int", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblChatHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sender = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receiver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Timestamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    ChatHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblChatH__3214EC07CBD56E82", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblPlayer_Sender",
                        column: x => x.Receiver,
                        principalTable: "tblPlayer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsOver = table.Column<bool>(type: "bit", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    tblChatHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblGame__3214EC07DA24F9C4", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGame_tblChatHistory_tblChatHistoryId",
                        column: x => x.tblChatHistoryId,
                        principalTable: "tblChatHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGame_tblPlayer_LoserId",
                        column: x => x.LoserId,
                        principalTable: "tblPlayer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblGameMove",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetCoordinates = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TimeStamp = table.Column<TimeSpan>(type: "time", nullable: false),
                    GameMoveId = table.Column<int>(type: "int", nullable: false),
                    IsHit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblGameM__3214EC07B921B560", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblGameMove_tblGame_GameId",
                        column: x => x.GameId,
                        principalTable: "tblGame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblGameMove_tblPlayer_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "tblPlayer",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" },
                    { new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("3bede396-0071-4304-b330-223bac278b55"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("6b3380a0-44d0-428c-a889-58607003e041"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("8d3a7de7-a999-43fe-bc3f-6f544d5b1370"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" }
                });

            migrationBuilder.InsertData(
                table: "tblShip",
                columns: new[] { "Id", "ShipType", "Size" },
                values: new object[,]
                {
                    { new Guid("13468db9-e4c0-48bb-b00d-83d531528d84"), 2, 2 },
                    { new Guid("35ad5e60-d7f9-4fb2-b633-25b75646d544"), 0, 4 },
                    { new Guid("4fe79b54-53f2-495e-b224-407a9bacd25d"), 1, 3 },
                    { new Guid("ea42e653-5c96-4aa1-ab47-aa03763fb699"), 4, 5 },
                    { new Guid("ffbae24a-6cb0-48c0-928f-4042be5b8e07"), 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"), new TimeSpan(0, 2, 20, 30, 0), 1, false, new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("3bede396-0071-4304-b330-223bac278b55"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 2, 21, 31, 0), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), null },
                    { new Guid("5b2a631a-1a3c-4525-ae7d-1cc83844c23e"), new TimeSpan(0, 4, 20, 30, 0), 3, false, new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 1, 20, 30, 0), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), null },
                    { new Guid("7beb78cb-3242-41f3-afbb-40b6ebc0d740"), new TimeSpan(0, 7, 20, 30, 0), 6, false, new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 1, 20, 30, 0), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), null },
                    { new Guid("91654455-0c57-45c5-90ad-9475dd2228dc"), new TimeSpan(0, 6, 20, 30, 0), 5, false, new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 1, 20, 30, 0), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), null },
                    { new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"), new TimeSpan(0, 3, 20, 30, 0), 2, false, new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("3bede396-0071-4304-b330-223bac278b55"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 1, 22, 32, 0), new Guid("3bede396-0071-4304-b330-223bac278b55"), null },
                    { new Guid("acea367a-8739-4412-99bf-0fb107f4891c"), new TimeSpan(0, 8, 20, 30, 0), 7, false, new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 1, 20, 30, 0), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), null },
                    { new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), new TimeSpan(0, 1, 11, 30, 0), 0, true, new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("3bede396-0071-4304-b330-223bac278b55"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new TimeSpan(0, 1, 20, 30, 0), new Guid("3bede396-0071-4304-b330-223bac278b55"), null },
                    { new Guid("f2c3e5e8-a345-4239-b5bb-956848c90719"), new TimeSpan(0, 5, 20, 30, 0), 4, true, new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 1, 20, 30, 0), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("1d861a68-d6ea-4ef3-bfa9-bf9deafb5d19"), 1, new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), "Follow my twitch stream?", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("2b3b9d21-e1ab-4d31-9b89-06eaf825cd78"), 3, new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"), "Follow my twitch stream?", new Guid("3bede396-0071-4304-b330-223bac278b55"), new Guid("3bede396-0071-4304-b330-223bac278b55"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("4db17c18-56f0-473a-a75f-b871a7d2a8d3"), 3, new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("5c0f7587-cfb6-439f-8d59-47f838626d97"), 3, new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"), "1v1 me", new Guid("3bede396-0071-4304-b330-223bac278b55"), new Guid("3bede396-0071-4304-b330-223bac278b55"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("6cccd770-b687-49c7-bf84-eb3d9ea06cc6"), 1, new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), "You missed, LOL", new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("6de2df82-f7c3-411d-8a6f-32c81a0d3ad3"), 2, new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("6e71d346-0395-4ce7-b81d-5872013e4231"), 1, new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), "1v1 me", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("9ad56427-ab95-4f68-a620-5f404085975d"), 1, new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("1930c246-2070-4d2f-9b6b-20bde85196fc"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("9d25d72b-e2d3-4962-8ba6-828c3ecc9717"), 2, new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"), "You missed, LOL", new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("ace83a63-6a1d-4ec0-a62e-5b6780674f20"), 2, new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"), "Follow my twitch stream?", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("b664b72e-f7a1-4010-9ace-32b6e0bed0d6"), 2, new Guid("38fb06d4-b5b9-4094-9da2-959bb94e238a"), "1v1 me", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("2701bd5f-fa30-4b76-98b6-7f405ae7fb99"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("e40d1b21-b39f-4cb1-b3d0-ed3890c47ac5"), 3, new Guid("a4159563-ef42-40f8-b84c-fffec88a0170"), "You missed, LOL", new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new Guid("6b3380a0-44d0-428c-a889-58607003e041"), new TimeSpan(0, 5, 1, 20, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "IsHit", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("3552ad94-8285-4ef0-acf8-6ef471e854d3"), new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), 3, true, new Guid("3bede396-0071-4304-b330-223bac278b55"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("7338c4b9-49b8-4d8a-99af-09ea772f0bdb"), new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), 1, true, new Guid("3bede396-0071-4304-b330-223bac278b55"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("80f8c5fc-a8e8-416e-8226-f7887ae176fc"), new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), 2, true, new Guid("3bede396-0071-4304-b330-223bac278b55"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("a4fb993a-812d-49bd-8806-47f709d3cf9a"), new Guid("d6130fbf-8774-46f1-82c6-95c1915f928f"), 0, true, new Guid("3bede396-0071-4304-b330-223bac278b55"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblChatHistory_GameId",
                table: "tblChatHistory",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblChatHistory_Receiver",
                table: "tblChatHistory",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_LoserId",
                table: "tblGame",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_tblChatHistoryId",
                table: "tblGame",
                column: "tblChatHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameMove_GameId",
                table: "tblGameMove",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameMove_PlayerId",
                table: "tblGameMove",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblChatHistory_tblGame_GameId",
                table: "tblChatHistory",
                column: "GameId",
                principalTable: "tblGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblChatHistory_tblGame_GameId",
                table: "tblChatHistory");

            migrationBuilder.DropTable(
                name: "tblGameMove");

            migrationBuilder.DropTable(
                name: "tblShip");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblChatHistory");

            migrationBuilder.DropTable(
                name: "tblPlayer");
        }
    }
}
