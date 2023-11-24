using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HiddenBattleship.PL.Migrations
{
    /// <inheritdoc />
    public partial class DBchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("3652d676-6d27-4f37-85ae-1111b6815728"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("5b10a02d-fde7-4fad-aeda-556ca03d314e"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("d9a440e3-6b4f-42e4-b78b-7e13ba488170"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("fc441581-4c59-4be3-bee4-dca76a4819f2"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("7ffbb846-8a6e-47f0-8ec8-851c95bb82af"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("2974d4f8-32e9-4cb1-99d2-ffb00725a326"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("3b9282bd-6ed8-415e-964c-3f9bb15693ff"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("9347b306-a0bc-4079-a05f-186730cc4a4e"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("b138605a-4eca-492d-8609-962b8f8e325a"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("37c04a2d-c484-4dcb-ae0a-8500ad8c566a"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("23efe435-0fb2-499c-a816-d0b969951408"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("edbb4462-761e-4479-881a-009e332cdb57"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("f2932938-3b6d-45b9-8de0-f623a51c13e2"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("3054955c-8301-46c6-97ab-776108ef0a31"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("337455fa-8b86-44b3-9086-0aae72e9c108"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("b2367ccb-adf4-418a-9c8b-67b24ce6c968"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("f730d22c-1ad2-452c-92cc-d82ce3826c41"));

            migrationBuilder.AddColumn<bool>(
                name: "IsHit",
                table: "tblGameMove",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsOver",
                table: "tblGame",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "tblPlayer",
                columns: new[] { "Id", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("0d47950d-e192-47eb-bd01-0015a6d6e1ee"), "uTest@yahoo.com", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "uTest" },
                    { new Guid("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"), "aaabbb@amazon.com", "3oUt/zAHVa53n7yyDzprXz4Rxs8=", "Skeert" },
                    { new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), "456@gmail.com", "YRfkWrV/hmDYZqIcpenSwx28GUU=", "Timmy" },
                    { new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), "123@gmail.com", "W6ph5Mm5Pz8GgiULbPgzG37mj9g=", "Sh1PD3STR0Y3R" },
                    { new Guid("8be96ee1-3dfd-4621-87aa-696515e526e4"), "789@yahoo.com", "7DUut/wAuxmp4mKiKKNr9eEUeG0=", "LoveMyCats1155" }
                });

            migrationBuilder.InsertData(
                table: "tblGame",
                columns: new[] { "Id", "EndTime", "GameId", "IsOver", "LoserId", "Player1", "Player2", "StartTime", "WinnerId", "tblChatHistoryId" },
                values: new object[,]
                {
                    { new Guid("2c4084fc-7a70-4fc9-a411-f79aa6c5e4bf"), new TimeSpan(0, 1, 20, 30, 0), 2, false, new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 1, 20, 30, 0), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), null },
                    { new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), new TimeSpan(0, 1, 20, 30, 0), 0, true, new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 1, 20, 30, 0), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), null },
                    { new Guid("a7235228-a0fd-45a8-ad74-15d904016984"), new TimeSpan(0, 1, 20, 30, 0), 1, false, new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 1, 20, 30, 0), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), null },
                    { new Guid("cec32b6c-024a-4186-917b-892f2c443d64"), new TimeSpan(0, 1, 20, 30, 0), 3, false, new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 1, 20, 30, 0), new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), null }
                });

            migrationBuilder.InsertData(
                table: "tblChatHistory",
                columns: new[] { "Id", "ChatHistoryId", "GameId", "Message", "Receiver", "Sender", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("7874c4ec-c337-4362-9d01-ef3bb31d96d0"), 3, new Guid("2c4084fc-7a70-4fc9-a411-f79aa6c5e4bf"), "You're hacking, i'm telling my dad he works at Jagex!!11!", new Guid("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"), new Guid("8be96ee1-3dfd-4621-87aa-696515e526e4"), new TimeSpan(0, 1, 28, 19, 0) },
                    { new Guid("810d03b7-fa50-485c-9304-8a657c72b547"), 2, new Guid("a7235228-a0fd-45a8-ad74-15d904016984"), "Follow my twitch stream?", new Guid("8be96ee1-3dfd-4621-87aa-696515e526e4"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 11, 51, 14, 0) },
                    { new Guid("cb4972d2-4bf4-43e9-9cec-55049dcd7288"), 0, new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), "1v1 me", new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new Guid("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"), new TimeSpan(0, 4, 10, 55, 0) },
                    { new Guid("ce22de26-5736-4eca-89e0-3c4aeb6c7f0e"), 1, new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), "You missed, LOL", new Guid("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"), new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"), new TimeSpan(0, 5, 1, 20, 0) }
                });

            migrationBuilder.InsertData(
                table: "tblGameMove",
                columns: new[] { "Id", "GameId", "GameMoveId", "IsHit", "PlayerId", "TargetCoordinates", "TimeStamp" },
                values: new object[,]
                {
                    { new Guid("3927c5fe-7dab-4426-b0de-37b8297ce886"), new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), 2, true, new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("7b2b6c47-fef8-40bf-b4e1-1f3b3ec6b82b"), new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), 3, true, new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("e4a5fe2a-b9a2-42d5-b9dd-e542fd007c15"), new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), 1, true, new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), "A5", new TimeSpan(0, 1, 20, 30, 0) },
                    { new Guid("fc70191c-2899-45b4-b2d0-2e983008aafc"), new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"), 0, true, new Guid("5ef72535-3891-4689-b1d6-281649d31e59"), "A5", new TimeSpan(0, 1, 20, 30, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("7874c4ec-c337-4362-9d01-ef3bb31d96d0"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("810d03b7-fa50-485c-9304-8a657c72b547"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("cb4972d2-4bf4-43e9-9cec-55049dcd7288"));

            migrationBuilder.DeleteData(
                table: "tblChatHistory",
                keyColumn: "Id",
                keyValue: new Guid("ce22de26-5736-4eca-89e0-3c4aeb6c7f0e"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("cec32b6c-024a-4186-917b-892f2c443d64"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("3927c5fe-7dab-4426-b0de-37b8297ce886"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("7b2b6c47-fef8-40bf-b4e1-1f3b3ec6b82b"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("e4a5fe2a-b9a2-42d5-b9dd-e542fd007c15"));

            migrationBuilder.DeleteData(
                table: "tblGameMove",
                keyColumn: "Id",
                keyValue: new Guid("fc70191c-2899-45b4-b2d0-2e983008aafc"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("0d47950d-e192-47eb-bd01-0015a6d6e1ee"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("2c4084fc-7a70-4fc9-a411-f79aa6c5e4bf"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("9e227195-3ea1-4d23-a5fc-df835b7c46a8"));

            migrationBuilder.DeleteData(
                table: "tblGame",
                keyColumn: "Id",
                keyValue: new Guid("a7235228-a0fd-45a8-ad74-15d904016984"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("0e7af0f1-d3b4-4d3f-aab7-5399cba2868a"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("5ef72535-3891-4689-b1d6-281649d31e59"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("8be96ee1-3dfd-4621-87aa-696515e526e4"));

            migrationBuilder.DeleteData(
                table: "tblPlayer",
                keyColumn: "Id",
                keyValue: new Guid("2ada9df8-3d6d-4116-8d71-f4ce4f6cd2d3"));

            migrationBuilder.DropColumn(
                name: "IsHit",
                table: "tblGameMove");

            migrationBuilder.AlterColumn<int>(
                name: "IsOver",
                table: "tblGame",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

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
        }
    }
}
