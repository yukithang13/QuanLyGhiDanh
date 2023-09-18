using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyGhiDanh.Migrations
{
    public partial class UpdateLopHoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HocVienIdHocVien",
                table: "LopHocs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHocVien",
                table: "LopHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_HocVienIdHocVien",
                table: "LopHocs",
                column: "HocVienIdHocVien");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocs_HocViens_HocVienIdHocVien",
                table: "LopHocs",
                column: "HocVienIdHocVien",
                principalTable: "HocViens",
                principalColumn: "IdHocVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocs_HocViens_HocVienIdHocVien",
                table: "LopHocs");

            migrationBuilder.DropIndex(
                name: "IX_LopHocs_HocVienIdHocVien",
                table: "LopHocs");

            migrationBuilder.DropColumn(
                name: "HocVienIdHocVien",
                table: "LopHocs");

            migrationBuilder.DropColumn(
                name: "IdHocVien",
                table: "LopHocs");
        }
    }
}
