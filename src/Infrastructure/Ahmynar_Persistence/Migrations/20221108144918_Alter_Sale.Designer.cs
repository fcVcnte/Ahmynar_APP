﻿// <auto-generated />
using System;
using Ahmynar_Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ahmynar_Persistence.Migrations
{
    [DbContext(typeof(AhmynarDbContext))]
    [Migration("20221108144918_Alter_Sale")]
    partial class Alter_Sale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ahmynar_Domain.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<float?>("TotalProducts")
                        .HasColumnType("real");

                    b.Property<float?>("TotalServices")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Ahmynar_Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressComplement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeCustomer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Ahmynar_Domain.Equipament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Acessories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeEquipament")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Equipaments");
                });

            modelBuilder.Entity("Ahmynar_Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupProduct")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("SalePrice")
                        .HasColumnType("real");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ahmynar_Domain.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BudgetId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InstallmentPayment")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentSale")
                        .HasColumnType("int");

                    b.Property<float>("TotalSale")
                        .HasColumnType("real");

                    b.Property<int>("TypeSale")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Ahmynar_Domain.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SalePrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Ahmynar_Domain.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<float?>("TotalDiscounts")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("Ahmynar_Domain.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressComplement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Obs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BudgetProduct", b =>
                {
                    b.Property<int>("BudgetsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("BudgetsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("BudgetProduct");
                });

            modelBuilder.Entity("BudgetService", b =>
                {
                    b.Property<int>("BudgetsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("BudgetsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("BudgetService");
                });

            modelBuilder.Entity("ProductSale", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SalesId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "SalesId");

                    b.HasIndex("SalesId");

                    b.ToTable("ProductSale");
                });

            modelBuilder.Entity("Ahmynar_Domain.Budget", b =>
                {
                    b.HasOne("Ahmynar_Domain.Customer", "Customer")
                        .WithMany("Budgets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Ahmynar_Domain.Equipament", b =>
                {
                    b.HasOne("Ahmynar_Domain.Customer", "Customer")
                        .WithMany("Equipaments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Ahmynar_Domain.Product", b =>
                {
                    b.HasOne("Ahmynar_Domain.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Ahmynar_Domain.Sale", b =>
                {
                    b.HasOne("Ahmynar_Domain.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId");

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("Ahmynar_Domain.ServiceOrder", b =>
                {
                    b.HasOne("Ahmynar_Domain.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("BudgetProduct", b =>
                {
                    b.HasOne("Ahmynar_Domain.Budget", null)
                        .WithMany()
                        .HasForeignKey("BudgetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ahmynar_Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BudgetService", b =>
                {
                    b.HasOne("Ahmynar_Domain.Budget", null)
                        .WithMany()
                        .HasForeignKey("BudgetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ahmynar_Domain.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductSale", b =>
                {
                    b.HasOne("Ahmynar_Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ahmynar_Domain.Sale", null)
                        .WithMany()
                        .HasForeignKey("SalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ahmynar_Domain.Customer", b =>
                {
                    b.Navigation("Budgets");

                    b.Navigation("Equipaments");
                });

            modelBuilder.Entity("Ahmynar_Domain.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
