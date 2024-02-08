using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthMvc.Data.Migrations
{
    public partial class ClassCours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnseignantId",
                table: "Cours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours",
                column: "EnseignantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cours_Enseignants_EnseignantId",
                table: "Cours",
                column: "EnseignantId",
                principalTable: "Enseignants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cours_Enseignants_EnseignantId",
                table: "Cours");

            migrationBuilder.DropIndex(
                name: "IX_Cours_EnseignantId",
                table: "Cours");

            migrationBuilder.DropColumn(
                name: "EnseignantId",
                table: "Cours");
        }
    }
}
