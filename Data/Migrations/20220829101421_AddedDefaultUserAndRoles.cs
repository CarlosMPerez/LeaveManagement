using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "5d154af9-ea8f-4c4a-81e4-b266959a2ce4", "Administrator", "ADMINISTRATOR" },
                    { "cac43a7e-f7cb-4148-baaf-1abc431eabbf", "fde891a0-d922-4291-b52c-6663abec9116", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1b43a7e-d3ba-7324-bddf-2cba431baebf", 0, "2fd3981a-c7d1-45d6-a2da-93762dc01616", null, null, "user@firm.com", false, "System", "User", false, null, "USER@FIRM.COM", null, "AQAAAAEAACcQAAAAEJlZqqlEHIKKFk6qZIbdRzAvOCZMQR2dHa1Gl3ir1EHjveHTNKMyf6Mf7mahw2im8A==", null, false, "f723450c-275d-4b29-9c1b-b80604a10105", null, false, null },
                    { "dad43a7e-f3cb-4237-bccf-2abc431baebf", 0, "951e9370-dfcd-4c80-9c09-8edd202c35ff", null, null, "admin@firm.com", false, "System", "Admin", false, null, "ADMIN@FIRM.COM", null, "AQAAAAEAACcQAAAAEFgqlE6lsD5u40v14mFXMfjprZwM8LpK/HD6HGBDKO2KwYsUrFKxgERXNHpkyRgejw==", null, false, "d3a6278e-e884-4d41-827a-631e41d8fb66", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a7e-f7cb-4148-baaf-1abc431eabbf", "b1b43a7e-d3ba-7324-bddf-2cba431baebf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "dad43a7e-f3cb-4237-bccf-2abc431baebf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a7e-f7cb-4148-baaf-1abc431eabbf", "b1b43a7e-d3ba-7324-bddf-2cba431baebf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "dad43a7e-f3cb-4237-bccf-2abc431baebf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf");
        }
    }
}
