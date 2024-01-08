﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.Models;

#nullable disable

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240105181239_adicionando campos")]
    partial class adicionandocampos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoFinal.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteID"), 1L, 1);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Idade")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteID");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Compra", b =>
                {
                    b.Property<int>("CompraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraID"), 1L, 1);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.HasKey("CompraID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ProjetoFinal.Models.FechamentoCaixa", b =>
                {
                    b.Property<int>("FechamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FechamentoID"), 1L, 1);

                    b.Property<int>("CompraID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFechamento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorFinal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorInicial")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FechamentoID");

                    b.HasIndex("CompraID");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoID"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoUnit")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoID");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Compra", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Cliente", "Cliente")
                        .WithMany("Compras")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjetoFinal.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ProjetoFinal.Models.FechamentoCaixa", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Cliente", b =>
                {
                    b.Navigation("Compras");
                });
#pragma warning restore 612, 618
        }
    }
}