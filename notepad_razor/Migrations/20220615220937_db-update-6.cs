using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notepad_razor.Migrations
{
    public partial class dbupdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserClass",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "NickName", "Password", "Permission", "UserClass" },
                values: new object[] { 1, "user@user.com", "AQAAAAEAACcQAAAAEIPml6EhNHdTF/UFC00wwnH+Do5mwU1UCpl1Y9EERknTH8LE1a5gg7DVk7yj+LQt5g==", "user", "user", "User", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "NickName", "Password", "Permission", "UserClass" },
                values: new object[] { 2, "admin@admin.com", "AQAAAAEAACcQAAAAEENAYcFrj25u9tzx+88HZpIpOBXVKV/LZb0clSVOE1fXy2hA++svzwO3jnjb3Wstxw==", "admin", "admin", "Admin", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UserClass",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
