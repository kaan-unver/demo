using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Demo.Entities.Models;

namespace Demo.Infrastructure.Context;

public partial class DemoContext : DbContext
{
    public DemoContext()
    {
    }

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<County> Counties { get; set; }

    public virtual DbSet<CurrentJwt> CurrentJwts { get; set; }

    public virtual DbSet<Hometown> Hometowns { get; set; }

    public virtual DbSet<Jwthistory> Jwthistories { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MessageGroup> MessageGroups { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyHistory> PropertyHistories { get; set; }

    public virtual DbSet<User> Tusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: false)
             .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<City>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<County>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.City).WithMany(p => p.Counties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_County_City");
        });

        modelBuilder.Entity<Hometown>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.County).WithMany(p => p.Hometowns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hometown_County");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasOne(d => d.Group).WithMany(p => p.Messages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Groups");
        });

        modelBuilder.Entity<MessageGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Group");
        });


        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Environment, e.IsDeleted }).HasName("PK__Properti__2713ABDB74E2B3AA");
        });

        modelBuilder.Entity<PropertyHistory>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Environment, e.IsDeleted }).HasName("PK_PropertyHistories_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Id).ValueGeneratedNever();

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
