using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Application
{
    public partial class RenamePersonRolesAndCompanyRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_Companies_CompanyId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_CompanyRoleTypes_CompanyRoleTypeId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_Productions_ProductionId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_PersonRoleTypes_PersonRoleTypeId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Productions_ProductionId",
                table: "PersonRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonRoles",
                table: "PersonRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyRoles",
                table: "CompanyRoles");

            migrationBuilder.RenameTable(
                name: "PersonRoles",
                newName: "ProductionPersonRoles");

            migrationBuilder.RenameTable(
                name: "CompanyRoles",
                newName: "ProductionCompanyRoles");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoles_ProductionId",
                table: "ProductionPersonRoles",
                newName: "IX_ProductionPersonRoles_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoles_PersonRoleTypeId",
                table: "ProductionPersonRoles",
                newName: "IX_ProductionPersonRoles_PersonRoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonRoles_PersonId",
                table: "ProductionPersonRoles",
                newName: "IX_ProductionPersonRoles_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyRoles_ProductionId",
                table: "ProductionCompanyRoles",
                newName: "IX_ProductionCompanyRoles_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyRoles_CompanyRoleTypeId",
                table: "ProductionCompanyRoles",
                newName: "IX_ProductionCompanyRoles_CompanyRoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyRoles_CompanyId",
                table: "ProductionCompanyRoles",
                newName: "IX_ProductionCompanyRoles_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionPersonRoles",
                table: "ProductionPersonRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionCompanyRoles",
                table: "ProductionCompanyRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanyRoles_Companies_CompanyId",
                table: "ProductionCompanyRoles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanyRoles_CompanyRoleTypes_CompanyRoleTypeId",
                table: "ProductionCompanyRoles",
                column: "CompanyRoleTypeId",
                principalTable: "CompanyRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanyRoles_Productions_ProductionId",
                table: "ProductionCompanyRoles",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionPersonRoles_PersonRoleTypes_PersonRoleTypeId",
                table: "ProductionPersonRoles",
                column: "PersonRoleTypeId",
                principalTable: "PersonRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionPersonRoles_Persons_PersonId",
                table: "ProductionPersonRoles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionPersonRoles_Productions_ProductionId",
                table: "ProductionPersonRoles",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanyRoles_Companies_CompanyId",
                table: "ProductionCompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanyRoles_CompanyRoleTypes_CompanyRoleTypeId",
                table: "ProductionCompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanyRoles_Productions_ProductionId",
                table: "ProductionCompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionPersonRoles_PersonRoleTypes_PersonRoleTypeId",
                table: "ProductionPersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionPersonRoles_Persons_PersonId",
                table: "ProductionPersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionPersonRoles_Productions_ProductionId",
                table: "ProductionPersonRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionPersonRoles",
                table: "ProductionPersonRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionCompanyRoles",
                table: "ProductionCompanyRoles");

            migrationBuilder.RenameTable(
                name: "ProductionPersonRoles",
                newName: "PersonRoles");

            migrationBuilder.RenameTable(
                name: "ProductionCompanyRoles",
                newName: "CompanyRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionPersonRoles_ProductionId",
                table: "PersonRoles",
                newName: "IX_PersonRoles_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionPersonRoles_PersonRoleTypeId",
                table: "PersonRoles",
                newName: "IX_PersonRoles_PersonRoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionPersonRoles_PersonId",
                table: "PersonRoles",
                newName: "IX_PersonRoles_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionCompanyRoles_ProductionId",
                table: "CompanyRoles",
                newName: "IX_CompanyRoles_ProductionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionCompanyRoles_CompanyRoleTypeId",
                table: "CompanyRoles",
                newName: "IX_CompanyRoles_CompanyRoleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionCompanyRoles_CompanyId",
                table: "CompanyRoles",
                newName: "IX_CompanyRoles_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonRoles",
                table: "PersonRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyRoles",
                table: "CompanyRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_Companies_CompanyId",
                table: "CompanyRoles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_CompanyRoleTypes_CompanyRoleTypeId",
                table: "CompanyRoles",
                column: "CompanyRoleTypeId",
                principalTable: "CompanyRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_Productions_ProductionId",
                table: "CompanyRoles",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_PersonRoleTypes_PersonRoleTypeId",
                table: "PersonRoles",
                column: "PersonRoleTypeId",
                principalTable: "PersonRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Productions_ProductionId",
                table: "PersonRoles",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
