using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizAPI.Migrations
{
    public partial class Hope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassP = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.QuizId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTopic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Questions_quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "QuizId", "CreatorName", "PassP", "QuizTitle", "QuizTopic" },
                values: new object[] { 1, "Brom", 60f, "Maths", "Maths" });

            migrationBuilder.InsertData(
                table: "quizzes",
                columns: new[] { "QuizId", "CreatorName", "PassP", "QuizTitle", "QuizTopic" },
                values: new object[] { 2, "Mr Mokey", 20f, "English", "English" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "QuestionImg", "QuestionText", "QuestionTopic", "QuizId" },
                values: new object[,]
                {
                    { 1, null, "What's 1+1", "Math", 1 },
                    { 2, null, "What's 2+2", "Math", 1 },
                    { 3, null, "What's 3+3", "Math", 1 },
                    { 4, null, "WHaat does monkey mean", "English", 2 },
                    { 5, null, "What does Word mean", "English", 2 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionID", "IsCorrect", "OptionLetter", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, false, "A", "999", 1 },
                    { 18, true, "B", "word", 5 },
                    { 17, false, "A", "Banna", 5 },
                    { 16, false, "D", "42", 4 },
                    { 15, false, "C", "876543245678", 4 },
                    { 14, true, "B", "Monkey", 4 },
                    { 13, false, "A", "Banna", 4 },
                    { 12, false, "D", "42", 3 },
                    { 11, false, "C", "876543245678", 3 },
                    { 10, true, "B", "6", 3 },
                    { 9, false, "A", "Banna", 3 },
                    { 8, false, "D", "42", 2 },
                    { 7, false, "C", "876543245678", 2 },
                    { 6, true, "B", "4", 2 },
                    { 5, false, "A", "Banna", 2 },
                    { 4, true, "D", "2", 1 },
                    { 3, false, "C", "777", 1 },
                    { 2, false, "B", "69", 1 },
                    { 19, false, "C", "876543245678", 5 },
                    { 20, false, "D", "42", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "quizzes");
        }
    }
}
