using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddImportOriginToPublicationItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdInImportOrigin",
                table: "PublicationItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImportOriginId",
                table: "PublicationItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdInImportOrigin",
                table: "PublicationItems");

            migrationBuilder.DropColumn(
                name: "ImportOriginId",
                table: "PublicationItems");
        }
    }
}
