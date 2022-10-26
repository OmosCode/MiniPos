using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef814f26-372a-430e-bfe8-57ff844f0aa4");

            migrationBuilder.CreateTable(
                name: "Rapor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    ToplamTutar = table.Column<int>(type: "int", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceteID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rapor_Recetes_ReceteID",
                        column: x => x.ReceteID,
                        principalTable: "Recetes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb24d020-5a34-4de8-ad5d-4a9c079658b5", "50c87a69-8374-4dcd-acbb-7461a754b2d2", "Member", "MEMBER" });

            migrationBuilder.CreateIndex(
                name: "IX_Rapor_ReceteID",
                table: "Rapor",
                column: "ReceteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapor");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb24d020-5a34-4de8-ad5d-4a9c079658b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef814f26-372a-430e-bfe8-57ff844f0aa4", "8523d3a1-4e4c-4ffd-99ef-6b882fade028", "Member", "MEMBER" });
        }
    }
}
