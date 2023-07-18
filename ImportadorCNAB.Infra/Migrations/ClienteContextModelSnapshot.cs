﻿// <auto-generated />
using System;
using ImportadorCNAB.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImportadorCNAB.Infra.Migrations
{
    [DbContext(typeof(ClienteContext))]
    partial class ClienteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeLoja")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.TipoTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Natureza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoTransacao", (string)null);

                    b.HasDiscriminator<string>("Natureza");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CartaoUtilizadoNumero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Data")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoTransacaoId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.TransacaoNegativa", b =>
                {
                    b.HasBaseType("ImportadorCNAB.Domain.ClienteAggregate.TipoTransacao");

                    b.HasDiscriminator().HasValue("Saida");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Codigo = 2,
                            Descricao = "Boleto",
                            Natureza = "Saida"
                        },
                        new
                        {
                            Id = 3,
                            Codigo = 3,
                            Descricao = "Financiamento",
                            Natureza = "Saida"
                        },
                        new
                        {
                            Id = 9,
                            Codigo = 9,
                            Descricao = "Aluguel",
                            Natureza = "Saida"
                        });
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.TransacaoPositiva", b =>
                {
                    b.HasBaseType("ImportadorCNAB.Domain.ClienteAggregate.TipoTransacao");

                    b.HasDiscriminator().HasValue("Entrada");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = 1,
                            Descricao = "Debito",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 4,
                            Codigo = 4,
                            Descricao = "Crédito",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 5,
                            Codigo = 5,
                            Descricao = "Recebimento Empréstimo",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 6,
                            Codigo = 6,
                            Descricao = "Vendas",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 7,
                            Codigo = 7,
                            Descricao = "Recebimento TED",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 8,
                            Codigo = 8,
                            Descricao = "Recebimento DOC",
                            Natureza = "Entrada"
                        });
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.Cliente", b =>
                {
                    b.OwnsOne("ImportadorCNAB.Domain.ClienteAggregate.CPF", "Cpf", b1 =>
                        {
                            b1.Property<int>("ClienteId")
                                .HasColumnType("int");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(200)");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.Transacao", b =>
                {
                    b.HasOne("ImportadorCNAB.Domain.ClienteAggregate.Cliente", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("ClienteId");

                    b.HasOne("ImportadorCNAB.Domain.ClienteAggregate.TipoTransacao", "TipoTransacao")
                        .WithMany()
                        .HasForeignKey("TipoTransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTransacao");
                });

            modelBuilder.Entity("ImportadorCNAB.Domain.ClienteAggregate.Cliente", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
