using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("066b1a80-092c-41ef-a69b-a589a1712d8d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c"));

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Models.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("311db9fb-3bb1-4dc9-814c-8cabca0a652a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 158, 135, 10, 199, 169, 129, 234, 11, 230, 242, 184, 39, 9, 118, 48, 113, 149, 163, 78, 230, 81, 227, 69, 132, 102, 212, 7, 85, 133, 235, 82, 144, 62, 77, 179, 81, 109, 44, 71, 16, 152, 43, 203, 194, 226, 100, 12, 198, 162, 127, 97, 15, 243, 203, 78, 60, 60, 12, 237, 104, 251, 165, 91, 64 }, new byte[] { 91, 182, 117, 54, 236, 100, 125, 90, 21, 191, 30, 237, 252, 126, 8, 202, 88, 214, 211, 74, 105, 77, 185, 162, 3, 65, 243, 234, 230, 177, 66, 206, 148, 4, 123, 227, 11, 81, 97, 99, 62, 235, 80, 123, 90, 148, 150, 22, 31, 60, 231, 15, 0, 231, 228, 197, 112, 44, 136, 204, 109, 7, 187, 181, 146, 60, 150, 60, 100, 212, 228, 95, 60, 199, 47, 27, 161, 86, 141, 5, 234, 154, 132, 219, 235, 186, 3, 83, 42, 120, 180, 171, 236, 179, 60, 19, 165, 61, 208, 194, 135, 232, 156, 6, 252, 205, 81, 5, 106, 88, 168, 54, 234, 139, 159, 27, 160, 36, 134, 203, 216, 13, 91, 89, 75, 101, 238, 252 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("24a86e3a-3eba-4698-88a8-596bcb4e3162"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("311db9fb-3bb1-4dc9-814c-8cabca0a652a") });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("24a86e3a-3eba-4698-88a8-596bcb4e3162"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("311db9fb-3bb1-4dc9-814c-8cabca0a652a"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 91, 95, 201, 107, 171, 236, 194, 153, 147, 193, 56, 238, 39, 58, 210, 111, 8, 40, 125, 15, 148, 127, 64, 113, 194, 59, 166, 85, 147, 121, 83, 233, 217, 132, 14, 38, 116, 148, 254, 201, 195, 13, 208, 38, 86, 101, 121, 169, 122, 175, 141, 101, 116, 219, 196, 252, 117, 208, 23, 107, 185, 38, 10, 229 }, new byte[] { 202, 210, 154, 6, 133, 181, 176, 141, 236, 195, 124, 181, 234, 66, 101, 8, 103, 195, 187, 120, 54, 49, 1, 85, 173, 71, 194, 117, 27, 80, 164, 140, 135, 122, 31, 162, 197, 188, 201, 81, 125, 100, 10, 149, 216, 67, 133, 67, 81, 198, 55, 38, 98, 16, 136, 108, 153, 49, 97, 125, 31, 159, 113, 156, 4, 213, 61, 183, 235, 48, 249, 159, 88, 87, 137, 219, 62, 239, 207, 33, 93, 48, 240, 39, 80, 221, 24, 198, 19, 105, 139, 186, 223, 25, 30, 151, 78, 11, 229, 38, 15, 46, 105, 4, 218, 44, 23, 146, 40, 110, 127, 113, 66, 213, 117, 19, 190, 180, 210, 79, 106, 233, 137, 245, 214, 133, 191, 163 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("066b1a80-092c-41ef-a69b-a589a1712d8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0dfbea2d-4703-4751-b1d9-8e00076d977c") });
        }
    }
}
