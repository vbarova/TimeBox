using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeBox.Data.Migrations
{
    public partial class AddAllNeededModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_CreatedByUserIdId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_AspNetUsers_CreatedByUserId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_CreatedByUserId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Images_CreatedByUserIdId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "CreatedByUserIdId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedByUserIs",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Quotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserIdId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserIs",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CreatedByUserId",
                table: "Quotes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CreatedByUserIdId",
                table: "Images",
                column: "CreatedByUserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_CreatedByUserIdId",
                table: "Images",
                column: "CreatedByUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_AspNetUsers_CreatedByUserId",
                table: "Quotes",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
