using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class evenevenmorerewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("03b27834-5e06-4be2-be41-6ef4b30c022c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("0dfaf399-32fc-4972-9243-859af55909ea"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("196f36b2-e500-4cb9-8b89-c27a7799aa90"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("33e66e73-bb1a-4e34-be2c-7b5c90120b34"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("4871f681-778d-467f-b2a8-f2845834da22"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6408112d-b819-4909-8a8c-0e5fe3a92c84"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6a869253-73d2-4f55-b940-fc70c4659956"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6fcda26a-7911-4ef0-adf9-1c78df965e30"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("97169c09-6972-4723-a7e4-486c2cf0abd6"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("acb8f58e-173b-459d-be09-e8384e07afbe"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("bd5fd075-253d-467b-9eab-ca68e1c8dced"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("d0355515-c7c3-4c01-bbc5-39d9779cf68d"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("dcc2d9e7-b82e-4ff6-a373-6beb2a1c76a6"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("e8b0b78d-13b7-49ce-9efb-52c96c57009f"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ecea8a51-9598-4de1-9873-90d411811fad"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("eec3bdaa-42fa-42cd-8a7f-85a7768548c3"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("d004c52c-63cb-4ebb-87d2-d8ce72b4877a"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("e9bdc45a-e3f1-4254-8aaf-f6c7261e3c5f"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Propability", "Title" },
                values: new object[,]
                {
                    { new Guid("03b27834-5e06-4be2-be41-6ef4b30c022c"), "", 100, "Dessert after dinner" },
                    { new Guid("0dfaf399-32fc-4972-9243-859af55909ea"), "", 200, "Home made Pizza" },
                    { new Guid("196f36b2-e500-4cb9-8b89-c27a7799aa90"), "", 500, "30 min gaming" },
                    { new Guid("33e66e73-bb1a-4e34-be2c-7b5c90120b34"), "", 1000, "30 min podcast" },
                    { new Guid("4871f681-778d-467f-b2a8-f2845834da22"), "", 200, "Glas of Wine" },
                    { new Guid("6408112d-b819-4909-8a8c-0e5fe3a92c84"), "", 1000, "Beer" },
                    { new Guid("6a869253-73d2-4f55-b940-fc70c4659956"), "", 500, "30 min book reading" },
                    { new Guid("6fcda26a-7911-4ef0-adf9-1c78df965e30"), "", 100, "Outside lunch" },
                    { new Guid("97169c09-6972-4723-a7e4-486c2cf0abd6"), "", 1000, "Tea" },
                    { new Guid("acb8f58e-173b-459d-be09-e8384e07afbe"), "", 200, "Home made Pizza" },
                    { new Guid("bd5fd075-253d-467b-9eab-ca68e1c8dced"), "", 1000, "One movie on TV" },
                    { new Guid("d0355515-c7c3-4c01-bbc5-39d9779cf68d"), "", 1000, "Coffea" },
                    { new Guid("dcc2d9e7-b82e-4ff6-a373-6beb2a1c76a6"), "", 500, "Soda" },
                    { new Guid("e8b0b78d-13b7-49ce-9efb-52c96c57009f"), "", 1000, "One episode on TV" },
                    { new Guid("e9bdc45a-e3f1-4254-8aaf-f6c7261e3c5f"), "", 10, "Weekend" },
                    { new Guid("ecea8a51-9598-4de1-9873-90d411811fad"), "", 100, "Cinema" },
                    { new Guid("eec3bdaa-42fa-42cd-8a7f-85a7768548c3"), "", 500, "Candy" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("d004c52c-63cb-4ebb-87d2-d8ce72b4877a"), false, new Guid("e9bdc45a-e3f1-4254-8aaf-f6c7261e3c5f"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }
    }
}
