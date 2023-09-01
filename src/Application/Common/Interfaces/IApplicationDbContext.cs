using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Actor> Actors { get; }
    DbSet<Director> Directors { get; }
    DbSet<Movie> Movies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
