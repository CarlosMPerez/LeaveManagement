using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class LeaveRequestCommentsCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "1fd0e801-2e1b-483f-b316-272ba80b1c2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "8b3374ff-7419-4f22-814b-20d8a82ebfd1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdf19219-bdb3-44e7-b6b1-442f88eb12ad", "AQAAAAEAACcQAAAAEGFfQ2AJN5qpm3w20pDdl2kyt/Fp81A9twipLa+62t2RSgiBmL4hEStQ79nWRw6bWg==", "e681c3bc-d1ae-4598-b733-b623639912e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e549cf5-3504-46c0-9d8d-67ab003c3857", "AQAAAAEAACcQAAAAEL6GEO7kSf+9qySk4BiQLCcRY+hYCMMhMEWavWVNbGBjEtdcjrxpB21R1j+eqYmVXQ==", "2ae867f6-e630-4d57-81df-63ac4360c7e2" });
        }
    }
}
