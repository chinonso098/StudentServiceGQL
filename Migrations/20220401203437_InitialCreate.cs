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
                name: "CollegePrograms",
                columns: table => new
                {
                    CollegeProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegePrograms", x => x.CollegeProgramID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_CollegePrograms_CollegeProgramID",
                        column: x => x.CollegeProgramID,
                        principalTable: "CollegePrograms",
                        principalColumn: "CollegeProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
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
                table: "CollegePrograms",
                columns: new[] { "CollegeProgramID", "EndDate", "ProgramName", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2084, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathematics", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2084, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2084, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bio-Chemistry", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2084, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geology", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "New York", "NY" },
                    { 2, "California", "CA" },
                    { 3, "Georgia", "GA" },
                    { 4, "North Dakota", "ND" },
                    { 5, "South Dakota", "SD" },
                    { 6, "North Carolina", "NC" },
                    { 7, "South Carolina", "SC" },
                    { 8, "Indiana", "IN" },
                    { 9, "Texas", "TX" },
                    { 10, "Illinois", "IL" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "Age", "CollegeProgramID", "DoB", "Email", "FirstName", "LastName", "StudentNumber" },
                values: new object[] { 1, new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 3, new DateTime(1984, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nicholas", "Gunn", "9580389442" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "AdmissionDate", "Age", "CollegeProgramID", "DoB", "Email", "FirstName", "LastName", "StudentNumber" },
                values: new object[] { 2, new DateTime(2021, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 2, new DateTime(1979, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Charles", "Freiderick", "9580389442" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "IsPrimary", "StateID", "StreetOne", "StreetTwo", "StudentID", "ZipCode" },
                values: new object[] { 1, "Polmero", true, 1, "8564 Fresco Street", "", 1, "96542" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "IsPrimary", "StateID", "StreetOne", "StreetTwo", "StudentID", "ZipCode" },
                values: new object[] { 2, "Nina", true, 2, "9621 Pinta Lane", "", 2, "52145" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "IsPrimary", "StateID", "StreetOne", "StreetTwo", "StudentID", "ZipCode" },
                values: new object[] { 3, "Fishers", false, 1, "2346 Venture Rd", "", 1, "96983" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateID",
                table: "Addresses",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentID",
                table: "Addresses",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeProgramID",
                table: "Students",
                column: "CollegeProgramID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "CollegePrograms");
        }
    }
}
