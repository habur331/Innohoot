﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Innohoot.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Innohoot.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Innohoot.Models.Activity.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PollId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Poll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PollCollectionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PollCollectionId");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccessCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("ActivePollId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("interval");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("ParticipantList")
                        .HasColumnType("text[]");

                    b.Property<Guid>("PollCollectionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("StarTime")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AccessCode")
                        .IsUnique();

                    b.HasIndex("ActivePollId");

                    b.HasIndex("PollCollectionId");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Innohoot.Models.ElementsForPA.PollCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PollCollections");
                });

            modelBuilder.Entity("Innohoot.Models.ElementsForPA.VoteRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<string>("ParticipantName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("SessionId");

                    b.ToTable("VoteRecords");
                });

            modelBuilder.Entity("Innohoot.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Option", b =>
                {
                    b.HasOne("Innohoot.Models.Activity.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Poll", b =>
                {
                    b.HasOne("Innohoot.Models.ElementsForPA.PollCollection", "PollCollection")
                        .WithMany("Polls")
                        .HasForeignKey("PollCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PollCollection");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Session", b =>
                {
                    b.HasOne("Innohoot.Models.Activity.Poll", "ActivePoll")
                        .WithMany()
                        .HasForeignKey("ActivePollId");

                    b.HasOne("Innohoot.Models.ElementsForPA.PollCollection", "PollCollection")
                        .WithMany()
                        .HasForeignKey("PollCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innohoot.Models.Identity.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivePoll");

                    b.Navigation("PollCollection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Innohoot.Models.ElementsForPA.PollCollection", b =>
                {
                    b.HasOne("Innohoot.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Innohoot.Models.ElementsForPA.VoteRecord", b =>
                {
                    b.HasOne("Innohoot.Models.Activity.Option", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Innohoot.Models.Activity.Session", "Session")
                        .WithMany("VoteRecords")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Poll", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("Innohoot.Models.Activity.Session", b =>
                {
                    b.Navigation("VoteRecords");
                });

            modelBuilder.Entity("Innohoot.Models.ElementsForPA.PollCollection", b =>
                {
                    b.Navigation("Polls");
                });

            modelBuilder.Entity("Innohoot.Models.Identity.User", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
