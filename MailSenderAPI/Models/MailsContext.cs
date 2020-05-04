﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MailSenderAPI.Models
{
   public partial class MailsContext : DbContext
   {
      public MailsContext()
      {
      }

      public MailsContext(DbContextOptions<MailsContext> options)
          : base(options)
      {
      }

      public virtual DbSet<Mails> Mails { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         if (!optionsBuilder.IsConfigured)
         {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql("server=127.0.0.1;database=db;uid=root;pwd=123456", x => x.ServerVersion("8.0.20-mysql"));
         }
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Mails>(entity =>
         {
            entity.ToTable("mails");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Body)
                   .HasColumnName("body")
                   .HasColumnType("text")
                   .HasCharSet("utf8")
                   .HasCollation("utf8_general_ci");

            entity.Property(e => e.Datecreate)
                   .HasColumnName("datecreate")
                   .HasColumnType("datetime");

            //entity.Property(e => e.Recipients)
            //    .HasColumnName("recipients")
            //    .HasColumnType("varchar(45)")
            //    .HasCharSet("utf8")
            //    .HasCollation("utf8_general_ci");

            entity.Property(e => e.Result)
                .HasColumnName("result")
                .HasColumnType("varchar(45)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Subject)
                   .HasColumnName("subject")
                   .HasColumnType("varchar(250)")
                   .HasCharSet("utf8")
                   .HasCollation("utf8_general_ci");

            entity.Property(e => e.Failedmessage)
               .HasColumnName("failedmessage")
               .HasColumnType("varchar(1000)")
               .HasCharSet("utf8")
               .HasCollation("utf8_general_ci");

            entity.Property<string>("_recipients")
                  .HasColumnName("recipients")
                  .HasColumnType("varchar(250)")
                  .HasCharSet("utf8")
                  .HasCollation("utf8_general_ci");
         });

         OnModelCreatingPartial(modelBuilder);
      }

      partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   }
}
