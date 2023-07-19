using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class AddedSubTypeIdforeignkeyinresponsetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "mstQuestionResponse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_mstQuestionResponse_SubTypeId",
                table: "mstQuestionResponse",
                column: "SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_mstQuestionResponse_mstQuestionSubType_SubTypeId",
                table: "mstQuestionResponse",
                column: "SubTypeId",
                principalTable: "mstQuestionSubType",
                principalColumn: "SubTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mstQuestionResponse_mstQuestionSubType_SubTypeId",
                table: "mstQuestionResponse");

            migrationBuilder.DropIndex(
                name: "IX_mstQuestionResponse_SubTypeId",
                table: "mstQuestionResponse");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "mstQuestionResponse");
        }
    }
}
