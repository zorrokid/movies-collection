using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyRoleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRoleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonRoleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRoleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GivenName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OriginalTitle = table.Column<string>(type: "text", nullable: true),
                    LocalTitle = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Barcode = table.Column<string>(type: "text", nullable: true),
                    CaseTypeId = table.Column<int>(type: "integer", nullable: false),
                    ConditionClassId = table.Column<int>(type: "integer", nullable: false),
                    HasSlipCover = table.Column<bool>(type: "boolean", nullable: false),
                    HasHologram = table.Column<bool>(type: "boolean", nullable: false),
                    IsRental = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    HasTwoSidedCover = table.Column<bool>(type: "boolean", nullable: false),
                    HasBooklet = table.Column<bool>(type: "boolean", nullable: false),
                    ImportOriginId = table.Column<int>(type: "integer", nullable: false),
                    IdInImportOrigin = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_CaseTypes_CaseTypeId",
                        column: x => x.CaseTypeId,
                        principalTable: "CaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_ConditionClasses_ConditionClassId",
                        column: x => x.ConditionClassId,
                        principalTable: "ConditionClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionTypeId = table.Column<int>(type: "integer", nullable: false),
                    OriginalTitle = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productions_ProductionTypes_ProductionTypeId",
                        column: x => x.ProductionTypeId,
                        principalTable: "ProductionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicationId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverLanguages_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "CompanyRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    CompanyRoleTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProductionId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRoles_CompanyRoleTypes_CompanyRoleTypeId",
                        column: x => x.CompanyRoleTypeId,
                        principalTable: "CompanyRoleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRoles_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    PersonRoleTypeId = table.Column<int>(type: "integer", nullable: false),
                    ProductionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRoles_PersonRoleTypes_PersonRoleTypeId",
                        column: x => x.PersonRoleTypeId,
                        principalTable: "PersonRoleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRoles_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRoles_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicationItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicationId = table.Column<int>(type: "integer", nullable: false),
                    ProductionId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationItems_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationItems_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicationItemId = table.Column<int>(type: "integer", nullable: false),
                    MediaTypeId = table.Column<int>(type: "integer", nullable: false),
                    ConditionClassId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaItems_ConditionClasses_ConditionClassId",
                        column: x => x.ConditionClassId,
                        principalTable: "ConditionClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaItems_MediaTypes_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaItems_PublicationItems_PublicationItemId",
                        column: x => x.PublicationItemId,
                        principalTable: "PublicationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicationItemId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_PublicationItems_PublicationItemId",
                        column: x => x.PublicationItemId,
                        principalTable: "PublicationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubtitleLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PublicationItemId = table.Column<int>(type: "integer", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtitleLanguages_PublicationItems_PublicationItemId",
                        column: x => x.PublicationItemId,
                        principalTable: "PublicationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CaseTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Undefined" },
                    { 2, "Keep Case" },
                    { 3, "Snapper Case" },
                    { 4, "Digipack" },
                    { 5, "Steelbook" },
                    { 6, "Keep case (slim)" },
                    { 7, "Mediabook" },
                    { 8, "Cardboard box set" },
                    { 9, "Special box set" }
                });

            migrationBuilder.InsertData(
                table: "CollectionStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Wanted item" },
                    { 3, "Trade item" },
                    { 1, "Undefined" },
                    { 2, "Collection item" },
                    { 5, "Previosly owned item" }
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
                table: "ConditionClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Poor" },
                    { 7, "Bad" },
                    { 5, "Fair" },
                    { 3, "Excellent" },
                    { 2, "New" },
                    { 1, "Undefined" },
                    { 4, "Good" }
                });

            migrationBuilder.InsertData(
                table: "MediaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "CD" },
                    { 1, "DVD" },
                    { 2, "Blu-ray" },
                    { 3, "VHS" },
                    { 4, "4K Ultra HD" },
                    { 5, "HD DVD" },
                    { 7, "Blu-ray 3D" }
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

            migrationBuilder.InsertData(
                table: "ProductionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "TV Serie" },
                    { 4, "Document" },
                    { 1, "Undefined" },
                    { 2, "Movie" },
                    { 5, "Music" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_CompanyId",
                table: "CompanyRoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_CompanyRoleTypeId",
                table: "CompanyRoles",
                column: "CompanyRoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_ProductionId",
                table: "CompanyRoles",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverLanguages_PublicationId",
                table: "CoverLanguages",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_ConditionClassId",
                table: "MediaItems",
                column: "ConditionClassId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_MediaTypeId",
                table: "MediaItems",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaItems_PublicationItemId",
                table: "MediaItems",
                column: "PublicationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_PersonId",
                table: "PersonRoles",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_PersonRoleTypeId",
                table: "PersonRoles",
                column: "PersonRoleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRoles_ProductionId",
                table: "PersonRoles",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_ProductionTypeId",
                table: "Productions",
                column: "ProductionTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PublicationItems_ProductionId",
                table: "PublicationItems",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationItems_PublicationId",
                table: "PublicationItems",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_CaseTypeId",
                table: "Publications",
                column: "CaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ConditionClassId",
                table: "Publications",
                column: "ConditionClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_PublicationItemId",
                table: "SpokenLanguages",
                column: "PublicationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleLanguages_PublicationItemId",
                table: "SubtitleLanguages",
                column: "PublicationItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionStatuses");

            migrationBuilder.DropTable(
                name: "CompanyRoles");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CoverLanguages");

            migrationBuilder.DropTable(
                name: "MediaItems");

            migrationBuilder.DropTable(
                name: "PersonRoles");

            migrationBuilder.DropTable(
                name: "PublicationCompanyRole");

            migrationBuilder.DropTable(
                name: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "SubtitleLanguages");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropTable(
                name: "PersonRoleTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyRoleTypes");

            migrationBuilder.DropTable(
                name: "PublicationItems");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "ProductionTypes");

            migrationBuilder.DropTable(
                name: "CaseTypes");

            migrationBuilder.DropTable(
                name: "ConditionClasses");
        }
    }
}
