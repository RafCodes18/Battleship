using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HiddenBattleship.PL.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationCreateDatabase : Migration
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
                    { new Guid("062a0160-ed33-478a-9bad-abc5e3b9ab13"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" },
                    { new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" },
                    { new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("7649c192-1e63-4b9f-90ef-23f66679a11c"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" }
                });

            migrationBuilder.InsertData(
                table: "tblShip",
                columns: new[] { "Id", "ShipType", "Size" },
                values: new object[,]
                {
                    { new Guid("1a1c2421-cf85-4cab-b79b-ee468e34a14b"), 1, 3 },
                    { new Guid("2b413181-cd25-46c4-8ddd-c41a84faafdb"), 3, 2 },
                    { new Guid("6a575606-ee44-4e58-a0af-df2ada76995a"), 4, 5 },
                    { new Guid("bde3bbe9-0e70-474f-a800-226bf4ae6e2c"), 0, 4 },
                    { new Guid("d5c75971-d3c6-46a7-933f-765d39c97f47"), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("33d64902-2d8d-492e-9136-b083abb978f6"), new TimeSpan(0, 1, 20, 30, 0), 1, false, new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 1, 20, 30, 0), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), null },
                    { new Guid("a3b8ac6e-abe6-4b36-acc9-1d33fdb6e55f"), new TimeSpan(0, 1, 20, 30, 0), 2, false, new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 1, 20, 30, 0), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), null },
                    { new Guid("aa1a9afe-4989-4c76-83ac-94e15985ec95"), new TimeSpan(0, 1, 20, 30, 0), 3, false, new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 1, 20, 30, 0), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), null },
                    { new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), new TimeSpan(0, 1, 20, 30, 0), 0, true, new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 1, 20, 30, 0), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("14c6e599-dc81-4d93-a9b0-2ac22908eee6"), 1, new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), "You missed, LOL", new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("1ae99457-c26c-487f-a5df-d73bd6772951"), 3, new Guid("a3b8ac6e-abe6-4b36-acc9-1d33fdb6e55f"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("2a84235b-e5d8-4d1c-88de-fac8982b26ff"), 2, new Guid("33d64902-2d8d-492e-9136-b083abb978f6"), "Follow my twitch stream?", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("7649c192-1e63-4b9f-90ef-23f66679a11c"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("59435841-2e36-4144-8dfc-1b2422872126"), 1, new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("67fd82f5-6f06-4dd6-bf13-59ade25d31d3"), 2, new Guid("33d64902-2d8d-492e-9136-b083abb978f6"), "You missed, LOL", new Guid("7649c192-1e63-4b9f-90ef-23f66679a11c"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("90e20966-b0d0-4d61-8517-32ba7510df0e"), 3, new Guid("a3b8ac6e-abe6-4b36-acc9-1d33fdb6e55f"), "Follow my twitch stream?", new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("9a94b4c9-fa7f-469f-b919-4603ee7f7b41"), 3, new Guid("a3b8ac6e-abe6-4b36-acc9-1d33fdb6e55f"), "1v1 me", new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("b9be3b0b-8045-4c64-a2ec-5c337d3170e4"), 2, new Guid("33d64902-2d8d-492e-9136-b083abb978f6"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("7649c192-1e63-4b9f-90ef-23f66679a11c"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("c113166c-8b56-475e-9e3c-8892cb218a38"), 1, new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), "Follow my twitch stream?", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("c59f3f49-d46a-4b3b-a6ed-6dda95b2760c"), 3, new Guid("a3b8ac6e-abe6-4b36-acc9-1d33fdb6e55f"), "You missed, LOL", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("cbaf1ffe-d1f7-4312-a4ab-83049be5dad9"), 1, new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), "1v1 me", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("202d9bf5-a700-4085-8443-9a53990ef8b2"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("e3da31a6-b34c-4c61-ba30-cf9b6fcb6952"), 2, new Guid("33d64902-2d8d-492e-9136-b083abb978f6"), "1v1 me", new Guid("2ec4ade3-309b-423b-a6f6-a60f420b8f7a"), new Guid("7649c192-1e63-4b9f-90ef-23f66679a11c"), new TimeSpan(0, 4, 10, 55, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "IsHit", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("047818f6-9e29-4101-be05-b58fa107fbd9"), new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), 2, true, new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("3d703040-44fc-4e60-a831-d25438fd395c"), new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), 3, true, new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("9a295282-a519-43ab-9440-88dddfd64d64"), new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), 0, true, new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("a25fda1b-97b1-46a3-8dc8-ca1a07214360"), new Guid("d0683cf5-b054-4f48-8e65-c8c03d7252f9"), 1, true, new Guid("a6df7b6b-8e07-4cbb-aa82-500c2cb3d897"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
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
