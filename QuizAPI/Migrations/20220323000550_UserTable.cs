using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserStuffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserStuffID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserStuffID", "UserName", "UserPassword" },
                values: new object[] { 1, "Admin", "Nah" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserStuffID", "UserName", "UserPassword" },
                values: new object[] { 2, "Teacher", "teach" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
