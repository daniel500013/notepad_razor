using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notepad_razor.Migrations
{
    public partial class dbupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_UserModelId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_UserModelId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Subjects");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserClass",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserClass",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UserModelId",
                table: "Subjects",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_UserModelId",
                table: "Subjects",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
