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
                        name: "FK_tblChatHistory_tblPlayer_Receiver",
                        column: x => x.Receiver,
                        principalTable: "tblPlayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsOver = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblGame__3214EC07DA24F9C4", x => x.Id);
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
                    GameMoveId = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("51201723-156f-4787-a43e-3346d08bab18"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" },
                    { new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("20c176a5-d912-40f6-8d12-b9546f47a8aa"), 1, new Guid("00000000-0000-0000-0000-000000000000"), "You missed, LOL", new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("aea77a63-18da-4f11-8f78-05e0decbc141"), 2, new Guid("00000000-0000-0000-0000-000000000000"), "Follow my twitch stream?", new Guid("51201723-156f-4787-a43e-3346d08bab18"), new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("b2c6665b-07a4-4470-bf7d-34ba3b8860c1"), 3, new Guid("00000000-0000-0000-0000-000000000000"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("ad3bb62c-71dd-4c84-aa0e-d77af5123549"), new Guid("51201723-156f-4787-a43e-3346d08bab18"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("f55d0d8f-ce27-410d-a5eb-0673105cc6bb"), 0, new Guid("00000000-0000-0000-0000-000000000000"), "1v1 me", new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), new TimeSpan(0, 4, 10, 55, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId" },
                values: new object[,]
                {
                    { new Guid("2cc2f566-97df-40e8-a33c-d3826fd7b2e7"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new TimeSpan(0, 1, 20, 30, 0), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0") },
                    { new Guid("3e70c965-656e-46b1-b84f-36cb77743fd4"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new TimeSpan(0, 1, 20, 30, 0), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0") },
                    { new Guid("513df2c7-0c39-45ca-9050-c2cbd7d41b7b"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new TimeSpan(0, 1, 20, 30, 0), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0") },
                    { new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), new Guid("7af2115b-bad0-41e8-b017-de547de80c78"), new TimeSpan(0, 1, 20, 30, 0), new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0") }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("26d0b09f-73cf-4d97-9f28-3e6dce1c00ab"), new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"), 0, new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("2f0505fb-f138-458f-84c0-7e22e452402d"), new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"), 1, new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("49aa022b-dc16-43fc-be8c-cbf65d906563"), new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"), 3, new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("cd8c4a0b-009d-43b3-a063-257d593c6c39"), new Guid("bd1ae00c-0a6c-4eb0-985f-5a01ce38fd5e"), 2, new Guid("c9742f18-a8fb-4f69-8d61-103e3e2f7fd0"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblChatHistory_Receiver",
                table: "tblChatHistory",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_tblGame_LoserId",
                table: "tblGame",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameMove_GameId",
                table: "tblGameMove",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGameMove_PlayerId",
                table: "tblGameMove",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblChatHistory");

            migrationBuilder.DropTable(
                name: "tblGameMove");

            migrationBuilder.DropTable(
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblPlayer");
        }
    }
}
