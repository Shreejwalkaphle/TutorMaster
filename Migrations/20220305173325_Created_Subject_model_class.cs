using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorMaster.Migrations
{
    public partial class Created_Subject_model_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserWhoGotRated",
                table: "RatingViewModels");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.AddColumn<string>(
                name: "UserWhoGotRated",
                table: "RatingViewModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
