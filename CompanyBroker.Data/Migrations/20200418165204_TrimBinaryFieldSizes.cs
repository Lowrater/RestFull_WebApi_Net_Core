using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyBroker.Data.Migrations
{
    public partial class TrimBinaryFieldSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Accounts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Accounts",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Accounts",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 32,
                oldNullable: true);
        }
    }
}
