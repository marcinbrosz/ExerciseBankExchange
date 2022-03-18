using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseBankExchange.Migrations
{
    public partial class PopulateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "SaldoPl", "UserId" },
                values: new object[] { 1, 1000f, 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "SaldoPl", "UserId" },
                values: new object[] { 2, 500f, 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "SaldoPl", "UserId" },
                values: new object[] { 3, 1200f, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
