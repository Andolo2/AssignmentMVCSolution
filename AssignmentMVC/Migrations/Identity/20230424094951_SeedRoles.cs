using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentMVC.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a39492f-dc70-4823-94ca-2714cebdbc68", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a39492f-dc70-4823-94ca-2714cebdbc68");
        }
    }
}
