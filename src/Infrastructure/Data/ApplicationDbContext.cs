using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using CinemaDB.Application.Common.Interfaces;
using CinemaDB.Domain.Entities;
using CinemaDB.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<ActorMovie> ActorMovies => Set<ActorMovie>();
    public DbSet<TvSeries> TvSeries => Set<TvSeries>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<Episode> Episodes => Set<Episode>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // One To Many Relationship Configuration (Director W Movie)
        builder.Entity<Director>()
        .HasMany(e => e.Movies)
        .WithOne(e => e.Director)
        .HasForeignKey(e => e.DirectorId)
        .IsRequired();

        // One To Many Relationship Configuration (TvSeries W Seasons)
        builder.Entity<TvSeries>()
        .HasMany(t => t.Seasons)
        .WithOne(s => s.TvSeries)
        .HasForeignKey(s => s.TvSeriesId)
        .IsRequired();

        // One To Many Relationship Configuration (Season W Episode)
        builder.Entity<Season>()
        .HasMany(s => s.Episodes)
        .WithOne(e => e.Season)
        .HasForeignKey(e => e.SeasonId)
        .IsRequired();

        base.OnModelCreating(builder);
    }
}
