﻿// <auto-generated />
using ChatApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApi.Migrations
{
    [DbContext(typeof(ChatApiContext))]
    [Migration("20220531105150_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ChatApi.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username1")
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.HasIndex("Username1");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ChatApi.Models.User", b =>
                {
                    b.HasOne("ChatApi.Models.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("Username1");
                });

            modelBuilder.Entity("ChatApi.Models.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
