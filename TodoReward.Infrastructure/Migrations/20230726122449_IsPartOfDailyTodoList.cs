using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsPartOfDailyTodoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("085bc056-006b-47e3-8ddb-2db3e20d8c78"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("0d462a81-f987-4f9e-8ab2-52dfc18e8c66"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("4841e316-49ed-4e26-bd93-d874b614d6a1"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("496e58cf-b3fe-4efa-93f4-761d3c2ca382"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("583b142a-d5c6-4d70-887f-b9b3d277c407"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6dc76e06-99b5-45d3-8c54-081d62898a73"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("8035dc79-45ca-4957-ac0b-7136fcb5ed01"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("92d35d69-7505-4ec6-ab90-19860e1b8633"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("98695360-281f-4932-b95f-473fe19c5f02"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9cc2bcab-d8a2-4586-82a0-a2f2a894d90d"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("b9fee397-daa3-4624-ae39-74681882723c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("be8faab0-eb48-4523-bce6-e03af09ee760"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ca13880f-b70b-43f1-9c8f-1bac90542540"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("cd122a8d-6d61-43cc-b1f2-2c3f5b1535b3"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ebbce4a9-1aae-4bb3-9c5f-3a6f6e4417e2"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("c5145485-b272-4cbc-a02d-b884771752dd"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("15562c37-977a-47ac-a7a6-538193334e3e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPartOfDailyTodoList",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Propability", "Title" },
                values: new object[,]
                {
                    { new Guid("017c3b6f-07d8-46db-b6c7-387c4131e77f"), "", 100, "Dessert after dinner" },
                    { new Guid("48836ac2-04aa-406e-b642-5be94086919c"), "", 1000, "One podcast episode" },
                    { new Guid("4a695991-43eb-4842-add4-8e21a107ee1b"), "", 1000, "One movie on TV" },
                    { new Guid("63409529-406d-418a-bb84-326a6c863312"), "", 100, "Cinema" },
                    { new Guid("6959ec84-aa12-4182-abdb-10d001f43228"), "", 10, "Go on a Weekend trip" },
                    { new Guid("7447d53a-4941-4bc8-92ea-150ef98653fb"), "", 500, "30 min gaming" },
                    { new Guid("8091d8b0-5b75-421b-8e2f-19f314abf4b1"), "Enjoy a cup of tea", 1000, "Tea" },
                    { new Guid("9110accc-a8f8-4588-8f92-f56bd80dd54c"), "", 1000, "One episode on TV" },
                    { new Guid("9eb99926-e103-4874-a31a-9f66bcf4ab11"), "", 500, "Candy" },
                    { new Guid("b1130e07-a160-4d79-a6b5-d5de1b9ee20d"), "", 200, "Glas of Wine" },
                    { new Guid("ce8f60e7-35d0-49dd-862d-d6a1c3659e9a"), "", 200, "Home made Pizza" },
                    { new Guid("d2819405-3dfd-48ae-9940-054fc6bb52b6"), "", 1000, "Coffea" },
                    { new Guid("ddacac00-ec62-42aa-bf6f-6d61f68fd21c"), "", 500, "30 min book reading" },
                    { new Guid("df59cb23-7daf-4659-973b-617fe4742bed"), "", 100, "Outside lunch" },
                    { new Guid("e4d06262-44d7-4def-b4d1-12386171bb5f"), "", 500, "Soda" },
                    { new Guid("e844a438-f241-426f-a67a-398d737270c0"), "", 1000, "Beer" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("408ba2e9-43c6-4972-9125-c6b528ca1348"), false, new Guid("6959ec84-aa12-4182-abdb-10d001f43228"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("017c3b6f-07d8-46db-b6c7-387c4131e77f"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("48836ac2-04aa-406e-b642-5be94086919c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("4a695991-43eb-4842-add4-8e21a107ee1b"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("63409529-406d-418a-bb84-326a6c863312"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("7447d53a-4941-4bc8-92ea-150ef98653fb"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("8091d8b0-5b75-421b-8e2f-19f314abf4b1"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9110accc-a8f8-4588-8f92-f56bd80dd54c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9eb99926-e103-4874-a31a-9f66bcf4ab11"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("b1130e07-a160-4d79-a6b5-d5de1b9ee20d"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ce8f60e7-35d0-49dd-862d-d6a1c3659e9a"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("d2819405-3dfd-48ae-9940-054fc6bb52b6"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ddacac00-ec62-42aa-bf6f-6d61f68fd21c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("df59cb23-7daf-4659-973b-617fe4742bed"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("e4d06262-44d7-4def-b4d1-12386171bb5f"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("e844a438-f241-426f-a67a-398d737270c0"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("408ba2e9-43c6-4972-9125-c6b528ca1348"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6959ec84-aa12-4182-abdb-10d001f43228"));

            migrationBuilder.DropColumn(
                name: "IsPartOfDailyTodoList",
                table: "TodoItems");

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Propability", "Title" },
                values: new object[,]
                {
                    { new Guid("085bc056-006b-47e3-8ddb-2db3e20d8c78"), "", 500, "30 min book reading" },
                    { new Guid("0d462a81-f987-4f9e-8ab2-52dfc18e8c66"), "", 1000, "Beer" },
                    { new Guid("15562c37-977a-47ac-a7a6-538193334e3e"), "", 10, "Go on a Weekend trip" },
                    { new Guid("4841e316-49ed-4e26-bd93-d874b614d6a1"), "", 200, "Home made Pizza" },
                    { new Guid("496e58cf-b3fe-4efa-93f4-761d3c2ca382"), "", 500, "Soda" },
                    { new Guid("583b142a-d5c6-4d70-887f-b9b3d277c407"), "", 100, "Cinema" },
                    { new Guid("6dc76e06-99b5-45d3-8c54-081d62898a73"), "", 500, "Candy" },
                    { new Guid("8035dc79-45ca-4957-ac0b-7136fcb5ed01"), "", 1000, "One episode on TV" },
                    { new Guid("92d35d69-7505-4ec6-ab90-19860e1b8633"), "", 200, "Glas of Wine" },
                    { new Guid("98695360-281f-4932-b95f-473fe19c5f02"), "", 1000, "Coffea" },
                    { new Guid("9cc2bcab-d8a2-4586-82a0-a2f2a894d90d"), "", 500, "30 min gaming" },
                    { new Guid("b9fee397-daa3-4624-ae39-74681882723c"), "", 100, "Outside lunch" },
                    { new Guid("be8faab0-eb48-4523-bce6-e03af09ee760"), "", 1000, "Tea" },
                    { new Guid("ca13880f-b70b-43f1-9c8f-1bac90542540"), "", 1000, "One podcast episode" },
                    { new Guid("cd122a8d-6d61-43cc-b1f2-2c3f5b1535b3"), "", 100, "Dessert after dinner" },
                    { new Guid("ebbce4a9-1aae-4bb3-9c5f-3a6f6e4417e2"), "", 1000, "One movie on TV" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("c5145485-b272-4cbc-a02d-b884771752dd"), false, new Guid("15562c37-977a-47ac-a7a6-538193334e3e"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }
    }
}
