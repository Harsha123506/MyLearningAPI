using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace My_new_API.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4efe3c60-a3d2-4570-b20f-8ed8dd8f53d0"), "Medium" },
                    { new Guid("a71142f7-7059-4fc3-8fd8-8e85711d808c"), "Easy" },
                    { new Guid("fd19b7a2-558a-44e2-81c0-44481088558a"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4efe3c60-a3d2-4570-b20f-8ed8dd8f53d0"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a71142f7-7059-4fc3-8fd8-8e85711d808c"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fd19b7a2-558a-44e2-81c0-44481088558a"));
        }
    }
}
