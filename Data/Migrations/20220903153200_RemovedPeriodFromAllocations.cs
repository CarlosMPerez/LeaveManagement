using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class RemovedPeriodFromAllocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "8c559373-bfbe-4b5b-9174-466ddab6b135");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "97175a3a-3468-4fcc-9213-ca0d2857a110");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d100de0b-0894-4862-a7d9-b9bff0d827bb", "AQAAAAEAACcQAAAAEPd0wlRxyMQ9h7S/RtprtrQ2nAx/4KK/nKKeBEC7kQGaF5a2myBpRvfGHMWGWtZxtg==", "37769a45-265d-493d-911d-1e056bad3b54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8002abf1-0f3e-49b0-ab30-b39a9cff080b", "AQAAAAEAACcQAAAAEO1qkguxbWDVFkbTeyKV7BLgyiaIqn7XDFp2Qve7vfqc9/2S2Zlg5VNG+nM0lrKWJQ==", "cdd2b831-77b2-4c85-b069-cdc8ee57d859" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
