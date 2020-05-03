using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Repository.Migrations
{
    public partial class SeedDataStudentSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "FirstName", "LastName", "MiddleInitial" },
                values: new object[,]
                {
                    { new Guid("90997e95-52e2-4eb8-a70a-b2f3d6711ef3"), 37, "Maheraj", "Thakur", null },
                    { new Guid("59a13bb7-7de9-4533-83bf-072e3ad37af3"), 42, "Sachin", "Tendulkar", null },
                    { new Guid("9c1d8ac1-5b3f-4429-b331-39365b09ed8a"), 27, "Virat", "Kohli", null }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("b1306a81-4a93-4ed5-b8c7-b04aeb02c68c"), ".Net Core" },
                    { new Guid("e4ede75e-9c39-45b2-b484-6f825defd26d"), "Data Structure" },
                    { new Guid("4d299076-c69b-4bd0-8ee3-58303c90aedc"), "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "StudentDetailId", "AdditionalInformation", "Address", "StudentId" },
                values: new object[] { new Guid("1fac2ab4-4237-40f6-baad-6042ab5495e2"), null, "Some Street", new Guid("90997e95-52e2-4eb8-a70a-b2f3d6711ef3") });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "StudentDetailId", "AdditionalInformation", "Address", "StudentId" },
                values: new object[] { new Guid("8c03177f-9c73-489a-ace8-604ae967c0c9"), null, "Mumbai", new Guid("59a13bb7-7de9-4533-83bf-072e3ad37af3") });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "StudentDetailId", "AdditionalInformation", "Address", "StudentId" },
                values: new object[] { new Guid("c2ad9a45-973d-4add-b2dd-65ef7041f397"), null, "Delhi", new Guid("9c1d8ac1-5b3f-4429-b331-39365b09ed8a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("1fac2ab4-4237-40f6-baad-6042ab5495e2"));

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("8c03177f-9c73-489a-ace8-604ae967c0c9"));

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("c2ad9a45-973d-4add-b2dd-65ef7041f397"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("4d299076-c69b-4bd0-8ee3-58303c90aedc"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("b1306a81-4a93-4ed5-b8c7-b04aeb02c68c"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("e4ede75e-9c39-45b2-b484-6f825defd26d"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("59a13bb7-7de9-4533-83bf-072e3ad37af3"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("90997e95-52e2-4eb8-a70a-b2f3d6711ef3"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("9c1d8ac1-5b3f-4429-b331-39365b09ed8a"));
        }
    }
}
