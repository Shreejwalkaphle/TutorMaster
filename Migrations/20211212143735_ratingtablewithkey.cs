using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorMaster.Migrations
{
    public partial class ratingtablewithkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Communication",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Personality",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Punctuality",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserWhoGotRated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserWhoRated",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RatingViewModels",
                columns: table => new
                {
                    key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserWhoRated = table.Column<string>(nullable: true),
                    UserWhoGotRated = table.Column<string>(nullable: true),
                    Communication = table.Column<int>(nullable: false),
                    Punctuality = table.Column<int>(nullable: false),
                    Personality = table.Column<int>(nullable: false),
                    AverageRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingViewModels", x => x.key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingViewModels");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AverageRating",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Communication",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Personality",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Punctuality",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserWhoGotRated",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserWhoRated",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
