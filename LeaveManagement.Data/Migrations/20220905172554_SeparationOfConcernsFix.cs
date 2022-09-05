using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Data.Migrations
{
    public partial class SeparationOfConcernsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "e9d333e5-c33f-4284-96e5-84821ac4cb0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a7e-f7cb-4148-baaf-1abc431eabbf",
                column: "ConcurrencyStamp",
                value: "d3252689-2d24-414c-9eae-20189c5cd7ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1b43a7e-d3ba-7324-bddf-2cba431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6348b22a-fedc-4d3b-a556-ac2bac639d0f", "AQAAAAEAACcQAAAAEGN7KNHUVs8hVOF3RdXFCXMVI5Xn9AwyWObkP0magcrYm+q9/3oSTUpA3ecYL2sGeQ==", "d7870699-c4f3-45e7-bd5b-e0f93fcd5462" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dad43a7e-f3cb-4237-bccf-2abc431baebf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d196eb1-aa07-4b22-889f-67c8b4a1f29f", "AQAAAAEAACcQAAAAEFG8ghzNa+QsQo/CEeOjS2aiXycnPHMnY4fJY1GoFl1hWueNRG/1oMOvc+9c13GZoA==", "b3b7084c-b600-4a19-a521-68ccf2ccbd1b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
