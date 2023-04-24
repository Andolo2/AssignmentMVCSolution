using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentMVC.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedSecondTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a39492f-dc70-4823-94ca-2714cebdbc68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8af42014-4f6e-485d-95e5-9c0129cfe0ac", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a8e9e1c-2b3c-4a1d-b323-2f5d8a5e826c", 0, null, "9cd6ebd4-2d05-420b-95c7-ad38af127ef9", null, false, "System", "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEORLB26SNbl04pSlX6Yg6Lz0J3dYrcpodQdS67Rqb61FWPW9M5rqX/JemiyzbMtOcA==", null, false, null, "eeacfc88-a663-4120-8ad3-f319e808773f", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8af42014-4f6e-485d-95e5-9c0129cfe0ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a8e9e1c-2b3c-4a1d-b323-2f5d8a5e826c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a39492f-dc70-4823-94ca-2714cebdbc68", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
