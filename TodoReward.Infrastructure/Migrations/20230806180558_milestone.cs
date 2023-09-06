using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoReward.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class milestone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MilstonesReached",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Description", "Propability", "Title" },
                values: new object[,]
                {
                    { new Guid("15b071f2-bda7-4470-bb11-7ef302332ffe"), "", 1000, "One episode on TV" },
                    { new Guid("16828482-e0b9-4fff-9f61-d9fb886fc05b"), "", 500, "Soda" },
                    { new Guid("34ac9300-5494-4c42-b43f-bfc1547ef6bd"), "", 200, "Glas of Wine" },
                    { new Guid("58d75dd1-7a84-4fb1-8d43-4ac7def320f4"), "", 200, "Home made Pizza" },
                    { new Guid("629a2829-dd9b-486e-a0e6-076c47d29658"), "", 500, "Candy" },
                    { new Guid("6b65807f-c2a1-4c6f-bd25-ff8197971423"), "", 1000, "One movie on TV" },
                    { new Guid("6c9792ae-60e6-4946-866f-04dacc55bad1"), "", 1000, "Beer" },
                    { new Guid("9d34543b-367f-46a4-acbf-26b5c525bbae"), "Enjoy a cup of tea", 1000, "Tea" },
                    { new Guid("9fa6d9b3-1dea-4905-b67d-62ea94e4bcfa"), "", 1000, "Coffea" },
                    { new Guid("b218083c-0cf0-416a-bf8b-861ca0bf61c7"), "", 100, "Dessert after dinner" },
                    { new Guid("b9795bd2-d8bf-4027-81ba-7c9e40a6c20e"), "", 100, "Outside lunch" },
                    { new Guid("c4488abe-e0b9-4369-a1b0-89ed107d63a0"), "", 500, "30 min book reading" },
                    { new Guid("cb23d905-326f-44bf-b1e3-ee074f5a1056"), "", 100, "Cinema" },
                    { new Guid("cfc3c4cf-f652-4c62-bda9-1745d230f55b"), "", 500, "30 min gaming" },
                    { new Guid("d637223d-9372-4dce-ae1c-c48937696d9a"), "", 10, "Go on a Weekend trip" },
                    { new Guid("dd969f98-6400-4803-8140-68a1f6f86ddc"), "", 1000, "One podcast episode" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b"),
                column: "MilstonesReached",
                value: 0);

            migrationBuilder.InsertData(
                table: "UserRewards",
                columns: new[] { "Id", "IsDone", "RewardId", "UserId" },
                values: new object[] { new Guid("8b2d8fd3-bdf7-4325-912c-e4f160593749"), false, new Guid("d637223d-9372-4dce-ae1c-c48937696d9a"), new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("15b071f2-bda7-4470-bb11-7ef302332ffe"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("16828482-e0b9-4fff-9f61-d9fb886fc05b"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("34ac9300-5494-4c42-b43f-bfc1547ef6bd"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("58d75dd1-7a84-4fb1-8d43-4ac7def320f4"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("629a2829-dd9b-486e-a0e6-076c47d29658"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6b65807f-c2a1-4c6f-bd25-ff8197971423"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("6c9792ae-60e6-4946-866f-04dacc55bad1"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9d34543b-367f-46a4-acbf-26b5c525bbae"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("9fa6d9b3-1dea-4905-b67d-62ea94e4bcfa"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("b218083c-0cf0-416a-bf8b-861ca0bf61c7"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("b9795bd2-d8bf-4027-81ba-7c9e40a6c20e"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("c4488abe-e0b9-4369-a1b0-89ed107d63a0"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("cb23d905-326f-44bf-b1e3-ee074f5a1056"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("cfc3c4cf-f652-4c62-bda9-1745d230f55b"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("dd969f98-6400-4803-8140-68a1f6f86ddc"));

            migrationBuilder.DeleteData(
                table: "UserRewards",
                keyColumn: "Id",
                keyValue: new Guid("8b2d8fd3-bdf7-4325-912c-e4f160593749"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: new Guid("d637223d-9372-4dce-ae1c-c48937696d9a"));

            migrationBuilder.DropColumn(
                name: "MilstonesReached",
                table: "Users");

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
    }
}
