using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.API.Migrations
{
    public partial class SlugMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Technologies_Slug",
                table: "Technologies",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_Slug",
                table: "Platforms",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Slug",
                table: "Languages",
                column: "Slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Technologies_Slug",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_Slug",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Slug",
                table: "Languages");
        }
    }
}
