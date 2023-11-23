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
                    { new Guid("aa6e32e1-9944-4e8d-be60-6369e5ae469f"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("c01f71d6-3314-4e8e-a256-0ae4c6bcf48b"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), null },
                    { new Guid("400442b7-459b-478d-a4b8-ffc84513fc5e"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), null },
                    { new Guid("d5971a87-2fac-4a85-82bd-bf94e30dad66"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), null },
                    { new Guid("e86c7bd4-26be-4f4f-ab94-c3054c368865"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("2103257d-052b-4f73-a821-b3284d74c637"), 0, new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), "1v1 me", new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new Guid("aa6e32e1-9944-4e8d-be60-6369e5ae469f"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("46d55afe-0ce5-48e3-81ff-df3ef850ded9"), 2, new Guid("400442b7-459b-478d-a4b8-ffc84513fc5e"), "Follow my twitch stream?", new Guid("c01f71d6-3314-4e8e-a256-0ae4c6bcf48b"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("c463ade9-b99e-4ae8-83b3-c7274766ec53"), 3, new Guid("e86c7bd4-26be-4f4f-ab94-c3054c368865"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("aa6e32e1-9944-4e8d-be60-6369e5ae469f"), new Guid("c01f71d6-3314-4e8e-a256-0ae4c6bcf48b"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("f2cc3b42-c6c2-4318-8227-93b2e87b0480"), 1, new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), "You missed, LOL", new Guid("aa6e32e1-9944-4e8d-be60-6369e5ae469f"), new Guid("f256f0a0-d837-4322-8f7d-123aab1808d1"), new TimeSpan(0, 5, 1, 20, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("1a82c5f4-adfc-48cf-85b0-6272cd5ae1e2"), new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), 2, new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("3f11d9b6-edc7-4fa6-a394-d61cd6372fe1"), new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), 0, new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("95965e01-e40e-4a6a-b537-767e4c99f5db"), new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), 1, new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("b3423e72-1575-4874-8374-0f26b1ed1ab1"), new Guid("28439070-31c4-4ec3-a607-1212cf0ec963"), 3, new Guid("e9d93fa9-8a2d-45b1-b211-b3f7fb4ffbf8"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
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
                name: "tblGame");

            migrationBuilder.DropTable(
                name: "tblChatHistory");

            migrationBuilder.DropTable(
                name: "tblPlayer");
        }
    }
}
