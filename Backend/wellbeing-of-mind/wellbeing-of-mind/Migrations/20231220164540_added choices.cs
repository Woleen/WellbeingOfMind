using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wellbeing_of_mind.Migrations
{
    /// <inheritdoc />
    public partial class addedchoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceContent", "ChoiceType", "QuestionId" },
                values: new object[,]
                {
                    { 1, "I do not worry", "No Anxiety", 1 },
                    { 2, "Sometimes", "Mild Anxiety", 1 },
                    { 3, "Almost every day", "Severe Anxiety", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
