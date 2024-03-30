using CryptoTop.Entities.Entitties.Users;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CryptoTop.Entities;

public class CryptoTopDbContext : DbContext
{
    public CryptoTopDbContext()
    {

    }

    public CryptoTopDbContext(DbContextOptions<CryptoTopDbContext> options) : base(options)
    {

    }
    
    #region Tables

    public DbSet<UserEntity> Users { get; set; }

    #endregion
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseMySql(ServerVersion.Create(10, 9, 2, ServerType.MariaDb));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Tables Bidning
        builder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.UserName).IsUnique();
            entity.Property(x=>x.UserName).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Login).HasMaxLength(60).IsRequired();
            entity.Property(x=>x.PasswordHash).IsRequired().HasMaxLength(64).IsFixedLength();
            entity.Property(x => x.Email).HasMaxLength(60);
            entity.Property(x => x.Telegram).HasMaxLength(20);
        });
        #endregion

    }
}