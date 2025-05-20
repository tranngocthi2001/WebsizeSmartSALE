using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOwebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddKhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "khachhang",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "khachhang",
                newName: "Id");
        }
    }
}
