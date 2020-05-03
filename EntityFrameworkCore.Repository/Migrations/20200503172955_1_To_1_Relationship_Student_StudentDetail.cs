using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Repository.Migrations
{
    public partial class _1_To_1_Relationship_Student_StudentDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    StudentDetailId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.StudentDetailId);
                    table.ForeignKey(
                        name: "FK_StudentDetail_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_StudentId",
                table: "StudentDetail",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetail");
        }
    }
}
