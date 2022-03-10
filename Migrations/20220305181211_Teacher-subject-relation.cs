using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorMaster.Migrations
{
    public partial class Teachersubjectrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "TeacherAndSubject",
                columns: table => new
                {
                    T_S_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(nullable: true),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAndSubject", x => x.T_S_Id);
                    table.ForeignKey(
                        name: "FK_TeacherAndSubject_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherAndSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAndSubject_Id",
                table: "TeacherAndSubject",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAndSubject_SubjectId",
                table: "TeacherAndSubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAndSubject");

            migrationBuilder.CreateTable(
                name: "TeacherAndTheirSubject",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAndTheirSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAndTheirSubject_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAndTheirSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAndTheirSubject_SubjectId",
                table: "TeacherAndTheirSubject",
                column: "SubjectId");
        }
    }
}
