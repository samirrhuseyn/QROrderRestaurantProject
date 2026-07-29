using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderRestaurant.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatesocialmediatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SocialMedias",
                newName: "Color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "SocialMedias",
                newName: "Title");
        }
    }
}
