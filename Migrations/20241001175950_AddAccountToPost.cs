using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_MiniProject.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountToPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountID",
                table: "Posts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AccountID",
                table: "Posts",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AccountID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AccountID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
