using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_MiniProject.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AccountID",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Posts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AccountID",
                table: "Posts",
                newName: "IX_Posts_AccountId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "JoinedAllPosts",
                newName: "AccountId");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "JoinedAllPosts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_JoinedAllPosts_AccountId",
                table: "JoinedAllPosts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedAllPosts_AspNetUsers_AccountId",
                table: "JoinedAllPosts",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AccountId",
                table: "Posts",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinedAllPosts_AspNetUsers_AccountId",
                table: "JoinedAllPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AccountId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_JoinedAllPosts_AccountId",
                table: "JoinedAllPosts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Posts",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AccountId",
                table: "Posts",
                newName: "IX_Posts_AccountID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "JoinedAllPosts",
                newName: "AccountID");

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountID",
                table: "JoinedAllPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AccountID",
                table: "Posts",
                column: "AccountID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
