using Microsoft.EntityFrameworkCore.Migrations;

namespace cv_melon1.Data.Migrations
{
    public partial class RandomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlace_CV_CVfileName",
                table: "StudyPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingPlace_CV_CVfileName",
                table: "WorkingPlace");

            migrationBuilder.RenameColumn(
                name: "CVfileName",
                table: "WorkingPlace",
                newName: "CVid");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingPlace_CVfileName",
                table: "WorkingPlace",
                newName: "IX_WorkingPlace_CVid");

            migrationBuilder.RenameColumn(
                name: "CVfileName",
                table: "StudyPlace",
                newName: "CVid");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPlace_CVfileName",
                table: "StudyPlace",
                newName: "IX_StudyPlace_CVid");

            migrationBuilder.RenameColumn(
                name: "fileName",
                table: "CV",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlace_CV_CVid",
                table: "StudyPlace",
                column: "CVid",
                principalTable: "CV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingPlace_CV_CVid",
                table: "WorkingPlace",
                column: "CVid",
                principalTable: "CV",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyPlace_CV_CVid",
                table: "StudyPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingPlace_CV_CVid",
                table: "WorkingPlace");

            migrationBuilder.RenameColumn(
                name: "CVid",
                table: "WorkingPlace",
                newName: "CVfileName");

            migrationBuilder.RenameIndex(
                name: "IX_WorkingPlace_CVid",
                table: "WorkingPlace",
                newName: "IX_WorkingPlace_CVfileName");

            migrationBuilder.RenameColumn(
                name: "CVid",
                table: "StudyPlace",
                newName: "CVfileName");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPlace_CVid",
                table: "StudyPlace",
                newName: "IX_StudyPlace_CVfileName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CV",
                newName: "fileName");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPlace_CV_CVfileName",
                table: "StudyPlace",
                column: "CVfileName",
                principalTable: "CV",
                principalColumn: "fileName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingPlace_CV_CVfileName",
                table: "WorkingPlace",
                column: "CVfileName",
                principalTable: "CV",
                principalColumn: "fileName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
