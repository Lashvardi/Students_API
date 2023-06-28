using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students_APP.Migrations
{
    /// <inheritdoc />
    public partial class projects1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalProject_Courses_CourseId",
                table: "FinalProject");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalProject_Students_StudentGuid",
                table: "FinalProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalProject",
                table: "FinalProject");

            migrationBuilder.RenameTable(
                name: "FinalProject",
                newName: "FinalProjects");

            migrationBuilder.RenameIndex(
                name: "IX_FinalProject_StudentGuid",
                table: "FinalProjects",
                newName: "IX_FinalProjects_StudentGuid");

            migrationBuilder.RenameIndex(
                name: "IX_FinalProject_CourseId",
                table: "FinalProjects",
                newName: "IX_FinalProjects_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalProjects",
                table: "FinalProjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalProjects_Courses_CourseId",
                table: "FinalProjects",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalProjects_Students_StudentGuid",
                table: "FinalProjects",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalProjects_Courses_CourseId",
                table: "FinalProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalProjects_Students_StudentGuid",
                table: "FinalProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalProjects",
                table: "FinalProjects");

            migrationBuilder.RenameTable(
                name: "FinalProjects",
                newName: "FinalProject");

            migrationBuilder.RenameIndex(
                name: "IX_FinalProjects_StudentGuid",
                table: "FinalProject",
                newName: "IX_FinalProject_StudentGuid");

            migrationBuilder.RenameIndex(
                name: "IX_FinalProjects_CourseId",
                table: "FinalProject",
                newName: "IX_FinalProject_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalProject",
                table: "FinalProject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalProject_Courses_CourseId",
                table: "FinalProject",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalProject_Students_StudentGuid",
                table: "FinalProject",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid");
        }
    }
}
