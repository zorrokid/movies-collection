using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemovedProductionRelationFromPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Persons_PersonId",
                table: "Productions");

            migrationBuilder.DropIndex(
                name: "IX_Productions_PersonId",
                table: "Productions");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Productions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Productions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productions_PersonId",
                table: "Productions",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Persons_PersonId",
                table: "Productions",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
