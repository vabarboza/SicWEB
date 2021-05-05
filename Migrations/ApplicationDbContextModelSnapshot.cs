﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SicWEB.Data;

namespace SicWEB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SicWEB.Models.CitacaoCarta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CitacaoCarta");
                });

            modelBuilder.Entity("SicWEB.Models.ConversaoExecucao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorDescrito")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorReal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ConversaoExecucao");
                });

            modelBuilder.Entity("SicWEB.Models.ConversaoExecucaoItau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Processo")
                        .HasColumnType("bigint");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ValorReal")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ConversaoExecucaoItau");
                });

            modelBuilder.Entity("SicWEB.Models.ExpedicaoNovoMandado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExpedicaoNovoMandado");
                });

            modelBuilder.Entity("SicWEB.Models.FielDepositario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Fiel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FielDepositario");
                });

            modelBuilder.Entity("SicWEB.Models.InformarEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InformarEndereco");
                });

            modelBuilder.Entity("SicWEB.Models.InformarOrgao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InformarOrgao");
                });

            modelBuilder.Entity("SicWEB.Models.JuntadaTermoCessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BancoCedente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Comarca")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Contrato")
                        .HasColumnType("bigint");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Oab")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Vara")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("JuntadaTermoCessao");
                });

            modelBuilder.Entity("SicWEB.Models.Malote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Atualizacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CidadeSaida")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataRecebido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Lacre")
                        .HasColumnType("int");

                    b.Property<string>("NomeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Percurso")
                        .HasColumnType("int");

                    b.Property<string>("Remetente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Malote");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
