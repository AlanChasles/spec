using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace rh.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    nom = table.Column<string>(nullable: true),
                    projetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Module_Projet_projetId",
                        column: x => x.projetId,
                        principalTable: "Projet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    code = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    moduleId = table.Column<int>(nullable: false),
                    nom = table.Column<string>(nullable: true),
                    utilisateur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Page_Module_moduleId",
                        column: x => x.moduleId,
                        principalTable: "Module",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageType = table.Column<int>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    pageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Image_Page_pageId",
                        column: x => x.pageId,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    commentaire = table.Column<string>(nullable: true),
                    infoPageType = table.Column<int>(nullable: false),
                    pageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Info_Page_pageId",
                        column: x => x.pageId,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lien",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    commentaire = table.Column<string>(nullable: true),
                    entreePageId = table.Column<int>(nullable: false),
                    sortiePageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lien", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lien_Page_entreePageId",
                        column: x => x.entreePageId,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lien_Page_sortiePageId",
                        column: x => x.sortiePageId,
                        principalTable: "Page",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_pageId",
                table: "Image",
                column: "pageId");

            migrationBuilder.CreateIndex(
                name: "IX_Info_pageId",
                table: "Info",
                column: "pageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien_entreePageId",
                table: "Lien",
                column: "entreePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lien_sortiePageId",
                table: "Lien",
                column: "sortiePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_projetId",
                table: "Module",
                column: "projetId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_moduleId",
                table: "Page",
                column: "moduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Lien");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Projet");
        }
    }
}
