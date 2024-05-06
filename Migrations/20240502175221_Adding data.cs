using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Addingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorName", "BookName", "IsAvailable", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Delia Owens", "Där kräftorna sjunger", true, new DateTime(2018, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Alex Schulman", "Bränn alla mina brev", true, new DateTime(2022, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Malin Persson Giolito", "I dina händer", true, new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Lars Kepler", "Hypnotisören", true, new DateTime(2009, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerFirstName", "CustomerLastName", "Email", "MobileNumber" },
                values: new object[,]
                {
                    { 1, "Felicia", "Müller", "felicia@hotmail.com", "0708150336" },
                    { 2, "Filip", "Styrman", "filip@hotmail.com", "0730937124" },
                    { 3, "Helena", "Westland", "helena@hotmail.com", "0705568681" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
