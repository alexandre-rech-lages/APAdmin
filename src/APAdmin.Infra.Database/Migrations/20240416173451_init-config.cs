using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APAdmin.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class initconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTeam", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeetingName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBStudent_TBTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TBTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TBClassAttendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Week = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Month = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Present = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBClassAttendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBClassAttendance_TBStudent_StudentId",
                        column: x => x.StudentId,
                        principalTable: "TBStudent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBClassAttendance_TBTeam_TeamId",
                        column: x => x.TeamId,
                        principalTable: "TBTeam",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TBClassAttendance_StudentId",
                table: "TBClassAttendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TBClassAttendance_TeamId",
                table: "TBClassAttendance",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TBStudent_TeamId",
                table: "TBStudent",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBClassAttendance");

            migrationBuilder.DropTable(
                name: "TBStudent");

            migrationBuilder.DropTable(
                name: "TBTeam");
        }
    }
}
