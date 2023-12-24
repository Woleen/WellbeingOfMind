using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wellbeing_of_mind.Migrations
{
    /// <inheritdoc />
    public partial class addedquestionIdtoallAnswerOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceContent", "ChoiceType", "QuestionId" },
                values: new object[,]
                {
                    { 4, "I do not worry", "No Anxiety", 2 },
                    { 5, "Sometimes", "Mild Anxiety", 2 },
                    { 6, "Almost every day", "Severe Anxiety", 2 },
                    { 7, "I do not worry", "No Anxiety", 3 },
                    { 8, "Sometimes", "Mild Anxiety", 3 },
                    { 9, "Almost every day", "Severe Anxiety", 3 },
                    { 10, "I do not worry", "No Anxiety", 3 },
                    { 11, "Sometimes", "Mild Anxiety", 3 },
                    { 12, "Almost every day", "Severe Anxiety", 3 },
                    { 13, "I do not worry", "No Anxiety", 4 },
                    { 14, "Sometimes", "Mild Anxiety", 4 },
                    { 15, "Almost every day", "Severe Anxiety", 4 },
                    { 16, "I do not worry", "No Anxiety", 5 },
                    { 17, "Sometimes", "Mild Anxiety", 5 },
                    { 18, "Almost every day", "Severe Anxiety", 5 },
                    { 19, "I do not worry", "No Anxiety", 6 },
                    { 20, "Sometimes", "Mild Anxiety", 6 },
                    { 21, "Almost every day", "Severe Anxiety", 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 9);

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

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 21);

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
    }
}
