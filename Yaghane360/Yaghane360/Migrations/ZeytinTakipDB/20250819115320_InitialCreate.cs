using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yaghane360.Migrations.ZeytinTakipDB
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kasalar",
                columns: table => new
                {
                    KasaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kasalar", x => x.KasaID);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    MusteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bolge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokYag = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StokZeytin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZeytinHacim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YagHacim = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.MusteriID);
                });

            migrationBuilder.CreateTable(
                name: "Boxlar",
                columns: table => new
                {
                    BoxID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MusteriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxlar", x => x.BoxID);
                    table.ForeignKey(
                        name: "FK_Boxlar_Musteriler_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID");
                });

            migrationBuilder.CreateTable(
                name: "KasaIslemleri",
                columns: table => new
                {
                    KasaIslemNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaID = table.Column<int>(type: "int", nullable: false),
                    KasaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IslemiYapanKisi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasaIslemleri", x => x.KasaIslemNo);
                    table.ForeignKey(
                        name: "FK_KasaIslemleri_Kasalar_KasaID",
                        column: x => x.KasaID,
                        principalTable: "Kasalar",
                        principalColumn: "KasaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KasaIslemleri_Musteriler_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    IslemNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriID = table.Column<int>(type: "int", nullable: true),
                    ZeytinKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TarihGirdi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BoxID = table.Column<int>(type: "int", nullable: true),
                    YagKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TarihCikti = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IslemDurum = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.IslemNo);
                    table.ForeignKey(
                        name: "FK_Urunler_Boxlar_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Boxlar",
                        principalColumn: "BoxID");
                    table.ForeignKey(
                        name: "FK_Urunler_Musteriler_MusteriID",
                        column: x => x.MusteriID,
                        principalTable: "Musteriler",
                        principalColumn: "MusteriID");
                });

            migrationBuilder.CreateTable(
                name: "Makineler",
                columns: table => new
                {
                    MachineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IslemNo = table.Column<int>(type: "int", nullable: true),
                    ZamanSayaci = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makineler", x => x.MachineID);
                    table.ForeignKey(
                        name: "FK_Makineler_Urunler_IslemNo",
                        column: x => x.IslemNo,
                        principalTable: "Urunler",
                        principalColumn: "IslemNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxlar_MusteriID",
                table: "Boxlar",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_KasaIslemleri_KasaID",
                table: "KasaIslemleri",
                column: "KasaID");

            migrationBuilder.CreateIndex(
                name: "IX_KasaIslemleri_MusteriID",
                table: "KasaIslemleri",
                column: "MusteriID");

            migrationBuilder.CreateIndex(
                name: "IX_Makineler_IslemNo",
                table: "Makineler",
                column: "IslemNo");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_BoxID",
                table: "Urunler",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_MusteriID",
                table: "Urunler",
                column: "MusteriID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KasaIslemleri");

            migrationBuilder.DropTable(
                name: "Makineler");

            migrationBuilder.DropTable(
                name: "Kasalar");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Boxlar");

            migrationBuilder.DropTable(
                name: "Musteriler");
        }
    }
}
