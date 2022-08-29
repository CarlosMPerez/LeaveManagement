using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedMissingFieldsInUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "55dc9097-aaa5-47e8-bfba-1fa4b9855488");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "a8d203ce-5dc2-49d2-93e0-8af8c8af304c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "be43ce60-b8e0-4769-adc5-a10ab2ced78a", true, "USER@FIRM.COM", "AQAAAAEAACcQAAAAEM8FtJ1ypczDPI65PBimSiSuXXS9Sov/DnIwqniJmTGGGbV9Z+7XSsfTh3jUmldAAw==", "81c7a6a5-3f67-4edc-af1d-19c1bf1a615b", "user@firm.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "464fa45b-37d9-4ba7-88fa-ead71d929e28", true, "ADMIN@FIRM.COM", "AQAAAAEAACcQAAAAELL0oBpTNPxDOMBhidxSFNsGJRyx9OdQ1IaI39/6gF6UaNlxcwwACv5vLkQZEQtfSw==", "e365fa41-b6b3-4518-a6aa-786e9af39e73", "admin@firm.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5d154af9-ea8f-4c4a-81e4-b266959a2ce4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "fde891a0-d922-4291-b52c-6663abec9116");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2fd3981a-c7d1-45d6-a2da-93762dc01616", false, null, "AQAAAAEAACcQAAAAEJlZqqlEHIKKFk6qZIbdRzAvOCZMQR2dHa1Gl3ir1EHjveHTNKMyf6Mf7mahw2im8A==", "f723450c-275d-4b29-9c1b-b80604a10105", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "951e9370-dfcd-4c80-9c09-8edd202c35ff", false, null, "AQAAAAEAACcQAAAAEFgqlE6lsD5u40v14mFXMfjprZwM8LpK/HD6HGBDKO2KwYsUrFKxgERXNHpkyRgejw==", "d3a6278e-e884-4d41-827a-631e41d8fb66", null });
        }
    }
}
