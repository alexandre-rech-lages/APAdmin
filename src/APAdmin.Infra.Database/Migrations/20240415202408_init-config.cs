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
            migrationBuilder.CreateTable(
                name: "TBTeam",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TBClassAttendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Week = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Present = table.Column<bool>(type: "bit", nullable: false)
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
                });

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
