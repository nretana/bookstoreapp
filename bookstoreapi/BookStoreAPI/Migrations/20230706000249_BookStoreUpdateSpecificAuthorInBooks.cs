using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class BookStoreUpdateSpecificAuthorInBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3f49efa5-d266-4305-8f61-bdf56d6caf5d", "eded88b7-70d3-4f74-a536-885ff173b7ed", "Role", "Administrator", "ADMNISTRATOR" },
                    { "46f73880-2008-420c-9be9-5fef95cc3fea", "c151c00a-b49b-461c-8a08-9fcd389f1ed6", "Role", "Visitor", "VISITOR" }
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("2a71a398-324d-4134-8d9d-d7a625d7bf7a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8884), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8881), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a109f317-0cb2-4052-a176-a30697bb0ec0"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8873), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d7f57782-b4f3-4258-aa1b-b9bfde59912a"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8876), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e1964bbc-16be-42d9-9f53-0269dab573cb"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8878), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e95d66d9-b76b-4487-8b50-a3dd9e076fed"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("fa9fe4c3-3e45-4690-b792-b0510311e3de"),
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2023, 7, 5, 18, 2, 48, 859, DateTimeKind.Unspecified).AddTicks(8851), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"),
                column: "AuthorId",
                value: new Guid("491177e1-7f31-4a87-a2d4-8d6fc6eea234"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f49efa5-d266-4305-8f61-bdf56d6caf5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46f73880-2008-420c-9be9-5fef95cc3fea");

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
                keyValue: new Guid("bcd3aa72-98e8-453a-8461-82dd63079dc3"),
                column: "AuthorId",
                value: new Guid("0b8199a2-5f74-44f2-aeb8-c892bd63f60a"));
        }
    }
}
