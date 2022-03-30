using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentServiceGQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    StreetOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[,]
                {
                    { 1, "NY" },
                    { 2, "CA" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "Age", "DoB", "Email", "FirstName", "LastName", "Program", "StudentNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, new DateTime(1984, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nicholas", "Gunn", "Music Studies", "9580389442" },
                    { 2, new DateTime(2021, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, new DateTime(1979, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Charles", "Freiderick", "Something Something Science", "9580389442" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "StateID", "StreetOne", "StreetTwo", "StudentID", "ZipCode" },
                values: new object[] { 1, "Polmero", 1, "8564 Fresco Street", "", 1, "96542" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "StateID", "StreetOne", "StreetTwo", "StudentID", "ZipCode" },
                values: new object[] { 2, "Nina", 2, "9621 Pinta Lane", "", 2, "52145" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateID",
                table: "Addresses",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentID",
                table: "Addresses",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
