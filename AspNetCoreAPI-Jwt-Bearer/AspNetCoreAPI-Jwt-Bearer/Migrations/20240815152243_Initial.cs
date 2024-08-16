using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetCoreAPI_Jwt_Bearer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BeginDate", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 18, 22, 42, 549, DateTimeKind.Local).AddTicks(4553), "aliucar@gmail.com", "Ali", "Uçar", "544 322 12 21" },
                    { 2, new DateTime(2024, 8, 15, 18, 22, 42, 549, DateTimeKind.Local).AddTicks(4568), "oyakosar@gmail.com", "Oya", "Koşar", "543 322 12 21" },
                    { 3, new DateTime(2024, 8, 15, 18, 22, 42, 549, DateTimeKind.Local).AddTicks(4570), "nese@gmail.com", "Neşe", "Sever", "532 322 12 21" },
                    { 4, new DateTime(2024, 8, 15, 18, 22, 42, 549, DateTimeKind.Local).AddTicks(4573), "hasan@gmail.com", "Hasan", "Kaya", "533 322 12 21" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
