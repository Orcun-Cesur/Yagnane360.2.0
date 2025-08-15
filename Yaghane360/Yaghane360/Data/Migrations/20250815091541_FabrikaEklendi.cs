using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yaghane360.Migrations
{
    /// <inheritdoc />
    public partial class FabrikaEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FabrikaAdi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FabrikaID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FabrikaAdi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FabrikaID",
                table: "AspNetUsers");
        }
    }
}
