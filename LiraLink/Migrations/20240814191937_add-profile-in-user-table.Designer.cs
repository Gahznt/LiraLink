﻿// <auto-generated />
using System;
using LiraLink.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LiraLink.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240814191937_add-profile-in-user-table")]
    partial class addprofileinusertable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LiraLink.Models.CargoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("LiraLink.Models.ClienteModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LiraLink.Models.ColaboradoresModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("data_admissao")
                        .HasColumnType("date");

                    b.Property<int>("departamento_id")
                        .HasColumnType("int");

                    b.Property<int>("tipo_vinculo_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("departamento_id");

                    b.HasIndex("tipo_vinculo_id");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("LiraLink.Models.DepartamentoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("LiraLink.Models.IndicadoresModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipo_indicador_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("tipo_indicador_id");

                    b.ToTable("Indicadores");
                });

            modelBuilder.Entity("LiraLink.Models.IndicadoresProjetoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("indicador_id")
                        .HasColumnType("int");

                    b.Property<float>("percentual")
                        .HasColumnType("real");

                    b.Property<int>("projeto_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("indicador_id");

                    b.HasIndex("projeto_id");

                    b.ToTable("ProjetoIndicadores");
                });

            modelBuilder.Entity("LiraLink.Models.ProjetoColaboradores", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("colaborador_id")
                        .HasColumnType("int");

                    b.Property<string>("estado_participacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("performance")
                        .HasColumnType("int");

                    b.Property<int>("projeto_id")
                        .HasColumnType("int");

                    b.Property<int>("quantidade_ficha_advertencia")
                        .HasColumnType("int");

                    b.Property<int>("quantidade_processos_disciplinar")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("colaborador_id");

                    b.HasIndex("projeto_id");

                    b.ToTable("ProjetoColaboradores");
                });

            modelBuilder.Entity("LiraLink.Models.ProjetoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Usuariosid")
                        .HasColumnType("int");

                    b.Property<int>("cliente_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("criado_por")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("numero_fatura")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_aplicavel_participacao")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_aplicavel_premio")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_aplicavel_valor_remunerado")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_desempenho_deficiente")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_ficha_advertencia")
                        .HasColumnType("real");

                    b.Property<float>("porcentagem_processo_disciplinar")
                        .HasColumnType("real");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<float>("valor_obra")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("Usuariosid");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("LiraLink.Models.RateiosModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("departamento_id")
                        .HasColumnType("int");

                    b.Property<int>("indicador_id")
                        .HasColumnType("int");

                    b.Property<float>("percentual")
                        .HasColumnType("real");

                    b.Property<int>("projeto_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("departamento_id");

                    b.HasIndex("indicador_id");

                    b.HasIndex("projeto_id");

                    b.ToTable("Rateios");
                });

            modelBuilder.Entity("LiraLink.Models.TipoIndicadorModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("TipoIndicadores");
                });

            modelBuilder.Entity("LiraLink.Models.TipoVinculoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("nome")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("TipoVinculo");
                });

            modelBuilder.Entity("LiraLink.Models.UsariosModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("cargo_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("perfil")
                        .HasColumnType("int");

                    b.Property<byte[]>("salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("senha")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("cargo_id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LiraLink.Models.ColaboradoresModel", b =>
                {
                    b.HasOne("LiraLink.Models.DepartamentoModel", "Departamento")
                        .WithMany()
                        .HasForeignKey("departamento_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.TipoVinculoModel", "TipoVinculo")
                        .WithMany()
                        .HasForeignKey("tipo_vinculo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("TipoVinculo");
                });

            modelBuilder.Entity("LiraLink.Models.IndicadoresModel", b =>
                {
                    b.HasOne("LiraLink.Models.TipoIndicadorModel", "TipoIndicador")
                        .WithMany()
                        .HasForeignKey("tipo_indicador_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoIndicador");
                });

            modelBuilder.Entity("LiraLink.Models.IndicadoresProjetoModel", b =>
                {
                    b.HasOne("LiraLink.Models.IndicadoresModel", "Indicadores")
                        .WithMany()
                        .HasForeignKey("indicador_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.ProjetoModel", "Projeto")
                        .WithMany()
                        .HasForeignKey("projeto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Indicadores");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("LiraLink.Models.ProjetoColaboradores", b =>
                {
                    b.HasOne("LiraLink.Models.ColaboradoresModel", "Colaboradores")
                        .WithMany()
                        .HasForeignKey("colaborador_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.ProjetoModel", "Projeto")
                        .WithMany()
                        .HasForeignKey("projeto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaboradores");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("LiraLink.Models.ProjetoModel", b =>
                {
                    b.HasOne("LiraLink.Models.ClienteModel", "cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.UsariosModel", "Usuarios")
                        .WithMany()
                        .HasForeignKey("Usuariosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("LiraLink.Models.RateiosModel", b =>
                {
                    b.HasOne("LiraLink.Models.DepartamentoModel", "Departamento")
                        .WithMany()
                        .HasForeignKey("departamento_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.IndicadoresModel", "Indicador")
                        .WithMany()
                        .HasForeignKey("indicador_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiraLink.Models.ProjetoModel", "Projeto")
                        .WithMany()
                        .HasForeignKey("projeto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Indicador");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("LiraLink.Models.UsariosModel", b =>
                {
                    b.HasOne("LiraLink.Models.CargoModel", "cargo")
                        .WithMany()
                        .HasForeignKey("cargo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cargo");
                });
#pragma warning restore 612, 618
        }
    }
}
