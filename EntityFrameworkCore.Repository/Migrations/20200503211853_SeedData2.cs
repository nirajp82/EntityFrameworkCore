using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Repository.Migrations
{
    public partial class SeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Student_StudentId",
                table: "Evaluation");

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

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "Age", "FirstName", "LastName", "MiddleInitial" },
                values: new object[,]
                {
                    { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), 37, "Maheraj", "Thakur", null },
                    { new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"), 42, "Sachin", "Tendulkar", "R" },
                    { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), 27, "Virat", "Kohli", null }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("a6995838-c28a-4289-bf49-36e5bbb434da"), ".Net Core" },
                    { new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4"), "Data Structure" },
                    { new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80"), "SQL Server" },
                    { new Guid("338b66ab-bbd4-4249-9490-6c8ff6066872"), "MS Azure" }
                });

            migrationBuilder.InsertData(
                table: "Evaluation",
                columns: new[] { "EvaluationId", "AdditionalExplanation", "Grade", "StudentId" },
                values: new object[,]
                {
                    { new Guid("18bb3e4d-1a1f-4f6f-ba6e-98a75f0833d1"), "Excellent", 12, new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019") },
                    { new Guid("0b2282ed-9034-4b7c-a275-f0c56f996972"), "Outstanding", 11, new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019") },
                    { new Guid("57313a49-f614-4e5b-82c1-cf3d51802ad0"), "Very good", 12, new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019") },
                    { new Guid("acd9b7ea-ee00-46e1-8bf0-e4ce0ea91854"), "Satisfactory", 11, new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2") }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "StudentDetailId", "AdditionalInformation", "Address", "StudentId" },
                values: new object[,]
                {
                    { new Guid("27bd8475-243e-4bde-9547-f6997d4c1428"), null, "Some Street", new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019") },
                    { new Guid("ec50e4a9-1f59-4eb9-90a0-fc57b9de1c37"), null, "Mumbai", new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2") },
                    { new Guid("6214ddb0-ae76-43f7-b15a-0f8cb72c322d"), null, "Delhi", new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3") }
                });

            migrationBuilder.InsertData(
                table: "StudentSubject",
                columns: new[] { "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") },
                    { new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") },
                    { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") },
                    { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") },
                    { new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") },
                    { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") },
                    { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80") },
                    { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80") },
                    { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("338b66ab-bbd4-4249-9490-6c8ff6066872") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Student_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Student_StudentId",
                table: "Evaluation");

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("0b2282ed-9034-4b7c-a275-f0c56f996972"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("18bb3e4d-1a1f-4f6f-ba6e-98a75f0833d1"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("57313a49-f614-4e5b-82c1-cf3d51802ad0"));

            migrationBuilder.DeleteData(
                table: "Evaluation",
                keyColumn: "EvaluationId",
                keyValue: new Guid("acd9b7ea-ee00-46e1-8bf0-e4ce0ea91854"));

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("27bd8475-243e-4bde-9547-f6997d4c1428"));

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("6214ddb0-ae76-43f7-b15a-0f8cb72c322d"));

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "StudentDetailId",
                keyValue: new Guid("ec50e4a9-1f59-4eb9-90a0-fc57b9de1c37"));

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("338b66ab-bbd4-4249-9490-6c8ff6066872") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"), new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("a6995838-c28a-4289-bf49-36e5bbb434da") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4") });

            migrationBuilder.DeleteData(
                table: "StudentSubject",
                keyColumns: new[] { "StudentId", "SubjectId" },
                keyValues: new object[] { new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"), new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80") });

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("1cef5f29-1e44-45e7-a07c-6acc8cab1df2"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("561bc65c-b946-434d-95f0-6edb75b40ee3"));

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: new Guid("f85ae61f-d8da-4c89-8e9d-eee890747019"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("338b66ab-bbd4-4249-9490-6c8ff6066872"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("a6995838-c28a-4289-bf49-36e5bbb434da"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("ab3a76fe-03ba-4769-a49f-577511738fa4"));

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: new Guid("b1ca8d94-5426-49eb-9068-791885ad3e80"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Student_StudentId",
                table: "Evaluation",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
