using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class evenmorerewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("10266726-06d6-4436-b50c-4681ba4e54d2"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("14110cf4-c6df-4ad0-9896-f2e810ba97fd"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("17e67d46-272d-4e35-ba74-e15c33d242e8"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("18e123fb-c137-4d13-848e-02dfda142035"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("554472ee-c6ea-4b5b-bee1-3b89127ce09c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("5fa2a748-eda6-40d0-8483-b4e7810b03b1"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9f382d1f-2c4b-4ab0-b1b6-630ae81c2756"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("a4ad72ee-2819-4b2a-8b85-b276a8603384"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("c8b940bc-ea11-4374-9459-40e01ba45655"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("cdf7ecd9-65a3-4018-9977-74b17972cc32"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("e618ff57-83e1-457e-b84e-90c6c804b82b"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("eb487fb3-db38-49da-9589-6f2e4e094163"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("ab7d62f2-86fb-4170-b106-48e9c74bc428"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("ced0f252-ac53-4dd5-92dd-b638e1f26166"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("10266726-06d6-4436-b50c-4681ba4e54d2"), "", 500, "One candy" },
                    { new Guid("14110cf4-c6df-4ad0-9896-f2e810ba97fd"), "", 500, "15 min gaming" },
                    { new Guid("17e67d46-272d-4e35-ba74-e15c33d242e8"), "", 10, "Weekend" },
                    { new Guid("18e123fb-c137-4d13-848e-02dfda142035"), "", 100, "Outside lunch" },
                    { new Guid("554472ee-c6ea-4b5b-bee1-3b89127ce09c"), "", 200, "Home made Pizza" },
                    { new Guid("5fa2a748-eda6-40d0-8483-b4e7810b03b1"), "", 1000, "30 min podcast" },
                    { new Guid("9f382d1f-2c4b-4ab0-b1b6-630ae81c2756"), "", 1000, "One cup of coffea" },
                    { new Guid("a4ad72ee-2819-4b2a-8b85-b276a8603384"), "", 1000, "One cup of tea" },
                    { new Guid("c8b940bc-ea11-4374-9459-40e01ba45655"), "", 500, "30 min book reading" },
                    { new Guid("cdf7ecd9-65a3-4018-9977-74b17972cc32"), "", 1000, "One beer" },
                    { new Guid("ced0f252-ac53-4dd5-92dd-b638e1f26166"), "", 1000, "15 min streaming" },
                    { new Guid("e618ff57-83e1-457e-b84e-90c6c804b82b"), "", 100, "Dessert after dinner" },
                    { new Guid("eb487fb3-db38-49da-9589-6f2e4e094163"), "", 500, "One soda" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("ab7d62f2-86fb-4170-b106-48e9c74bc428"), false, new Guid("ced0f252-ac53-4dd5-92dd-b638e1f26166"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }
    }
}
