using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_MiniProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "AspNetUsers");
        }
    }
}
