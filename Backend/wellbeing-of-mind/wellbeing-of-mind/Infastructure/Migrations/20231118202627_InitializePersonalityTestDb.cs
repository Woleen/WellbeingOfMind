using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wellbeing_of_mind.Migrations
{
    /// <inheritdoc />
    public partial class InitializePersonalityTestDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceWeight = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionContent" },
                values: new object[,]
                {
                    { 1, "How often do you feel nervous or anxious?" },
                    { 2, "Do you have trouble relaxing?" },
                    { 3, "How often do you worry about things that might go wrong?" },
                    { 4, "Do you experience physical symptoms such as trembling, sweating, or a racing heart when anxious?" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceContent", "ChoiceWeight", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Never", -1, 1 },
                    { 2, "Sometimes", 0, 1 },
                    { 3, "Often", 1, 1 },
                    { 4, "Always", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
