using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cv_melon1.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    fileName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.fileName);
                });

           

            migrationBuilder.CreateTable(
                name: "StudyPlace",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVfileName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlace", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudyPlace_CV_CVfileName",
                        column: x => x.CVfileName,
                        principalTable: "CV",
                        principalColumn: "fileName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingPlace",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVfileName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingPlace", x => x.id);
                    table.ForeignKey(
                        name: "FK_WorkingPlace_CV_CVfileName",
                        column: x => x.CVfileName,
                        principalTable: "CV",
                        principalColumn: "fileName",
                        onDelete: ReferentialAction.Restrict);
                });



            migrationBuilder.CreateIndex(
                name: "IX_StudyPlace_CVfileName",
                table: "StudyPlace",
                column: "CVfileName");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingPlace_CVfileName",
                table: "WorkingPlace",
                column: "CVfileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "StudyPlace");

            migrationBuilder.DropTable(
                name: "WorkingPlace");

            migrationBuilder.DropTable(
                name: "CV");
        }
    }
}
