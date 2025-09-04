using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yaghane360.Migrations.ZeytinTakipDB
{
    /// <inheritdoc />
    public partial class GiderEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KasaGider",
                columns: table => new
                {
                    KasaGiderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaID = table.Column<int>(type: "int", nullable: false),
                    MusteriID = table.Column<int>(type: "int", nullable: true),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiderTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IslemiYapanKisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasaGider", x => x.KasaGiderID);
                    table.ForeignKey(
                        name: "FK_KasaGider_Kasalar_KasaID",
                        column: x => x.KasaID,
                        principalTable: "Kasalar",
                        principalColumn: "KasaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KasaGider_Musteriler_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KasaGider_KasaID",
                table: "KasaGider",
                column: "KasaID");

            migrationBuilder.CreateIndex(
                name: "IX_KasaGider_MusteriID",
                table: "KasaGider",
                column: "MusteriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KasaGider");
        }
    }
}
