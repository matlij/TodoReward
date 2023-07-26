﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoReward.Infrastructure;

#nullable disable

namespace TodoReward.Infrastructure.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230725115644_evenmorerewards")]
    partial class evenmorerewards
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("TodoReward.Core.Models.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Propability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rewards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9bdc45a-e3f1-4254-8aaf-f6c7261e3c5f"),
                            Description = "",
                            Propability = 10,
                            Title = "Weekend"
                        },
                        new
                        {
                            Id = new Guid("e8b0b78d-13b7-49ce-9efb-52c96c57009f"),
                            Description = "",
                            Propability = 1000,
                            Title = "One episode on TV"
                        },
                        new
                        {
                            Id = new Guid("bd5fd075-253d-467b-9eab-ca68e1c8dced"),
                            Description = "",
                            Propability = 1000,
                            Title = "One movie on TV"
                        },
                        new
                        {
                            Id = new Guid("196f36b2-e500-4cb9-8b89-c27a7799aa90"),
                            Description = "",
                            Propability = 500,
                            Title = "30 min gaming"
                        },
                        new
                        {
                            Id = new Guid("33e66e73-bb1a-4e34-be2c-7b5c90120b34"),
                            Description = "",
                            Propability = 1000,
                            Title = "30 min podcast"
                        },
                        new
                        {
                            Id = new Guid("6a869253-73d2-4f55-b940-fc70c4659956"),
                            Description = "",
                            Propability = 500,
                            Title = "30 min book reading"
                        },
                        new
                        {
                            Id = new Guid("6408112d-b819-4909-8a8c-0e5fe3a92c84"),
                            Description = "",
                            Propability = 1000,
                            Title = "Beer"
                        },
                        new
                        {
                            Id = new Guid("4871f681-778d-467f-b2a8-f2845834da22"),
                            Description = "",
                            Propability = 200,
                            Title = "Glas of Wine"
                        },
                        new
                        {
                            Id = new Guid("eec3bdaa-42fa-42cd-8a7f-85a7768548c3"),
                            Description = "",
                            Propability = 500,
                            Title = "Candy"
                        },
                        new
                        {
                            Id = new Guid("dcc2d9e7-b82e-4ff6-a373-6beb2a1c76a6"),
                            Description = "",
                            Propability = 500,
                            Title = "Soda"
                        },
                        new
                        {
                            Id = new Guid("d0355515-c7c3-4c01-bbc5-39d9779cf68d"),
                            Description = "",
                            Propability = 1000,
                            Title = "Coffea"
                        },
                        new
                        {
                            Id = new Guid("97169c09-6972-4723-a7e4-486c2cf0abd6"),
                            Description = "",
                            Propability = 1000,
                            Title = "Tea"
                        },
                        new
                        {
                            Id = new Guid("6fcda26a-7911-4ef0-adf9-1c78df965e30"),
                            Description = "",
                            Propability = 100,
                            Title = "Outside lunch"
                        },
                        new
                        {
                            Id = new Guid("03b27834-5e06-4be2-be41-6ef4b30c022c"),
                            Description = "",
                            Propability = 100,
                            Title = "Dessert after dinner"
                        },
                        new
                        {
                            Id = new Guid("0dfaf399-32fc-4972-9243-859af55909ea"),
                            Description = "",
                            Propability = 200,
                            Title = "Home made Pizza"
                        },
                        new
                        {
                            Id = new Guid("ecea8a51-9598-4de1-9873-90d411811fad"),
                            Description = "",
                            Propability = 100,
                            Title = "Cinema"
                        },
                        new
                        {
                            Id = new Guid("acb8f58e-173b-459d-be09-e8384e07afbe"),
                            Description = "",
                            Propability = 200,
                            Title = "Home made Pizza"
                        });
                });

            modelBuilder.Entity("TodoReward.Core.Models.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("TodoReward.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalPointsRewarded")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b"),
                            TotalPoints = 0,
                            TotalPointsRewarded = 0
                        });
                });

            modelBuilder.Entity("TodoReward.Core.Models.UserReward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RewardId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RewardId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRewards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d004c52c-63cb-4ebb-87d2-d8ce72b4877a"),
                            IsDone = false,
                            RewardId = new Guid("e9bdc45a-e3f1-4254-8aaf-f6c7261e3c5f"),
                            UserId = new Guid("03de3c78-5bda-4429-8147-7096c3d2f91b")
                        });
                });

            modelBuilder.Entity("TodoReward.Core.Models.UserReward", b =>
                {
                    b.HasOne("TodoReward.Core.Models.Reward", "Reward")
                        .WithMany()
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoReward.Core.Models.User", "User")
                        .WithMany("Rewards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reward");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoReward.Core.Models.User", b =>
                {
                    b.Navigation("Rewards");
                });
#pragma warning restore 612, 618
        }
    }
}