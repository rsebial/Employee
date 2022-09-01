using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temperature = table.Column<double>(type: "decimal", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeNumber", "FirstName", "LastName", "Temperature", "RecordDate" },
                values: new object[,]
                {
                    { 1L, "Roosevelt", "Sebial", 36.5, "2022-08-30" },
                    { 2L, "Rachel", "Sebial", 36.9, "2022-09-01" },
                    { 3L, "Cloe", "Ferrater", 36.2, "2022-08-30" },
                    { 4L, "Cleo", "Sebial", 36.7, "2022-08-31" },
                    { 5L, "Maria", "Lourdes", 37.0, "2022-08-31" },
                    { 6L, "Sara", "Anna", 36.9, "2022-09-01" },
                    { 7L, "Mateo", "Juana", 36.5, "2022-09-01" },
                    { 8L, "Lyka", "Gairanod", 36.3, "2022-08-30" },
                    { 9L, "Marcial", "Guadalupe", 36.4, "2022-08-30" },
                    { 10L, "Jose", "Luna", 36.6, "2022-08-31" },
                    { 11L, "Mario", "Lucas", 36.7, "2022-08-30" },
                    { 12L, "Juan", "Cruz", 36.2, "2022-09-01" },
                    { 13L, "Rose", "Antonio", 35.9, "2022-08-29" },
                    { 14L, "Kat", "Lopez", 36.8, "2022-08-28" },
                    { 15L, "Maria", "Debora", 36.5, "2022-08-25" }
                });

            

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "Employee");

        }
    }
}
