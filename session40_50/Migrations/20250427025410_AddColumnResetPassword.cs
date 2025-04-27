using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace session40_50.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresTokenReset",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenResetPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresTokenReset",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenResetPassword",
                table: "Users");
        }
    }
}
