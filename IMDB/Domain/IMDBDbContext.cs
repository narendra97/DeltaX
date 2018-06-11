using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace imdb.Domain
{
    public partial class IMDBDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<ActorMovie> Actor_Movie { get; set; }

        public DbSet<ProducerMovie> Producer_Movie { get; set; }

        public static readonly LoggerFactory LoggerFactory
        = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public IMDBDbContext(DbContextOptions<IMDBDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Actor>().HasIndex(p => new { p.Name, p.Sex, p.DOB });

            modelBuilder.Entity<Producer>().HasIndex(p => new { p.Name, p.Sex, p.DOB });

            modelBuilder.Entity<Movie>().HasOne(c => c.Producer).WithMany().OnDelete(DeleteBehavior.SetNull);            

            modelBuilder.Entity<ActorMovie>().HasIndex(p => new { p.ActorId, p.MovieId});

            modelBuilder.Entity<ProducerMovie>().HasIndex(p => new { p.ProducerId, p.MovieId });

        }
    }
}
