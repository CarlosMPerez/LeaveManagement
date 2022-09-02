using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
        }
    }
}
