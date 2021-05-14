using Microsoft.EntityFrameworkCore.Migrations;

namespace SicWEB.Migrations {
  public partial class Malotes_N : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.AddColumn<string>(
          name: "NomeUser",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropColumn(
          name: "NomeUser",
          table: "Malote");
    }
  }
}
