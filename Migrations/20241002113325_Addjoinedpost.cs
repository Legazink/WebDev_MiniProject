using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_MiniProject.Migrations
{
    /// <inheritdoc />
    public partial class Addjoinedpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JoinedAllPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinedAllPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JoinedAllPosts_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinedAllPosts_PostID",
                table: "JoinedAllPosts",
                column: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JoinedAllPosts");
        }
    }
}
