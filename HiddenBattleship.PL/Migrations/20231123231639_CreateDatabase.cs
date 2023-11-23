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
                    { new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("337455fa-8b86-44b3-9086-0aae72e9c108"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("37c04a2d-c484-4dcb-ae0a-8500ad8c566a"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" },
                    { new Guid("b2367ccb-adf4-418a-9c8b-67b24ce6c968"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" },
                    { new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("23efe435-0fb2-499c-a816-d0b969951408"), new TimeSpan(0, 1, 20, 30, 0), 1, 0, new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 1, 20, 30, 0), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), null },
                    { new Guid("7ffbb846-8a6e-47f0-8ec8-851c95bb82af"), new TimeSpan(0, 1, 20, 30, 0), 3, 0, new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 1, 20, 30, 0), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), null },
                    { new Guid("edbb4462-761e-4479-881a-009e332cdb57"), new TimeSpan(0, 1, 20, 30, 0), 2, 0, new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 1, 20, 30, 0), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), null },
                    { new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), new TimeSpan(0, 1, 20, 30, 0), 0, 0, new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 1, 20, 30, 0), new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("3652d676-6d27-4f37-85ae-1111b6815728"), 0, new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), "1v1 me", new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new Guid("337455fa-8b86-44b3-9086-0aae72e9c108"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("5b10a02d-fde7-4fad-aeda-556ca03d314e"), 1, new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), "You missed, LOL", new Guid("337455fa-8b86-44b3-9086-0aae72e9c108"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 5, 1, 20, 0) },
                    { new Guid("d9a440e3-6b4f-42e4-b78b-7e13ba488170"), 3, new Guid("edbb4462-761e-4479-881a-009e332cdb57"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("337455fa-8b86-44b3-9086-0aae72e9c108"), new Guid("b2367ccb-adf4-418a-9c8b-67b24ce6c968"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("fc441581-4c59-4be3-bee4-dca76a4819f2"), 2, new Guid("23efe435-0fb2-499c-a816-d0b969951408"), "Follow my twitch stream?", new Guid("b2367ccb-adf4-418a-9c8b-67b24ce6c968"), new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"), new TimeSpan(0, 11, 51, 14, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("2974d4f8-32e9-4cb1-99d2-ffb00725a326"), new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), 0, new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("3b9282bd-6ed8-415e-964c-3f9bb15693ff"), new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), 3, new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("9347b306-a0bc-4079-a05f-186730cc4a4e"), new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), 2, new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("b138605a-4eca-492d-8609-962b8f8e325a"), new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"), 1, new Guid("3054955c-8301-46c6-97ab-776108ef0a31"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
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
