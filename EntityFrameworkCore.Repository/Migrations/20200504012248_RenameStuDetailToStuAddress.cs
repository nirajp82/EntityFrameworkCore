using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Repository.Migrations
{
    public partial class RenameStuDetailToStuAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetail");

            migrationBuilder.CreateTable(
                name: "StudentAddress",
                columns: table => new
                {
                    StudentAddressId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddress", x => x.StudentAddressId);
                    table.ForeignKey(
                        name: "FK_StudentAddress_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddress_StudentId",
                table: "StudentAddress",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAddress");

            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    StudentDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalInformation = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.StudentDetailId);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudentId",
                table: "StudentDetail",
                column: "StudentId",
                unique: true);
        }
    }
}
