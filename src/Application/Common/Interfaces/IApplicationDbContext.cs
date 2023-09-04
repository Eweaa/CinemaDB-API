using CinemaDB.Domain.Entities;

namespace CinemaDB.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Actor> Actors { get; }
    DbSet<Director> Directors { get; }
    DbSet<Movie> Movies { get; }
    //DbSet<User> User { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
