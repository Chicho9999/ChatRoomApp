using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatRoomApp.Migrations
{
    public partial class addUserIdInMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "3241ad88-ac48-45a0-b1e9-20d1a091ceef");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "e8edc6b0-bcf3-4dba-9bd7-ad4e537226a3");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "14b72866-a053-4a6c-ba88-5cada1e6a7bb", 0, "7d3278d7-d360-46da-8851-b65bb88e98cf", "test@test.com", false, false, null, "test@test.com", "test", "AQAAAAEAACcQAAAAECwiWNiCiKHn7ORHiLF9sBj4bbBhosO3/9YDkHunBCT6JroGRnYm1wqqcxlW+vAilg==", null, false, "3bbc0e0a-2469-4d6e-9675-ee7f873c558b", false, "test" },
                    { "aff888df-3895-4a14-b349-605a3d47d15a", 0, "f98a9f37-ae12-46dc-8c5b-a55a3e801604", "admin@admin.com", false, false, null, "admin@admin.com", "admin", "AQAAAAEAACcQAAAAEJo66BFGcEjznSYwP27eKc+UqKenH09/0IzxVRjDfxWmiDDP9e9k7D0uc7GLPYTmmQ==", null, false, "8c8c29e0-4367-40d8-98d2-1fc9b7ab4f71", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 7, 6, 20, 48, 39, 893, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 7, 6, 20, 48, 39, 893, DateTimeKind.Local).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 7, 6, 20, 48, 39, 893, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "14b72866-a053-4a6c-ba88-5cada1e6a7bb");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aff888df-3895-4a14-b349-605a3d47d15a");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3241ad88-ac48-45a0-b1e9-20d1a091ceef", 0, "27f414eb-ec8d-4572-89d3-e6657dcc7ed0", "test@test.com", false, false, null, "test@test.com", "test", "AQAAAAEAACcQAAAAEPnqCPC82uE5iH769uJ2yvUQfQS/rn70dMKsQcB/lyMKT5d60A1TPvieNbcqzRjJrA==", null, false, "c8203551-af53-423f-9f81-966ab1d2a320", false, "test" },
                    { "e8edc6b0-bcf3-4dba-9bd7-ad4e537226a3", 0, "e2c6a3af-d588-4b33-8e46-496ca8d16be5", "admin@admin.com", false, false, null, "admin@admin.com", "admin", "AQAAAAEAACcQAAAAEACs3NFATTageAgxg9JK84sHuG/yU/xpd4hjNjvDrhAD0guJ+3gxLBFcYxJyoAzWpw==", null, false, "6f8e2e38-b4fa-44bd-a4e9-2078ee00a1a5", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 29, 15, 11, 45, 427, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 29, 15, 11, 45, 427, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 29, 15, 11, 45, 427, DateTimeKind.Local).AddTicks(1070));
        }
    }
}
