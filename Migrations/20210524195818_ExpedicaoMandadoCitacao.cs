using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SicWEB.Migrations {
  public partial class ExpedicaoMandadoCitacao : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.CreateTable(
          name: "ExpedicaoMandadoCitacao",
          columns: table => new {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Autos = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Contrato = table.Column<long>(type: "bigint", nullable: false),
            Vara = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Comarca = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Estado = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Banco = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Reu = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Endereco = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Oab = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Data = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            NomeUser = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4")
          },
          constraints: table => {
            table.PrimaryKey("PK_ExpedicaoMandadoCitacao", x => x.Id);
            table.UniqueConstraint("UK_ExpedicaoMandadoCitacao_Contrato", x => x.Contrato);
          })
          .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable(
          name: "ExpedicaoMandadoCitacao");
    }
  }
}
