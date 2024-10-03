using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_MiniProject.Migrations
{
    /// <inheritdoc />
    public partial class RelationJoinedPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinedAllPosts_Posts_PostID",
                table: "JoinedAllPosts");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "JoinedAllPosts",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedAllPosts_PostID",
                table: "JoinedAllPosts",
                newName: "IX_JoinedAllPosts_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedAllPosts_Posts_PostId",
                table: "JoinedAllPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JoinedAllPosts_Posts_PostId",
                table: "JoinedAllPosts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "JoinedAllPosts",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_JoinedAllPosts_PostId",
                table: "JoinedAllPosts",
                newName: "IX_JoinedAllPosts_PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_JoinedAllPosts_Posts_PostID",
                table: "JoinedAllPosts",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
