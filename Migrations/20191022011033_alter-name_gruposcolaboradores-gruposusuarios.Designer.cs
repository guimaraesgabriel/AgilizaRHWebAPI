﻿// <auto-generated />
using System;
using AgilizaRH.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgilizaRH.Migrations
{
    [DbContext(typeof(AgilizaRHContext))]
    [Migration("20191022011033_alter-name_gruposcolaboradores-gruposusuarios")]
    partial class altername_gruposcolaboradoresgruposusuarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgilizaRH.Models.CargoGratificacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("GratificacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("GratificacaoId");

                    b.ToTable("CargoGratificacoes");
                });

            modelBuilder.Entity("AgilizaRH.Models.Cargos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("AgilizaRH.Models.Gratificacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Porcentagem")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Gratificacoes");
                });

            modelBuilder.Entity("AgilizaRH.Models.GruposUsuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("PermissaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissaoId");

                    b.ToTable("GruposColaboradores");
                });

            modelBuilder.Entity("AgilizaRH.Models.HistoricoFerias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataFerias")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PrevisaoFerias")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoFerias");
                });

            modelBuilder.Entity("AgilizaRH.Models.HistoricoPromocoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargoIdAnterior")
                        .HasColumnType("int");

                    b.Property<int?>("CargoIdNovo")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargoIdAnterior");

                    b.HasIndex("CargoIdNovo");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoPromocoes");
                });

            modelBuilder.Entity("AgilizaRH.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acao")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("TelaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("AgilizaRH.Models.Permissoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adicionar")
                        .HasColumnType("bit");

                    b.Property<bool>("Editar")
                        .HasColumnType("bit");

                    b.Property<bool>("Excluir")
                        .HasColumnType("bit");

                    b.Property<int>("TelaId")
                        .HasColumnType("int");

                    b.Property<bool>("Visualizar")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TelaId");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("AgilizaRH.Models.Telas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Tela")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Telas");
                });

            modelBuilder.Entity("AgilizaRH.Models.Telefones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("AgilizaRH.Models.UsuarioTelefones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TelefoneId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TelefoneId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioTelefones");
                });

            modelBuilder.Entity("AgilizaRH.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CargoIdNovo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<bool>("Logado")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CargoIdNovo");

                    b.HasIndex("GrupoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AgilizaRH.Models.CargoGratificacoes", b =>
                {
                    b.HasOne("AgilizaRH.Models.Cargos", "Cargos")
                        .WithMany("CargoGratificacoes")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilizaRH.Models.Gratificacoes", "Gratificacoes")
                        .WithMany("CargoGratificacoes")
                        .HasForeignKey("GratificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.GruposUsuarios", b =>
                {
                    b.HasOne("AgilizaRH.Models.Permissoes", "Permissoes")
                        .WithMany("GruposUsuarios")
                        .HasForeignKey("PermissaoId");
                });

            modelBuilder.Entity("AgilizaRH.Models.HistoricoFerias", b =>
                {
                    b.HasOne("AgilizaRH.Models.Usuarios", "Usuarios")
                        .WithMany("HistoricoFerias")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.HistoricoPromocoes", b =>
                {
                    b.HasOne("AgilizaRH.Models.Cargos", "CargoAnterior")
                        .WithMany()
                        .HasForeignKey("CargoIdAnterior");

                    b.HasOne("AgilizaRH.Models.Cargos", "CargoNovo")
                        .WithMany()
                        .HasForeignKey("CargoIdNovo");

                    b.HasOne("AgilizaRH.Models.Usuarios", "Usuarios")
                        .WithMany("HistoricoPromocoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.Log", b =>
                {
                    b.HasOne("AgilizaRH.Models.Telas", "Telas")
                        .WithMany("Log")
                        .HasForeignKey("TelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilizaRH.Models.Usuarios", "Usuarios")
                        .WithMany("Log")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.Permissoes", b =>
                {
                    b.HasOne("AgilizaRH.Models.Telas", "Telas")
                        .WithMany("Permissoes")
                        .HasForeignKey("TelaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.UsuarioTelefones", b =>
                {
                    b.HasOne("AgilizaRH.Models.Telefones", "Telefones")
                        .WithMany("UsuarioTelefones")
                        .HasForeignKey("TelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilizaRH.Models.Usuarios", "Usuarios")
                        .WithMany("UsuarioTelefones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgilizaRH.Models.Usuarios", b =>
                {
                    b.HasOne("AgilizaRH.Models.Cargos", "Cargos")
                        .WithMany()
                        .HasForeignKey("CargoIdNovo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgilizaRH.Models.GruposUsuarios", "GruposColaboradores")
                        .WithMany("Usuarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
