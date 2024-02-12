using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class BookStore_UpdateAuthorsInBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "014c5767-8c57-4e06-a6d0-27b4e0537ab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cb60b05-4a0b-4bc7-a5ef-8ee28601fc30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10ee62f0-3b79-481e-aaeb-48c8bb28ce5d", "3df0d72c-54de-4fcf-85cf-8763629d0503", "Role", "Visitor", "VISITOR" },
                    { "c4b4c9b4-21bf-4566-8b14-56b192836852", "713f96e5-44bc-4ebf-8094-2d2a9d00efcd", "Role", "Administrator", "ADMNISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6906), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6924), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6921), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6912), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6916), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6918), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6901), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 1, 22, 54, 878, DateTimeKind.Unspecified).AddTicks(6881), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"),
                column: "AuthorId",
                value: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"),
                column: "AuthorId",
                value: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"),
                column: "AuthorId",
                value: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"),
                column: "AuthorId",
                value: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10ee62f0-3b79-481e-aaeb-48c8bb28ce5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4b4c9b4-21bf-4566-8b14-56b192836852");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "014c5767-8c57-4e06-a6d0-27b4e0537ab2", "5f82ac62-ea16-46f9-a89e-d1bddd522d94", "Role", "Visitor", "VISITOR" },
                    { "1cb60b05-4a0b-4bc7-a5ef-8ee28601fc30", "41d2ac23-bc90-4120-a52d-d9f48c6c9ad1", "Role", "Administrator", "ADMNISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7575), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7590), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7587), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7582), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7584), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 4, 22, 0, 27, 820, DateTimeKind.Unspecified).AddTicks(7559), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("5f5b5017-7347-469d-b351-55bac3c348f6"),
                column: "AuthorId",
                value: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("7376672f-8dc6-4d04-8bcb-e93da5d3c013"),
                column: "AuthorId",
                value: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("8d950ad4-1817-4c82-8a28-17ff6098dc9f"),
                column: "AuthorId",
                value: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b08d1f7a-c874-4743-b742-3b0188f4f96f"),
                column: "AuthorId",
                value: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"));
        }
    }
}
