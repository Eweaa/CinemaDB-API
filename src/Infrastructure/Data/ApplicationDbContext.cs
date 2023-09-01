using System.Reflection;
using System.Reflection.Emit;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Movie>()
                .HasMany(M => M.Actors)
                .WithMany(M => M.Movies)
                .UsingEntity<ActorMovie>();

        base.OnModelCreating(builder);
    }
}
