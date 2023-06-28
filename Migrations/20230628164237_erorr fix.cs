using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Students_APP.Migrations
{
    /// <inheritdoc />
    public partial class erorrfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentGuid",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Groups_GroupId",
                table: "StudentGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroup_Students_StudentGuid",
                table: "StudentGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "StudentGroup",
                newName: "StudentGroups");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroup_GroupId",
                table: "StudentGroups",
                newName: "IX_StudentGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups",
                columns: new[] { "StudentGuid", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentGuid", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentGuid",
                table: "StudentCourses",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Groups_GroupId",
                table: "StudentGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroups_Students_StudentGuid",
                table: "StudentGroups",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentGuid",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Groups_GroupId",
                table: "StudentGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroups_Students_StudentGuid",
                table: "StudentGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentGroups",
                newName: "StudentGroup");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourse");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroups_GroupId",
                table: "StudentGroup",
                newName: "IX_StudentGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup",
                columns: new[] { "StudentGuid", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                columns: new[] { "StudentGuid", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseId",
                table: "StudentCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentGuid",
                table: "StudentCourse",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Groups_GroupId",
                table: "StudentGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroup_Students_StudentGuid",
                table: "StudentGroup",
                column: "StudentGuid",
                principalTable: "Students",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
