using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace passagens_backend.Migrations
{
    public partial class escrevendoAereaCorreto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanhiaArea",
                table: "Passagens",
                newName: "CompanhiaAerea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanhiaAerea",
                table: "Passagens",
                newName: "CompanhiaArea");
        }
    }
}
