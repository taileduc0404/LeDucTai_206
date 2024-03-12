using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeDucTai_206.Migrations
{
    public partial class Setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khachthue",
                columns: table => new
                {
                    makh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenkh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    socmnd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sodienthoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachthue", x => x.makh);
                });

            migrationBuilder.CreateTable(
                name: "loaiphong",
                columns: table => new
                {
                    maloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    songuoi = table.Column<int>(type: "int", nullable: true),
                    dongia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiphong", x => x.maloai);
                });

            migrationBuilder.CreateTable(
                name: "phieuthue",
                columns: table => new
                {
                    sopt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngaythue = table.Column<DateTime>(type: "date", nullable: true),
                    makh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuthue", x => x.sopt);
                    table.ForeignKey(
                        name: "FK_phieuthue_khachthue",
                        column: x => x.makh,
                        principalTable: "khachthue",
                        principalColumn: "makh");
                });

            migrationBuilder.CreateTable(
                name: "phong",
                columns: table => new
                {
                    maphong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tinhtrang = table.Column<int>(type: "int", nullable: true),
                    maloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phong", x => x.maphong);
                    table.ForeignKey(
                        name: "FK_phong_loaiphong",
                        column: x => x.maloai,
                        principalTable: "loaiphong",
                        principalColumn: "maloai");
                });

            migrationBuilder.CreateTable(
                name: "chitietphieuthue",
                columns: table => new
                {
                    sopt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    maphong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dongia = table.Column<double>(type: "float", nullable: true),
                    songaythue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitietphieuthue", x => new { x.sopt, x.maphong });
                    table.ForeignKey(
                        name: "FK_chitietphieuthue_phieuthue",
                        column: x => x.sopt,
                        principalTable: "phieuthue",
                        principalColumn: "sopt");
                    table.ForeignKey(
                        name: "FK_chitietphieuthue_phong",
                        column: x => x.maphong,
                        principalTable: "phong",
                        principalColumn: "maphong");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chitietphieuthue_maphong",
                table: "chitietphieuthue",
                column: "maphong");

            migrationBuilder.CreateIndex(
                name: "IX_phieuthue_makh",
                table: "phieuthue",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_phong_maloai",
                table: "phong",
                column: "maloai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chitietphieuthue");

            migrationBuilder.DropTable(
                name: "phieuthue");

            migrationBuilder.DropTable(
                name: "phong");

            migrationBuilder.DropTable(
                name: "khachthue");

            migrationBuilder.DropTable(
                name: "loaiphong");
        }
    }
}
