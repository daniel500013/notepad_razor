using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notepad_razor.Migrations
{
    public partial class dbupdate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Subject", "UserID" },
                values: new object[,]
                {
                    { 1, "Polski", 1 },
                    { 2, "Matematyka", 1 },
                    { 3, "Angielski", 1 },
                    { 4, "Polski", 2 },
                    { 5, "Matematyka", 2 },
                    { 6, "Angielski", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
