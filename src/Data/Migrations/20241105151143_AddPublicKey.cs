using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvantageTool.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicKey",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicKey",
                table: "Platforms");
        }
    }
}
