using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class DataModelChangesWIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_Companies_CompanyId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_CompanyRoleTypes_RoleId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyRoles_PublicationItems_MovieId",
                table: "CompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CoverLanguages_Publications_PublicationId",
                table: "CoverLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_MediaTypes_MediaTypeId",
                table: "MediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_PublicationItems_PublicationItemId",
                table: "MediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_PersonRoleTypes_RoleId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Productions_MovieId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Productions_ProductionId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Productions_ProductionId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Productions_ProductionId2",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Companies_StudioId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_ProductionTypes_ProductionTypeId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationItems_Productions_ProductionId",
                table: "PublicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationItems_Publications_PublicationId",
                table: "PublicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_CaseTypes_CaseTypeId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Companies_PublisherId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_ConditionClasses_ConditionClassId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_PublicationItems_PublicationItemId",
                table: "SpokenLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubtitleLanguages_PublicationItems_PublicationItemId",
                table: "SubtitleLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Publications_PublisherId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ProductionId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ProductionId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ProductionId2",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_PersonRoles_MovieId",
                table: "PersonRoles");

            migrationBuilder.DropIndex(
                name: "IX_PersonRoles_RoleId",
                table: "PersonRoles");

            migrationBuilder.DropIndex(
                name: "IX_CompanyRoles_MovieId",
                table: "CompanyRoles");

            migrationBuilder.DropIndex(
                name: "IX_CompanyRoles_RoleId",
                table: "CompanyRoles");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ImportOriginId",
                table: "PublicationItems");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ProductionId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ProductionId2",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "PersonRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "PersonRoles");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "CompanyRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "CompanyRoles");

            migrationBuilder.RenameColumn(
                name: "StudioId",
                table: "Productions",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Productions_StudioId",
                table: "Productions",
                newName: "IX_Productions_PersonId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Persons",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "SubtitleLanguages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "SpokenLanguages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConditionClassId",
                table: "Publications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseTypeId",
                table: "Publications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdInImportOrigin",
                table: "Publications",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "PublicationItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionId",
                table: "PublicationItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionTypeId",
                table: "Productions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PersonRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonRoleTypeId",
                table: "PersonRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "PersonRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "MediaItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "MediaItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConditionClassId",
                table: "MediaItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "CoverLanguages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyRoleTypeId",
                table: "CompanyRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "CompanyRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PublicationCompanyRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    CompanyRoleTypeId = table.Column<int>(type: "integer", nullable: false),
                    PublicationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationCompanyRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationCompanyRole_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationCompanyRole_CompanyRoleTypes_CompanyRoleTypeId",
                        column: x => x.CompanyRoleTypeId,
                        principalTable: "CompanyRoleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationCompanyRole_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyRoleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Publisher" },
                    { 1, "Studio" }
                });

            migrationBuilder.InsertData(
                table: "PersonRoleTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Producer" },
                    { 3, "Writer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_PersonRoleTypeId",
                table: "PersonRoles",
                column: "PersonRoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_ProductionId",
                table: "PersonRoles",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_ConditionClassId",
                table: "MediaItems",
                column: "ConditionClassId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_CompanyRoleTypeId",
                table: "CompanyRoles",
                column: "CompanyRoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_ProductionId",
                table: "CompanyRoles",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationCompanyRole_CompanyId",
                table: "PublicationCompanyRole",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationCompanyRole_CompanyRoleTypeId",
                table: "PublicationCompanyRole",
                column: "CompanyRoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationCompanyRole_PublicationId",
                table: "PublicationCompanyRole",
                column: "PublicationId");

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
                name: "FK_CoverLanguages_Publications_PublicationId",
                table: "CoverLanguages",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_ConditionClasses_ConditionClassId",
                table: "MediaItems",
                column: "ConditionClassId",
                principalTable: "ConditionClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_MediaTypes_MediaTypeId",
                table: "MediaItems",
                column: "MediaTypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_PublicationItems_PublicationItemId",
                table: "MediaItems",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Persons_PersonId",
                table: "Productions",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_ProductionTypes_ProductionTypeId",
                table: "Productions",
                column: "ProductionTypeId",
                principalTable: "ProductionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationItems_Productions_ProductionId",
                table: "PublicationItems",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationItems_Publications_PublicationId",
                table: "PublicationItems",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_CaseTypes_CaseTypeId",
                table: "Publications",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_ConditionClasses_ConditionClassId",
                table: "Publications",
                column: "ConditionClassId",
                principalTable: "ConditionClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_PublicationItems_PublicationItemId",
                table: "SpokenLanguages",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubtitleLanguages_PublicationItems_PublicationItemId",
                table: "SubtitleLanguages",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_CoverLanguages_Publications_PublicationId",
                table: "CoverLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_ConditionClasses_ConditionClassId",
                table: "MediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_MediaTypes_MediaTypeId",
                table: "MediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaItems_PublicationItems_PublicationItemId",
                table: "MediaItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_PersonRoleTypes_PersonRoleTypeId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonRoles_Productions_ProductionId",
                table: "PersonRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Persons_PersonId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_ProductionTypes_ProductionTypeId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationItems_Productions_ProductionId",
                table: "PublicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicationItems_Publications_PublicationId",
                table: "PublicationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_CaseTypes_CaseTypeId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_ConditionClasses_ConditionClassId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_PublicationItems_PublicationItemId",
                table: "SpokenLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubtitleLanguages_PublicationItems_PublicationItemId",
                table: "SubtitleLanguages");

            migrationBuilder.DropTable(
                name: "PublicationCompanyRole");

            migrationBuilder.DropIndex(
                name: "IX_PersonRoles_PersonRoleTypeId",
                table: "PersonRoles");

            migrationBuilder.DropIndex(
                name: "IX_PersonRoles_ProductionId",
                table: "PersonRoles");

            migrationBuilder.DropIndex(
                name: "IX_MediaItems_ConditionClassId",
                table: "MediaItems");

            migrationBuilder.DropIndex(
                name: "IX_CompanyRoles_CompanyRoleTypeId",
                table: "CompanyRoles");

            migrationBuilder.DropIndex(
                name: "IX_CompanyRoles_ProductionId",
                table: "CompanyRoles");

            migrationBuilder.DeleteData(
                table: "CompanyRoleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyRoleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonRoleTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonRoleTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonRoleTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IdInImportOrigin",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "PersonRoleTypeId",
                table: "PersonRoles");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "PersonRoles");

            migrationBuilder.DropColumn(
                name: "ConditionClassId",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "CompanyRoleTypeId",
                table: "CompanyRoles");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "CompanyRoles");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Productions",
                newName: "StudioId");

            migrationBuilder.RenameIndex(
                name: "IX_Productions_PersonId",
                table: "Productions",
                newName: "IX_Productions_StudioId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "SubtitleLanguages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "SpokenLanguages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ConditionClassId",
                table: "Publications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CaseTypeId",
                table: "Publications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Publications",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "PublicationItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionId",
                table: "PublicationItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ImportOriginId",
                table: "PublicationItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductionTypeId",
                table: "Productions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ProductionId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionId1",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductionId2",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PersonRoles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "PersonRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "PersonRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationItemId",
                table: "MediaItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "MediaItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "CoverLanguages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyRoles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "CompanyRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "CompanyRoles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublisherId",
                table: "Publications",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProductionId",
                table: "Persons",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProductionId1",
                table: "Persons",
                column: "ProductionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProductionId2",
                table: "Persons",
                column: "ProductionId2");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_MovieId",
                table: "PersonRoles",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_RoleId",
                table: "PersonRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_MovieId",
                table: "CompanyRoles",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_RoleId",
                table: "CompanyRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_Companies_CompanyId",
                table: "CompanyRoles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_CompanyRoleTypes_RoleId",
                table: "CompanyRoles",
                column: "RoleId",
                principalTable: "CompanyRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyRoles_PublicationItems_MovieId",
                table: "CompanyRoles",
                column: "MovieId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoverLanguages_Publications_PublicationId",
                table: "CoverLanguages",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_MediaTypes_MediaTypeId",
                table: "MediaItems",
                column: "MediaTypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItems_PublicationItems_PublicationItemId",
                table: "MediaItems",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_PersonRoleTypes_RoleId",
                table: "PersonRoles",
                column: "RoleId",
                principalTable: "PersonRoleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Persons_PersonId",
                table: "PersonRoles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonRoles_Productions_MovieId",
                table: "PersonRoles",
                column: "MovieId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Productions_ProductionId",
                table: "Persons",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Productions_ProductionId1",
                table: "Persons",
                column: "ProductionId1",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Productions_ProductionId2",
                table: "Persons",
                column: "ProductionId2",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Companies_StudioId",
                table: "Productions",
                column: "StudioId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_ProductionTypes_ProductionTypeId",
                table: "Productions",
                column: "ProductionTypeId",
                principalTable: "ProductionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationItems_Productions_ProductionId",
                table: "PublicationItems",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationItems_Publications_PublicationId",
                table: "PublicationItems",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_CaseTypes_CaseTypeId",
                table: "Publications",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Companies_PublisherId",
                table: "Publications",
                column: "PublisherId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_ConditionClasses_ConditionClassId",
                table: "Publications",
                column: "ConditionClassId",
                principalTable: "ConditionClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_PublicationItems_PublicationItemId",
                table: "SpokenLanguages",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubtitleLanguages_PublicationItems_PublicationItemId",
                table: "SubtitleLanguages",
                column: "PublicationItemId",
                principalTable: "PublicationItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
