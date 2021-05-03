using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SicWEB.Migrations
{
  public partial class FielDepositario : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "FielDepositario",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Autos = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Contrato = table.Column<int>(type: "bigint", nullable: false),
            Vara = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Comarca = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Estado = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Banco = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Reu = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Fiel = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            RG = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Telefone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Oab = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Data = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            NomeUser = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_FielDepositario", x => x.Id);
            table.UniqueConstraint("UK_PK_FielDepositario_Contrato", x => x.Contrato);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "FielDepositario");
    }
  }
}
