using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Feedback.Model
{
    public partial class aml_projectContext : DbContext
    {
        public aml_projectContext()
        {
        }

        public aml_projectContext(DbContextOptions<aml_projectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogEntry> LogEntry { get; set; }
        public virtual DbSet<SurveyForm> SurveyForm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(UnityFeedback.FeedbackAPI.Configuration.ConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coins).HasColumnName("coins");

                entity.Property(e => e.Lifes).HasColumnName("lifes");

                entity.Property(e => e.PlayerGuid)
                    .IsRequired()
                    .HasColumnName("playerGuid")
                    .HasColumnType("text");

                entity.Property(e => e.RestartTime).HasColumnName("restartTime");
            });

            modelBuilder.Entity<SurveyForm>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddTime)
                    .HasColumnName("addTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Annoyed).HasColumnName("annoyed");

                entity.Property(e => e.DeeplyConcentrated).HasColumnName("deeplyConcentrated");

                entity.Property(e => e.Frustrated).HasColumnName("frustrated");

                entity.Property(e => e.LostConnection).HasColumnName("lostConnection");

                entity.Property(e => e.PlayerGuid)
                    .IsRequired()
                    .HasColumnName("playerGuid")
                    .HasColumnType("text");

                entity.Property(e => e.PutEffort).HasColumnName("putEffort");

                entity.Property(e => e.WasGood).HasColumnName("wasGood");
            });
        }
    }
}
