﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api_asmontech.Migrations
{
    [DbContext(typeof(MeuContexto))]
    [Migration("20250216184109_UpdateTabelaTiposProdutos1")]
    partial class UpdateTabelaTiposProdutos1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("api_asmontech.Models.CardapioProdutos", b =>
                {
                    b.Property<int>("IdCardapioProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HorarioFuncionamentoidHorarioFuncionamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdHorarioFuncionamento")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoidProduto")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCardapioProduto");

                    b.HasIndex("HorarioFuncionamentoidHorarioFuncionamento");

                    b.HasIndex("ProdutoidProduto");

                    b.ToTable("CardapioProdutos");
                });

            modelBuilder.Entity("api_asmontech.Models.HorarioFuncionamentoModel", b =>
                {
                    b.Property<int>("idHorarioFuncionamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HorarioFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("idHorarioFuncionamento");

                    b.ToTable("HorarioFuncionamentoModel");
                });

            modelBuilder.Entity("api_asmontech.Models.ItensPedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notas")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PedidoModelIdPedido")
                        .HasColumnType("INTEGER");

                    b.Property<short>("Qtd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idItemPedido")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPedido");

                    b.HasIndex("PedidoModelIdPedido");

                    b.ToTable("ItensPedidoModel");
                });

            modelBuilder.Entity("api_asmontech.Models.PedidoModel", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DtRegister")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<short>("IdStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPedido");

                    b.ToTable("PedidoModel");
                });

            modelBuilder.Entity("api_asmontech.Models.ProdutosModel", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoProduto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idProduto");

                    b.ToTable("ProdutosModel");
                });

            modelBuilder.Entity("api_asmontech.Models.StatusPedidosModel", b =>
                {
                    b.Property<short>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdStatus");

                    b.ToTable("StatusPedidosModel");
                });

            modelBuilder.Entity("api_asmontech.Models.TiposProdutoModel", b =>
                {
                    b.Property<int>("IdTipoProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdTipoProduto");

                    b.ToTable("TiposProdutoModel");
                });

            modelBuilder.Entity("api_asmontech.Models.CardapioProdutos", b =>
                {
                    b.HasOne("api_asmontech.Models.HorarioFuncionamentoModel", "HorarioFuncionamento")
                        .WithMany("CardapioProdutos")
                        .HasForeignKey("HorarioFuncionamentoidHorarioFuncionamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_asmontech.Models.ProdutosModel", "Produto")
                        .WithMany("CardapioProdutos")
                        .HasForeignKey("ProdutoidProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HorarioFuncionamento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("api_asmontech.Models.ItensPedidoModel", b =>
                {
                    b.HasOne("api_asmontech.Models.PedidoModel", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoModelIdPedido");
                });

            modelBuilder.Entity("api_asmontech.Models.HorarioFuncionamentoModel", b =>
                {
                    b.Navigation("CardapioProdutos");
                });

            modelBuilder.Entity("api_asmontech.Models.PedidoModel", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("api_asmontech.Models.ProdutosModel", b =>
                {
                    b.Navigation("CardapioProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
