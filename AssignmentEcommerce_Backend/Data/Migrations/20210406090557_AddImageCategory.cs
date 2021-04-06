using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentEcommerce_Backend.Migrations
{
    public partial class AddImageCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Categories");
        }
    }
}
