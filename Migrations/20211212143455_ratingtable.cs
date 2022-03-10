using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorMaster.Migrations
{
    public partial class ratingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AverageRating",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Communication",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Personality",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Punctuality",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserWhoGotRated",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserWhoRated",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
