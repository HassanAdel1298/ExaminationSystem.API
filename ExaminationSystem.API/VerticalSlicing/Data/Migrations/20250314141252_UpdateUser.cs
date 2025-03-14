using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.API.VerticalSlicing.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Instructors_InstructorID",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswerQuestions_Students_StudentID",
                table: "studentAnswerQuestions");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_InstructorID",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Quizzes");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswerQuestions_Users_StudentID",
                table: "studentAnswerQuestions",
                column: "StudentID",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentAnswerQuestions_Users_StudentID",
                table: "studentAnswerQuestions");

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_InstructorID",
                table: "Quizzes",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId1",
                table: "Instructors",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId1",
                table: "Students",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Instructors_InstructorID",
                table: "Quizzes",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_studentAnswerQuestions_Students_StudentID",
                table: "studentAnswerQuestions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
