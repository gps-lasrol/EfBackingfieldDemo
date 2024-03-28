﻿// <auto-generated />
using System;
using EfCoreBackingFieldDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreBackingFieldDemo.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20240328205749_AddedV2Tests")]
    partial class AddedV2Tests
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.BlogV2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("BlogV2s");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.PostV2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BlogV2Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BlogV2Id");

                    b.ToTable("PostV2s");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.Post", b =>
                {
                    b.HasOne("EfCoreBackingFieldDemo.Model.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.PostV2", b =>
                {
                    b.HasOne("EfCoreBackingFieldDemo.Model.BlogV2", "BlogV2")
                        .WithMany("PostV2s")
                        .HasForeignKey("BlogV2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogV2");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("EfCoreBackingFieldDemo.Model.BlogV2", b =>
                {
                    b.Navigation("PostV2s");
                });
#pragma warning restore 612, 618
        }
    }
}