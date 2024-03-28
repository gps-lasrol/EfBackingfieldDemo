using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreBackingFieldDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddedV2Tests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogV2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogV2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostV2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogV2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostV2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostV2s_BlogV2s_BlogV2Id",
                        column: x => x.BlogV2Id,
                        principalTable: "BlogV2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostV2s_BlogV2Id",
                table: "PostV2s",
                column: "BlogV2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostV2s");

            migrationBuilder.DropTable(
                name: "BlogV2s");
        }
    }
}
