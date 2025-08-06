using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace My_new_API.Migrations
{
    /// <inheritdoc />
    public partial class regionseednew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("2a75c676-0cfd-434b-b4c4-eff4475c33d8"), "CND", "https://www.alamy.com/stock-photo/canada-map.html?sortBy=relevant", "Canada" },
                    { new Guid("5ff782a8-3d4f-44c8-bbcc-6e01d9967078"), "MLS", "https://www.shutterstock.com/search/malaysia-map", "Malaysia" },
                    { new Guid("6008a2a4-c3f1-48d7-90c1-3ae57bdbc710"), "IND", "https://www.gettyimages.in/detail/illustration/india-map-royalty-free-illustration/1147562559?adppopup=true", "India" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("2a75c676-0cfd-434b-b4c4-eff4475c33d8"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("5ff782a8-3d4f-44c8-bbcc-6e01d9967078"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("6008a2a4-c3f1-48d7-90c1-3ae57bdbc710"));
        }
    }
}
