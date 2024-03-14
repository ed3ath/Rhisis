﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rhisis.Infrastructure.Persistance.Contexts;

#nullable disable

namespace Rhisis.Infrastructure.Persistance.Sqlite.Migrations.Game
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20230624111422_SkillBuffAttributes")]
    partial class SkillBuffAttributes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.ItemEntity", b =>
                {
                    b.Property<int>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte?>("Element")
                        .HasColumnType("INTEGER");

                    b.Property<byte?>("ElementRefine")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<byte?>("Refine")
                        .HasColumnType("INTEGER");

                    b.HasKey("SerialNumber");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Angle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(0f);

                    b.Property<int>("BankPin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0L);

                    b.Property<int>("FaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fp")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gold")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HairColor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HairId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("LastConnectionTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MapLayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("PlayTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0L);

                    b.Property<float>("PosX")
                        .HasColumnType("REAL");

                    b.Property<float>("PosY")
                        .HasColumnType("REAL");

                    b.Property<float>("PosZ")
                        .HasColumnType("REAL");

                    b.Property<int>("SkillPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkinSetId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Slot")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stamina")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerItemEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("StorageType")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Slot")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "StorageType", "Slot");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasIndex("PlayerId", "StorageType", "Slot")
                        .IsUnique();

                    b.ToTable("PlayerItems");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerQuestEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuestId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPatrolDone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonsterKilled1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonsterKilled2")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId", "QuestId");

                    b.HasIndex("PlayerId", "QuestId")
                        .IsUnique();

                    b.ToTable("PlayerQuests");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffAttributeEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Attribute")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "SkillId", "Attribute");

                    b.ToTable("PlayerSkillBuffAttributes");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RemainingTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "SkillId");

                    b.HasIndex("PlayerId", "SkillId")
                        .IsUnique();

                    b.ToTable("PlayerSkillBuffs");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillEntity", b =>
                {
                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId", "SkillId");

                    b.HasIndex("PlayerId", "SkillId")
                        .IsUnique();

                    b.ToTable("PlayerSkills");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerItemEntity", b =>
                {
                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.ItemEntity", "Item")
                        .WithOne()
                        .HasForeignKey("Rhisis.Infrastructure.Persistance.Entities.PlayerItemEntity", "ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", "Player")
                        .WithMany("Items")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerQuestEntity", b =>
                {
                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", "Player")
                        .WithMany("Quests")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffAttributeEntity", b =>
                {
                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffEntity", null)
                        .WithMany("Attributes")
                        .HasForeignKey("PlayerId", "SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffEntity", b =>
                {
                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", "Player")
                        .WithMany("Buffs")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillEntity", b =>
                {
                    b.HasOne("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", "Player")
                        .WithMany("Skills")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerEntity", b =>
                {
                    b.Navigation("Buffs");

                    b.Navigation("Items");

                    b.Navigation("Quests");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Rhisis.Infrastructure.Persistance.Entities.PlayerSkillBuffEntity", b =>
                {
                    b.Navigation("Attributes");
                });
#pragma warning restore 612, 618
        }
    }
}
