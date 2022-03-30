﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAPI.Models;

namespace QuizAPI.Migrations
{
    [DbContext(typeof(QuizableDbContext))]
    partial class QuizableDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizAPI.Models.Option", b =>
                {
                    b.Property<int>("OptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OptionLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("OptionID");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");

                    b.HasData(
                        new
                        {
                            OptionID = 1,
                            IsCorrect = false,
                            OptionLetter = "A",
                            OptionText = "999",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionID = 2,
                            IsCorrect = false,
                            OptionLetter = "B",
                            OptionText = "69",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionID = 3,
                            IsCorrect = false,
                            OptionLetter = "C",
                            OptionText = "777",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionID = 4,
                            IsCorrect = true,
                            OptionLetter = "D",
                            OptionText = "2",
                            QuestionId = 1
                        },
                        new
                        {
                            OptionID = 5,
                            IsCorrect = false,
                            OptionLetter = "A",
                            OptionText = "Banna",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionID = 6,
                            IsCorrect = true,
                            OptionLetter = "B",
                            OptionText = "4",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionID = 7,
                            IsCorrect = false,
                            OptionLetter = "C",
                            OptionText = "876543245678",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionID = 8,
                            IsCorrect = false,
                            OptionLetter = "D",
                            OptionText = "42",
                            QuestionId = 2
                        },
                        new
                        {
                            OptionID = 9,
                            IsCorrect = false,
                            OptionLetter = "A",
                            OptionText = "Banna",
                            QuestionId = 3
                        },
                        new
                        {
                            OptionID = 10,
                            IsCorrect = true,
                            OptionLetter = "B",
                            OptionText = "6",
                            QuestionId = 3
                        },
                        new
                        {
                            OptionID = 11,
                            IsCorrect = false,
                            OptionLetter = "C",
                            OptionText = "876543245678",
                            QuestionId = 3
                        },
                        new
                        {
                            OptionID = 12,
                            IsCorrect = false,
                            OptionLetter = "D",
                            OptionText = "42",
                            QuestionId = 3
                        },
                        new
                        {
                            OptionID = 13,
                            IsCorrect = false,
                            OptionLetter = "A",
                            OptionText = "Banna",
                            QuestionId = 4
                        },
                        new
                        {
                            OptionID = 14,
                            IsCorrect = true,
                            OptionLetter = "B",
                            OptionText = "Monkey",
                            QuestionId = 4
                        },
                        new
                        {
                            OptionID = 15,
                            IsCorrect = false,
                            OptionLetter = "C",
                            OptionText = "876543245678",
                            QuestionId = 4
                        },
                        new
                        {
                            OptionID = 16,
                            IsCorrect = false,
                            OptionLetter = "D",
                            OptionText = "42",
                            QuestionId = 4
                        },
                        new
                        {
                            OptionID = 17,
                            IsCorrect = false,
                            OptionLetter = "A",
                            OptionText = "Banna",
                            QuestionId = 5
                        },
                        new
                        {
                            OptionID = 18,
                            IsCorrect = true,
                            OptionLetter = "B",
                            OptionText = "word",
                            QuestionId = 5
                        },
                        new
                        {
                            OptionID = 19,
                            IsCorrect = false,
                            OptionLetter = "C",
                            OptionText = "876543245678",
                            QuestionId = 5
                        },
                        new
                        {
                            OptionID = 20,
                            IsCorrect = false,
                            OptionLetter = "D",
                            OptionText = "42",
                            QuestionId = 5
                        });
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionTopic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            QuestionText = "What's 1+1",
                            QuestionTopic = "Math",
                            QuizId = 1
                        },
                        new
                        {
                            QuestionId = 2,
                            QuestionText = "What's 2+2",
                            QuestionTopic = "Math",
                            QuizId = 1
                        },
                        new
                        {
                            QuestionId = 3,
                            QuestionText = "What's 3+3",
                            QuestionTopic = "Math",
                            QuizId = 1
                        },
                        new
                        {
                            QuestionId = 4,
                            QuestionText = "WHaat does monkey mean",
                            QuestionTopic = "English",
                            QuizId = 2
                        },
                        new
                        {
                            QuestionId = 5,
                            QuestionText = "What does Word mean",
                            QuestionTopic = "English",
                            QuizId = 2
                        });
                });

            modelBuilder.Entity("QuizAPI.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PassP")
                        .HasColumnType("real");

                    b.Property<string>("QuizTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizTopic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuizId");

                    b.ToTable("quizzes");

                    b.HasData(
                        new
                        {
                            QuizId = 1,
                            CreatorName = "Brom",
                            PassP = 60f,
                            QuizTitle = "Maths",
                            QuizTopic = "Maths"
                        },
                        new
                        {
                            QuizId = 2,
                            CreatorName = "Mr Mokey",
                            PassP = 20f,
                            QuizTitle = "English",
                            QuizTopic = "English"
                        });
                });

            modelBuilder.Entity("QuizAPI.Models.UserStuff", b =>
                {
                    b.Property<int>("UserStuffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserStuffID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserStuffID = 1,
                            UserName = "Admin",
                            UserPassword = "Nah"
                        },
                        new
                        {
                            UserStuffID = 2,
                            UserName = "Teacher",
                            UserPassword = "teach"
                        });
                });

            modelBuilder.Entity("QuizAPI.Models.Option", b =>
                {
                    b.HasOne("QuizAPI.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.HasOne("QuizAPI.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizAPI.Models.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("QuizAPI.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
