using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class morerewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("062a0330-3dc5-44a1-8c0d-8497d1cbd953"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("2ef7d9ef-42da-4e1a-9e5f-70c9a81ebed0"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("3c85a296-29f5-441d-a3a1-f5bb4821def5"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("40329088-69a8-4f90-b236-4aad5c5a5ffa"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("4fcb7677-7a2c-4cb6-addc-4f404ebc65fc"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("60b5108e-97b3-4f55-a9cb-f89048ab7875"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("7e8728e5-fd75-4ca9-ba0b-d990033f6e82"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("cddba36a-449e-4272-bfa2-cf68d3bb8c75"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("fbb2b8cb-3d69-4389-a2d1-35ad1e50f354"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("0b16153e-9b3d-4696-b62c-b58e5e9c9e4c"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("d17a2923-5740-46e4-aca8-e9e5b1357de1"));

            migrationBuilder.AddColumn<int>(
                name: "Propability",
                table: "Rewards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Propability",
                table: "Rewards");

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("062a0330-3dc5-44a1-8c0d-8497d1cbd953"), "", "One cup of tea" },
                    { new Guid("2ef7d9ef-42da-4e1a-9e5f-70c9a81ebed0"), "", "Dessert after dinner" },
                    { new Guid("3c85a296-29f5-441d-a3a1-f5bb4821def5"), "", "One candy" },
                    { new Guid("40329088-69a8-4f90-b236-4aad5c5a5ffa"), "", "15 min gaming" },
                    { new Guid("4fcb7677-7a2c-4cb6-addc-4f404ebc65fc"), "", "30 min podcast" },
                    { new Guid("60b5108e-97b3-4f55-a9cb-f89048ab7875"), "", "One cup of coffea" },
                    { new Guid("7e8728e5-fd75-4ca9-ba0b-d990033f6e82"), "", "Outside lunch" },
                    { new Guid("cddba36a-449e-4272-bfa2-cf68d3bb8c75"), "", "One beer" },
                    { new Guid("d17a2923-5740-46e4-aca8-e9e5b1357de1"), "", "15 min streaming" },
                    { new Guid("fbb2b8cb-3d69-4389-a2d1-35ad1e50f354"), "", "One soda" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("0b16153e-9b3d-4696-b62c-b58e5e9c9e4c"), false, new Guid("d17a2923-5740-46e4-aca8-e9e5b1357de1"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }
    }
}
