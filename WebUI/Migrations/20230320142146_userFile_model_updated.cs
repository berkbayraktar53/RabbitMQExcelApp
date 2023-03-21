using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class UserFile_model_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileStatus",
                table: "UserFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileStatus",
                table: "UserFiles");
        }
    }
}
