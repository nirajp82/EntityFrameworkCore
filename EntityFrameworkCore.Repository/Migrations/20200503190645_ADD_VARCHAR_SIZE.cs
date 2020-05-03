using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Repository.Migrations
{
    public partial class ADD_VARCHAR_SIZE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MiddleInitial",
                table: "Students",
                type: "VARCHAR(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StudentDetail",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInformation",
                table: "StudentDetail",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 150,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MiddleInitial",
                table: "Students",
                type: "VARCHAR",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Students",
                type: "VARCHAR",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "VARCHAR",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StudentDetail",
                type: "VARCHAR",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalInformation",
                table: "StudentDetail",
                type: "VARCHAR",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
