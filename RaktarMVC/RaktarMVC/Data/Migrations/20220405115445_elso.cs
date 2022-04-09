using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaktarMVC.Data.Migrations
{
    public partial class elso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adatmodel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Gyarto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Tipus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BeszerzesiAr = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adatmodel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adatmodel");
        }
    }
}
