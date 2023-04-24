using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentMVC.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "54aa71ed-38ff-4a40-8ee9-f6934978e29c", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c2137672-6c1f-4b17-a032-3e66fcb02006", 0, null, "d1778991-6754-479f-b9f3-8b64cff9195c", "administrator@gmail.com", false, " ", " ", false, null, null, null, "AQAAAAIAAYagAAAAEPk/E4mtLoEtaeA+VSceelUf8WlEQyfhwiF6sFR37z4WmT/HoLdpBYDWzYRFZWe95Q==", null, false, null, "39857fb1-a033-43e7-a6fb-792606d2b67f", false, "administrator@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "54aa71ed-38ff-4a40-8ee9-f6934978e29c", "c2137672-6c1f-4b17-a032-3e66fcb02006" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54aa71ed-38ff-4a40-8ee9-f6934978e29c", "c2137672-6c1f-4b17-a032-3e66fcb02006" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54aa71ed-38ff-4a40-8ee9-f6934978e29c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2137672-6c1f-4b17-a032-3e66fcb02006");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8af42014-4f6e-485d-95e5-9c0129cfe0ac", null, "System Administrator", "SYSTEM ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyName", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a8e9e1c-2b3c-4a1d-b323-2f5d8a5e826c", 0, null, "9cd6ebd4-2d05-420b-95c7-ad38af127ef9", null, false, "System", "Administrator", false, null, null, null, "AQAAAAIAAYagAAAAEORLB26SNbl04pSlX6Yg6Lz0J3dYrcpodQdS67Rqb61FWPW9M5rqX/JemiyzbMtOcA==", null, false, null, "eeacfc88-a663-4120-8ad3-f319e808773f", false, "administrator" });
        }
    }
}
