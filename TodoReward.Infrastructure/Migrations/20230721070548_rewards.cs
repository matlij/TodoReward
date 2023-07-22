using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rewards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("b917428f-0445-41aa-8137-742512c0d02b"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("bca1a308-eb4e-41c1-ae83-eae66ef1d92b"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("2197edd1-ffda-42e3-a7be-fe93503d48fd"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("2197edd1-ffda-42e3-a7be-fe93503d48fd"), "", "HBO 30 min" },
                    { new Guid("b917428f-0445-41aa-8137-742512c0d02b"), "", "Beer" }
                });

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("bca1a308-eb4e-41c1-ae83-eae66ef1d92b"), false, new Guid("2197edd1-ffda-42e3-a7be-fe93503d48fd"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }
    }
}
