using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Undefined");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Keep Case");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Snapper Case");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Digipack");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Steelbook");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Keep case (slim)");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Mediabook");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Cardboard box set");

            migrationBuilder.InsertData(
                table: "CaseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Special box set" });

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Undefined");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Collection item");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Trade item");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Wanted item");

            migrationBuilder.InsertData(
                table: "CollectionStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Previosly owned item" });

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Undefined");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "New");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Fair");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Poor");

            migrationBuilder.InsertData(
                table: "ConditionClasses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Bad" });

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Undefined");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Movie");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "TV Serie");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Document");

            migrationBuilder.InsertData(
                table: "ProductionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Music" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Keep Case");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Snapper Case");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Digipack");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Steelbook");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Keep case (slim)");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Mediabook");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Cardboard box set");

            migrationBuilder.UpdateData(
                table: "CaseTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Special box set");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Collection item");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Trade item");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Wanted item");

            migrationBuilder.UpdateData(
                table: "CollectionStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Previosly owned item");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "New");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Excellent");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Fair");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Poor");

            migrationBuilder.UpdateData(
                table: "ConditionClasses",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Bad");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Movie");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "TV Serie");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Document");

            migrationBuilder.UpdateData(
                table: "ProductionTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Music");
        }
    }
}
