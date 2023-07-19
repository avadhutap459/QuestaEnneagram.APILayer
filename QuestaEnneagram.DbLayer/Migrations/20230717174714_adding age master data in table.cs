using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class addingagemasterdataintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "mstAge",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "mstAge",
                columns: new[] { "AgeId", "AgeName" },
                values: new object[,]
                {
                    { 1, "18-21" },
                    { 2, "22-24" },
                    { 3, "25-34" },
                    { 4, "35-44" },
                    { 5, "45-54" },
                    { 6, "55-64" },
                    { 7, "65-74" },
                    { 8, "75 and above" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "mstAge",
                keyColumn: "AgeId",
                keyValue: 8);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "mstAge",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
