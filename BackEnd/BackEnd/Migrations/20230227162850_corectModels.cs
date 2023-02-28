using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class corectModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Party",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PositionSik",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "Distribution",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Distribution",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PositionSik",
                table: "Distribution",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Party",
                table: "Distribution");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Distribution");

            migrationBuilder.DropColumn(
                name: "PositionSik",
                table: "Distribution");

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PositionSik",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
