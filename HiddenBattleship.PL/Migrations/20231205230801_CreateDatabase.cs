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
                    { new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("d03a3240-744b-4851-aca3-dd931e88ee23"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" },
                    { new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" }
                });

            migrationBuilder.InsertData(
                table: "tblShip",
                columns: new[] { "Id", "ShipType", "Size" },
                values: new object[,]
                {
                    { new Guid("358f1a8a-d620-4c95-a4c8-9582762a1dd9"), 1, 3 },
                    { new Guid("7bd24bab-35b4-4b19-ab44-ea2138dcfe3a"), 2, 2 },
                    { new Guid("82ac0e17-4a91-4040-8e8f-15a3065a36f7"), 0, 4 },
                    { new Guid("9b82dd7f-07af-4ff2-a882-40512c05dd9c"), 4, 5 },
                    { new Guid("c355a5d3-8067-4ea9-879b-5c066902c842"), 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("01d195d0-4a11-460c-93c5-747b3c9ae47c"), new TimeSpan(0, 6, 20, 30, 0), 5, false, new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), null },
                    { new Guid("0dcf22df-5679-4656-805d-f9619103802f"), new TimeSpan(0, 1, 11, 30, 0), 0, true, new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new TimeSpan(0, 1, 20, 30, 0), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), null },
                    { new Guid("242a0d3a-c8a5-4696-840a-c92f73068e4c"), new TimeSpan(0, 7, 20, 30, 0), 6, false, new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 1, 20, 30, 0), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), null },
                    { new Guid("2c88036e-1494-49e1-b929-e49a456ca384"), new TimeSpan(0, 3, 20, 30, 0), 2, false, new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 1, 22, 32, 0), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), null },
                    { new Guid("2e448797-7627-4a85-9aaf-a8436edd320e"), new TimeSpan(0, 4, 20, 30, 0), 3, false, new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), null },
                    { new Guid("9b2d4276-570a-44b0-bf19-f6c52bebb115"), new TimeSpan(0, 2, 20, 30, 0), 1, false, new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 2, 21, 31, 0), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), null },
                    { new Guid("a5202682-3cdb-4f63-8cc2-9d661b9a720f"), new TimeSpan(0, 8, 20, 30, 0), 7, false, new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 1, 20, 30, 0), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), null },
                    { new Guid("c44a09b3-010c-4cf0-8e24-7fe746c4ebd8"), new TimeSpan(0, 5, 20, 30, 0), 4, true, new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 1, 20, 30, 0), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("02cc8c67-b2de-4020-a111-90b48337bde8"), 1, new Guid("0dcf22df-5679-4656-805d-f9619103802f"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("10083e34-f4eb-4eb8-9f09-abfe2ee00eb3"), 1, new Guid("0dcf22df-5679-4656-805d-f9619103802f"), "1v1 me", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("447856bd-e6b7-4cd2-b0f5-40ad2aefc643"), 3, new Guid("2c88036e-1494-49e1-b929-e49a456ca384"), "Follow my twitch stream?", new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("6d9a37db-97e3-40ed-9526-b6a0dc576b91"), 2, new Guid("9b2d4276-570a-44b0-bf19-f6c52bebb115"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("86f3db31-377a-4422-b0c7-fbab856e17af"), 2, new Guid("9b2d4276-570a-44b0-bf19-f6c52bebb115"), "1v1 me", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("93358209-c8c7-427d-a3b7-bbde753c4c38"), 2, new Guid("9b2d4276-570a-44b0-bf19-f6c52bebb115"), "Follow my twitch stream?", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("a2ebdec4-7275-4028-bcb1-b3a036971d6a"), 1, new Guid("0dcf22df-5679-4656-805d-f9619103802f"), "Follow my twitch stream?", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("af44a1ed-b641-409d-bb88-1a1951c00056"), 3, new Guid("2c88036e-1494-49e1-b929-e49a456ca384"), "1v1 me", new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("e09e062b-9b48-41bb-9cdd-18543814eecb"), 1, new Guid("0dcf22df-5679-4656-805d-f9619103802f"), "You missed, LOL", new Guid("e6f5d410-7877-4798-b90a-d1934ea55817"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("e31c401e-78a5-4e10-8a2a-ba869057a1ea"), 3, new Guid("2c88036e-1494-49e1-b929-e49a456ca384"), "You missed, LOL", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("e9bc2e29-83da-4634-ba57-fd8a06e8132e"), 2, new Guid("9b2d4276-570a-44b0-bf19-f6c52bebb115"), "You missed, LOL", new Guid("d443d28c-97cd-41a4-b297-9afff57d58c4"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("f8dc4185-5655-41c8-aad4-5d14f69585b2"), 3, new Guid("2c88036e-1494-49e1-b929-e49a456ca384"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new Guid("8d520d13-a349-471f-9998-0743604ef4bc"), new TimeSpan(0, 1, 28, 19, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "IsHit", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("59c277e0-6647-4f26-b089-fea83580a717"), new Guid("0dcf22df-5679-4656-805d-f9619103802f"), 3, true, new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("5a408bcf-c82f-47a2-8cf3-30f8403e3dab"), new Guid("0dcf22df-5679-4656-805d-f9619103802f"), 0, true, new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("7a52dd76-9968-4f90-9ec6-d74a396fc978"), new Guid("0dcf22df-5679-4656-805d-f9619103802f"), 2, true, new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("c5512b58-7423-48c0-9a92-708115e7eb37"), new Guid("0dcf22df-5679-4656-805d-f9619103802f"), 1, true, new Guid("1ec34753-526c-4ccb-bd97-331d4912e519"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
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
