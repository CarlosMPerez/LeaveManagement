using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedNumerOfDaysToLeaveRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalLeaveDays",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5181c5cb-c2b9-41da-9a24-d4c7f228632c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "30934d23-d97d-41c0-9c20-eedfda590cfc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "473c6272-93f6-4bc8-a06b-6df2606048d9", "AQAAAAEAACcQAAAAEBxdAknMVAyEYcGd8PgwrIf+iVtuCFt8nRDiL6mGMGl1v9FoM6bG6ibSbYotOxxX5w==", "13050009-5c18-4b24-89b4-ba4961899d22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "857af86e-2011-4bdc-8318-8ad900ecd64d", "AQAAAAEAACcQAAAAEB8NNa+WvUOLfGma4eXAp46m6lEe+nzzdqcMflgVSGzJVGvMWr6yPI0KtxZrRHeyzQ==", "1ef0f6ea-1c66-4064-ac0f-9992e3b8486d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalLeaveDays",
                table: "LeaveRequests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "52a74379-528e-4621-8286-f29a0eaca8f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "ea9655a1-5dc7-45ed-b211-f13c6605785b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98ada192-1634-4b50-a7c9-bbb90f24e07e", "AQAAAAEAACcQAAAAEOxAynWDzv6UgAYFTBS+r7xpOGbnfrj6GCgUjcEDyocYgzfRKDyI7k3+jefoWhQsoQ==", "e5baf7c9-92c2-4c18-a6b8-519c090e8756" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afe2d61a-6b08-4dd6-b226-b53a50ceb013", "AQAAAAEAACcQAAAAEEjzW24M1dFOI/vaJf7usev0SeKuh4nqP9CQCCw+Ye6PpB7y/Xo6tTI5/wu0qo20Kw==", "1a6e76bb-203d-4fbf-9d14-025ce6f443dc" });
        }
    }
}
