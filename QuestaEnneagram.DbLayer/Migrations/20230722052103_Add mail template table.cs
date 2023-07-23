using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestaEnneagram.DbLayer.Migrations
{
    public partial class Addmailtemplatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mstMailTemplate",
                columns: table => new
                {
                    MailTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMTP_SenderNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SMTP_USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTP_PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONFIGSET = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FromMailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BCCMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOST = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PORT = table.Column<int>(type: "int", nullable: false),
                    BODY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstMailTemplate", x => x.MailTemplateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstMailTemplate");
        }
    }
}
