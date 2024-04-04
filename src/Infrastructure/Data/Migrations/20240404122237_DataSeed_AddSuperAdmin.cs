﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed_AddSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BlockedOn", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[] { 1L, null, "su@example.com", "Super Admin", "$2a$12$cyddlq4JXaEROGif0epD4OuQVeGcv01S3fUSlN0xiUMA0qG0AZQ2m", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
