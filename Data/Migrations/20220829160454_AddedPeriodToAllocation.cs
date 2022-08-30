using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be43ce60-b8e0-4769-adc5-a10ab2ced78a", "AQAAAAEAACcQAAAAEM8FtJ1ypczDPI65PBimSiSuXXS9Sov/DnIwqniJmTGGGbV9Z+7XSsfTh3jUmldAAw==", "81c7a6a5-3f67-4edc-af1d-19c1bf1a615b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "464fa45b-37d9-4ba7-88fa-ead71d929e28", "AQAAAAEAACcQAAAAELL0oBpTNPxDOMBhidxSFNsGJRyx9OdQ1IaI39/6gF6UaNlxcwwACv5vLkQZEQtfSw==", "e365fa41-b6b3-4518-a6aa-786e9af39e73" });
        }
    }
}
