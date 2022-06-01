﻿// <auto-generated />
using System;
using ChatApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatApi.Migrations
{
    [DbContext(typeof(ChatApiContext))]
    partial class ChatApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("ChatApi.Models.Chat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("User1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("ChatApi.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChatId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("When")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Message");
                });

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

            modelBuilder.Entity("ChatApi.Models.Message", b =>
                {
                    b.HasOne("ChatApi.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("ChatApi.Models.User", b =>
                {
                    b.HasOne("ChatApi.Models.User", null)
                        .WithMany("Friends")
                        .HasForeignKey("Username1");
                });

            modelBuilder.Entity("ChatApi.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ChatApi.Models.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
