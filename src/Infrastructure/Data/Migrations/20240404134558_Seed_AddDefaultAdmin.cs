using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_AddDefaultAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BlockedOn", "Email", "FullName", "PasswordHash", "Role" },
                values: new object[] { 1L, null, "admin@example.com", null, "$2a$12$f71iOEnNm.M6DiBO2mvWFueeCEyz8FRj6RYD0BSUMkBk58mDNFnTK", 0 });
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
