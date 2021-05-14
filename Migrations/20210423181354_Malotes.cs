using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SicWEB.Migrations {
  public partial class Malotes : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.CreateTable(
          name: "Malote",
          columns: table => new {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Numero = table.Column<int>(type: "int", nullable: false),
            Percurso = table.Column<int>(type: "int", nullable: false),
            Lacre = table.Column<int>(type: "int", nullable: false),
            Cidade = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Remetente = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            Atualizacao = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
            DataEnvio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            DataRecebido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            CidadeSaida = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
          },
          constraints: table => {
            table.PrimaryKey("PK_Malote", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable(
          name: "Malote");
    }
  }
}
