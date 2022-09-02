using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class EmployeeFKOnLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveAllocations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "86b781c8-f7ab-407d-b4a9-97679f25a841");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "f297507b-7e13-4a03-a956-34f48b1c566b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0f63f33-19e7-4649-9833-c1ce6d065cea", "AQAAAAEAACcQAAAAECRBwPA2J5cR9DGF1x2gio12al+ux9sDpyHlSD+MI09UVUR6ij14JIJoIkCNbbf2ng==", "cefbcc9e-2a8f-4d01-9b17-0656bf230376" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62a5ce39-f632-490a-99ec-6982df81c2eb", "AQAAAAEAACcQAAAAEJazM2QUMJsuwtETNa/UHksylQpHdYd468MyQpHQmUO4ndlWL07Ra8nAKwXBAIa2Kg==", "8374b48b-53e6-4f96-95ef-b8481b3c0a08" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                table: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveAllocations_EmployeeId",
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
                value: "a2b65a32-2efd-4505-accb-e6153e1af118");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "5f3eb644-270a-4a3e-a01b-67983d3ea043");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca9a959b-2ec6-4957-8380-0cc1d07672eb", "AQAAAAEAACcQAAAAEEVAhbusjAYMaJmFnoeXGVYM+sf0dkJLpm62rblQd0009WLC+t2WehwYZ4Mz700Ohw==", "11c32d52-aec8-4589-9528-b3fe5b8582d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c71b03db-4a84-4d40-8d98-0e48d5ebc1b1", "AQAAAAEAACcQAAAAEN6s0qEILaV3Luxqg2eCy8/BIZGebyS2E2RHSFO50i61w8hZVmZFa31RvrUbi/mwXQ==", "bd8b4b6b-7265-4fcc-9e4a-b735b1ba3c91" });
        }
    }
}
