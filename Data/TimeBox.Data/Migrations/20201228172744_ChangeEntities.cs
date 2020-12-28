using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeBox.Data.Migrations
{
    public partial class ChangeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlannedTasks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlannedTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTasks_IsDeleted",
                table: "PlannedTasks",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IsDeleted",
                table: "Notes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlannedTasks_IsDeleted",
                table: "PlannedTasks");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IsDeleted",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Images_IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlannedTasks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlannedTasks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");
        }
    }
}
