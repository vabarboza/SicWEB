using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SicWEB.Migrations {
  public partial class InformarEndereco : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.AlterColumn<string>(
          name: "Status",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Remetente",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "CidadeSaida",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Cidade",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "Atualizacao",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true);

      migrationBuilder.AlterColumn<long>(
          name: "Contrato",
          table: "FielDepositario",
          type: "bigint",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AlterColumn<long>(
          name: "Contrato",
          table: "ExpedicaoNovoMandado",
          type: "bigint",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AlterColumn<long>(
          name: "Contrato",
          table: "CitacaoCarta",
          type: "bigint",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.CreateTable(
          name: "InformarEndereco",
          columns: table => new {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Autos = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Contrato = table.Column<long>(type: "bigint", nullable: false),
            Vara = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Comarca = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Estado = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Banco = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Reu = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Endereco = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Oab = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            Data = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
            NomeUser = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
          },
          constraints: table => {
            table.PrimaryKey("PK_InformarEndereco", x => x.Id);
            table.UniqueConstraint("UK_InformarEndereco_Contrato", x => x.Contrato);

          });
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropTable(
          name: "InformarEndereco");

      migrationBuilder.AlterColumn<string>(
          name: "Status",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Remetente",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "CidadeSaida",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Cidade",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Atualizacao",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4");

      migrationBuilder.AlterColumn<int>(
          name: "Contrato",
          table: "FielDepositario",
          type: "int",
          nullable: false,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AlterColumn<int>(
          name: "Contrato",
          table: "ExpedicaoNovoMandado",
          type: "int",
          nullable: false,
          oldClrType: typeof(long),
          oldType: "bigint");

      migrationBuilder.AlterColumn<int>(
          name: "Contrato",
          table: "CitacaoCarta",
          type: "int",
          nullable: false,
          oldClrType: typeof(long),
          oldType: "bigint");
    }
  }
}
