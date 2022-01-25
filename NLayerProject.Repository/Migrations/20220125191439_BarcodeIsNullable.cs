using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerProject.Repository.Migrations
{
    public partial class BarcodeIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 25, 19, 14, 38, 792, DateTimeKind.Utc).AddTicks(6917));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 1, 23, 14, 32, 10, 677, DateTimeKind.Utc).AddTicks(2083));
        }
    }
}
