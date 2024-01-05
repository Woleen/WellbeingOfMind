using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wellbeing_of_mind.Migrations
{
    /// <inheritdoc />
    public partial class ChangingAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChoiceContent",
                value: "One-two time");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChoiceContent",
                value: "Few times");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChoiceContent",
                value: "No, I do not");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 13,
                column: "ChoiceContent",
                value: "No, I do not");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 19,
                column: "ChoiceContent",
                value: "I do not");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChoiceContent",
                value: "I do not worry");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2,
                column: "ChoiceContent",
                value: "Sometimes");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChoiceContent",
                value: "I do not worry");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 13,
                column: "ChoiceContent",
                value: "I do not worry");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 19,
                column: "ChoiceContent",
                value: "I do not worry");

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceContent", "ChoiceType", "QuestionId" },
                values: new object[,]
                {
                    { 10, "I do not worry", "No Anxiety", 3 },
                    { 11, "Sometimes", "Mild Anxiety", 3 },
                    { 12, "Almost every day", "Severe Anxiety", 3 }
                });
        }
    }
}
