using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderRestaurant.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditTestimonialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Testimonials");
        }
    }
}
