using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HiddenBattleship.PL.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
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
                    { new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("bd41a2ea-d599-49bb-853d-5776a6aae471"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("ce915408-18c5-47a4-a1ca-d0aad6865cfe"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" },
                    { new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("2c61ed53-9f16-4ef0-8133-4e01870346b0"), new TimeSpan(0, 1, 20, 30, 0), 1, false, new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 1, 20, 30, 0), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), null },
                    { new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), new TimeSpan(0, 1, 20, 30, 0), 0, true, new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 1, 20, 30, 0), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), null },
                    { new Guid("de1e8857-8e5e-44f6-b5e5-a5f9333dec4b"), new TimeSpan(0, 1, 20, 30, 0), 2, false, new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 1, 20, 30, 0), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), null },
                    { new Guid("e945baf2-fbfb-4d49-87cd-9627a2525ee0"), new TimeSpan(0, 1, 20, 30, 0), 3, false, new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 1, 20, 30, 0), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("202acd67-b2e4-41d0-9163-83c603d51779"), 3, new Guid("de1e8857-8e5e-44f6-b5e5-a5f9333dec4b"), "You missed, LOL", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("25a10537-12ec-4bb0-8e09-d73a6a3c6b3d"), 2, new Guid("2c61ed53-9f16-4ef0-8133-4e01870346b0"), "You missed, LOL", new Guid("bd41a2ea-d599-49bb-853d-5776a6aae471"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("51cdedf4-7b5c-4a8f-9da5-1940e5e43fc4"), 2, new Guid("2c61ed53-9f16-4ef0-8133-4e01870346b0"), "1v1 me", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("bd41a2ea-d599-49bb-853d-5776a6aae471"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("7ec38e9b-5c80-4e2d-b602-24a3c4c5ec12"), 2, new Guid("2c61ed53-9f16-4ef0-8133-4e01870346b0"), "Follow my twitch stream?", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("bd41a2ea-d599-49bb-853d-5776a6aae471"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("7f074d26-dd20-4b29-a179-941d3f4b93cc"), 3, new Guid("de1e8857-8e5e-44f6-b5e5-a5f9333dec4b"), "Follow my twitch stream?", new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("9811ebd6-1387-409b-a0df-ab986444f4b5"), 2, new Guid("2c61ed53-9f16-4ef0-8133-4e01870346b0"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("bd41a2ea-d599-49bb-853d-5776a6aae471"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("b458db6c-93cb-4612-a6a7-129b4382a265"), 1, new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), "1v1 me", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("b51105a2-993a-4c23-adda-f10a4ac8a534"), 3, new Guid("de1e8857-8e5e-44f6-b5e5-a5f9333dec4b"), "1v1 me", new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("c27ef319-964b-41ab-a2f9-6ca8e2dd8672"), 3, new Guid("de1e8857-8e5e-44f6-b5e5-a5f9333dec4b"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("d950b146-80e7-4eea-8ace-d908fdc4538b"), 1, new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), "Follow my twitch stream?", new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("fb765900-433c-41d1-87dd-357f1963782d"), 1, new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("ffaf3f06-a655-436d-b013-e582fa5a15df"), 1, new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), "You missed, LOL", new Guid("d7fc902a-8e8b-411f-ab57-79b60cb0e676"), new Guid("2c8a9bf5-b85e-4806-bff7-ebb67c96a1c4"), new TimeSpan(0, 5, 1, 20, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "IsHit", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("02d140fd-1f51-4276-b9d0-c68264a74669"), new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), 3, true, new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("0c5c348d-188d-4858-b615-e79dbb19fb37"), new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), 0, true, new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("5ba4fb22-c8a4-4a50-995f-d333af8f76d4"), new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), 1, true, new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("78fc66e1-6769-490b-9b2b-0d245f1b52b2"), new Guid("c9731145-2bab-44a6-b3c9-c04c2de638d7"), 2, true, new Guid("835b7b7a-872e-4475-9f5c-2965995af13f"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
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
