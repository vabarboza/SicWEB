using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SicWEB.Migrations
{
  public partial class InformarOrgao : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "Status",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Remetente",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "CidadeSaida",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Cidade",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Atualizacao",
          table: "Malote",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "InformarEndereco",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Telefone",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "RG",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Fiel",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "FielDepositario",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "ExpedicaoNovoMandado",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "CitacaoCarta",
          type: "longtext",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Value",
          table: "AspNetUserTokens",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "SecurityStamp",
          table: "AspNetUsers",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "PhoneNumber",
          table: "AspNetUsers",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "PasswordHash",
          table: "AspNetUsers",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ConcurrencyStamp",
          table: "AspNetUsers",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ProviderDisplayName",
          table: "AspNetUserLogins",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimValue",
          table: "AspNetUserClaims",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimType",
          table: "AspNetUserClaims",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ConcurrencyStamp",
          table: "AspNetRoles",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimValue",
          table: "AspNetRoleClaims",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimType",
          table: "AspNetRoleClaims",
          type: "longtext",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext CHARACTER SET utf8mb4",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
          name: "InformarOrgao",
          columns: table => new
          {
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
            Oab = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            Data = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4"),
            NomeUser = table.Column<string>(type: "longtext", nullable: false)
                  .Annotation("MySql:CharSet", "utf8mb4")
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_InformarOrgao", x => x.Id);
            table.UniqueConstraint("UK_InformarOrgao_Contrato", x => x.Contrato);
          })
          .Annotation("MySql:CharSet", "utf8mb4");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "InformarOrgao");

      migrationBuilder.AlterColumn<string>(
          name: "Status",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Remetente",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "CidadeSaida",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Cidade",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Atualizacao",
          table: "Malote",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "InformarEndereco",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Telefone",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "RG",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Fiel",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "FielDepositario",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "ExpedicaoNovoMandado",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Vara",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Reu",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Oab",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "NomeUser",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Estado",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Endereco",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Data",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Comarca",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Banco",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Autos",
          table: "CitacaoCarta",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "longtext")
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "Value",
          table: "AspNetUserTokens",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "SecurityStamp",
          table: "AspNetUsers",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "PhoneNumber",
          table: "AspNetUsers",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "PasswordHash",
          table: "AspNetUsers",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ConcurrencyStamp",
          table: "AspNetUsers",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ProviderDisplayName",
          table: "AspNetUserLogins",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimValue",
          table: "AspNetUserClaims",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimType",
          table: "AspNetUserClaims",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ConcurrencyStamp",
          table: "AspNetRoles",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimValue",
          table: "AspNetRoleClaims",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.AlterColumn<string>(
          name: "ClaimType",
          table: "AspNetRoleClaims",
          type: "longtext CHARACTER SET utf8mb4",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "longtext",
          oldNullable: true)
          .Annotation("MySql:CharSet", "utf8mb4")
          .OldAnnotation("MySql:CharSet", "utf8mb4");
    }
  }
}
